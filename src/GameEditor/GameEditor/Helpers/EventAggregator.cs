using GameEditor.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GameEditor.Helpers
{
    public class EventAggregator : IEventAggregator
    {
        readonly List<Handler> handlers = new List<Handler>();
        public static Action<object, object> HandlerResultProcessing = (target, result) => { };

        public bool HandlerExistsFor(Type messageType)
        {
            return handlers.Any(handler => handler.Handles(messageType) & !handler.IsDead);
        }

        public void Publish(object message, Action<Action> marshal)
        {
            if (message == null) throw new ArgumentNullException("message");
            if (marshal == null) throw new ArgumentNullException("marshal");
            Handler[] toNotify;
            lock (handlers) toNotify = handlers.ToArray();
            marshal(() =>
            {
                var messageType = message.GetType();
                var dead = toNotify
                    .Where(handler => !handler.Handle(messageType, message))
                    .ToList();
                if (dead.Any())
                {
                    lock (handlers) dead.Apply(x => handlers.Remove(x));
                }
            });
        }

        public void Subscribe(object subscriber)
        {
            if (subscriber == null) throw new ArgumentNullException("subscriber");
            lock (handlers)
            {
                if (handlers.Any(x => x.Matches(subscriber))) return;
                handlers.Add(new Handler(subscriber));
            }
        }

        public void Unsubscribe(object subscriber)
        {
            if (subscriber == null) throw new ArgumentNullException("subscriber");
            lock (handlers)
            {
                var found = handlers.FirstOrDefault(x => x.Matches(subscriber));
                if (found != null) handlers.Remove(found);
            }
        }

        class Handler
        {
            readonly WeakReference reference;
            readonly Dictionary<Type, MethodInfo> supportedHandlers = new Dictionary<Type, MethodInfo>();

            public bool IsDead { get { return reference.Target == null; } }

            public Handler(object handler)
            {
                reference = new WeakReference(handler);
                var interfaces = handler.GetType().GetInterfaces()
                    .Where(x => typeof(IHandle).IsAssignableFrom(x) && x.IsGenericType);

                foreach (var @interface in interfaces)
                {
                    var type = @interface.GetGenericArguments()[0];
                    var method = @interface.GetMethod("Handle", new Type[] { type });
                    if (method != null) supportedHandlers[type] = method;
                }
            }

            public bool Matches(object instance)
            {
                return reference.Target == instance;
            }

            public bool Handle(Type messageType, object message)
            {
                var target = reference.Target;
                if (target == null) return false;
                foreach (var pair in supportedHandlers)
                {
                    if (pair.Key.IsAssignableFrom(messageType))
                    {
                        var result = pair.Value.Invoke(target, new[] { message });
                        if (result != null) HandlerResultProcessing(target, result);
                    }
                }
                return true;
            }

            public bool Handles(Type messageType)
            {
                return supportedHandlers.Any(pair => pair.Key.IsAssignableFrom(messageType));
            }
        }
    }
    public interface IHandle { }

    public interface IHandle<TMessage> : IHandle
    {
        void Handle(TMessage message);
    }
}

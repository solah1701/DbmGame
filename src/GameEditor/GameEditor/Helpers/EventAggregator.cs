using GameEditor.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GameEditor.Helpers
{
    public class EventAggregator : IEventAggregator
    {
        readonly List<Handler> _handlers = new List<Handler>();
        private static readonly Action<object, object> HandlerResultProcessing = (target, result) => { };

        public bool HandlerExistsFor(Type messageType)
        {
            lock (_handlers)
            {
                return _handlers.Any(handler => handler.Handles(messageType) & !handler.IsDead);
            }
        }

        public void Publish(object message, Action<Action> marshal)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));
            if (marshal == null) throw new ArgumentNullException(nameof(marshal));
            Handler[] toNotify;
            lock (_handlers) toNotify = _handlers.ToArray();
            marshal(() =>
            {
                var messageType = message.GetType();
                var dead = toNotify
                    .Where(handler => !handler.Handle(messageType, message))
                    .ToList();
                if (!dead.Any()) return;
                lock (_handlers) dead.Apply(x => _handlers.Remove(x));
            });
        }

        public void Subscribe(object subscriber)
        {
            if (subscriber == null) throw new ArgumentNullException(nameof(subscriber));
            lock (_handlers)
            {
                if (_handlers.Any(x => x.Matches(subscriber))) return;
                _handlers.Add(new Handler(subscriber));
            }
        }

        public void Unsubscribe(object subscriber)
        {
            if (subscriber == null) throw new ArgumentNullException(nameof(subscriber));
            lock (_handlers)
            {
                var found = _handlers.FirstOrDefault(x => x.Matches(subscriber));
                if (found != null) _handlers.Remove(found);
            }
        }

        private class Handler
        {
            readonly WeakReference _reference;
            readonly Dictionary<Type, MethodInfo> _supportedHandlers = new Dictionary<Type, MethodInfo>();

            public bool IsDead => _reference.Target == null;

            public Handler(object handler)
            {
                _reference = new WeakReference(handler);
                var interfaces = handler.GetType().GetInterfaces()
                    .Where(x => typeof(IHandle).IsAssignableFrom(x) && x.IsGenericType);

                foreach (var @interface in interfaces)
                {
                    var type = @interface.GetGenericArguments()[0];
                    var method = @interface.GetMethod("Handle", new[] { type });
                    if (method != null) _supportedHandlers[type] = method;
                }
            }

            public bool Matches(object instance)
            {
                return _reference.Target == instance;
            }

            public bool Handle(Type messageType, object message)
            {
                var target = _reference.Target;
                if (target == null) return false;
                foreach (var result in _supportedHandlers.Where(pair => pair.Key.IsAssignableFrom(messageType)).Select(pair => pair.Value.Invoke(target, new[] { message })).Where(result => result != null))
                {
                    HandlerResultProcessing(target, result);
                }
                return true;
            }

            public bool Handles(Type messageType)
            {
                return _supportedHandlers.Any(pair => pair.Key.IsAssignableFrom(messageType));
            }
        }
    }
    public interface IHandle { }

    public interface IHandle<in TMessage> : IHandle
    {
        void Handle(TMessage message);
    }
}

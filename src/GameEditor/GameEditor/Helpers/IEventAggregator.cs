using System;

namespace GameEditor.Helpers
{
    public interface IEventAggregator
    {
        bool HandlerExistsFor(Type messageType);
        void Subscribe(object subscriber);
        void Unsubscribe(object subscriber);
        void Publish(object message, Action<Action> marshal);
    }
}

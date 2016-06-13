using System;

namespace GameEditor.Wcf.Harness.Helpers
{
    public interface IEventAggregator
    {
        bool HandlerExistsFor(Type messageType);
        void Subscribe(object subscriber);
        void Unsubscribe(object subscriber);
        void Publish(object message, Action<Action> marshal);
    }
}

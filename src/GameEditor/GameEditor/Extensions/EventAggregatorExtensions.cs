using GameEditor.Helpers;
using System.Threading;
using System.Threading.Tasks;

namespace GameEditor.Extensions
{
    public static class EventAggregatorExtensions
    {
        public static void PublishOnCurrentThread(this IEventAggregator eventAggregator, object message)
        {
            eventAggregator.Publish(message, action => action());
        }

        public static void PublishOnBackgroundThread(this IEventAggregator eventAggregator, object message)
        {
            eventAggregator.Publish(message, action => Task.Factory.StartNew(action, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default));
        }
    }
}

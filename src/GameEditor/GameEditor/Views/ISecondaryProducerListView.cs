using GameCore;
using GameEditor.Views.Base;
using GameEditor.Views.UI;
using System.Collections.Generic;

namespace GameEditor.Views
{
    public interface ISecondaryProducerListView : IListView<ISecondaryProducer>
    {
        IUIListView UIListView { get; }
        List<string> GoodsList { set; }
        int MaxConsumers { get; set; }
        string Produces { get; set; }
        int Amount { get; set; }
        int Rate { get; set; }
    }
}

using GameCore;
using GameEditor.Views.Base;
using System.Collections.Generic;

namespace GameEditor.Views
{
    public interface IPrimaryProducerListView : IListView<IPrimaryProducer>
    {
        int Amount { get; set; }
        string Produces { get; set; }
        List<string> GoodsList { set; }
        int ProductionRate { get; set; }
    }
}

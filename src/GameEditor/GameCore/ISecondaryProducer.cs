using System.Collections.Generic;

namespace GameCore
{
    public interface ISecondaryProducer : INamedItem
    {
        List<IGoods> Consumes { get; set; }
        int MaxConsumers { get; set; }
        IGoods Produces { get; set; }
        int Amount { get; set; }
        int Rate { get; set; }
    }
}
using System.Collections.Generic;

namespace GameCore
{
    public interface IGame : INamedItem
    {
        List<IGoods> GoodsList { get; set; }
        List<IPrimaryProducer> PrimaryProducerList { get; set; }
        List<ISecondaryProducer> SecondaryProducerList { get; set; }
    }
}

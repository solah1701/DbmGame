namespace GameCore
{
    public interface IPrimaryProducer : INamedItem
    {
        int Amount { get; set; }
        IGoods Produces { get; set; }
        int ProductionRate { get; set; }
    }
}
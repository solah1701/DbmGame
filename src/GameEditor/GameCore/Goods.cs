using System.Runtime.Serialization;

namespace GameCore
{
    [DataContract(Name = "Goods", Namespace = "GameCore")]
    public class Goods : IGoods
    {
        [DataMember()]
        public string Name { get; set; }
    }
}

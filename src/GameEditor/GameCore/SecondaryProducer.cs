using GameCore.Serialization;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System;

namespace GameCore
{
    [DataContract(Name ="SecondaryProducer", Namespace = "GameCore")]
    public class SecondaryProducer : SerializerBase<SecondaryProducer>, ISecondaryProducer
    {
        [DataMember()]
        public string Name { get; set; }
        [DataMember()]
        public int MaxConsumers { get; set; }
        [DataMember()]
        public List<IGoods> Consumes { get; set; }
        [DataMember()]
        public IGoods Produces { get; set; }
        [DataMember()]
        public int Amount { get; set; }
        [DataMember()]
        public int Rate { get; set; }

        public SecondaryProducer()
        {
            Consumes = new List<IGoods>();
        }

        public override void AddKnownTypes(IList<Type> knownTypes)
        {
            knownTypes.Add(typeof(Goods));
        }
    }
}

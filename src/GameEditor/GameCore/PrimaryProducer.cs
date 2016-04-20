using GameCore.Serialization;
using System.Runtime.Serialization;
using System;
using System.Collections.Generic;

namespace GameCore
{
    [DataContract(Name = "PrimaryProducer", Namespace = "GameCore")]
    public class PrimaryProducer : SerializerBase<PrimaryProducer>, IPrimaryProducer
    {
        [DataMember()]
        public string Name { get; set; }
        [DataMember()]
        public int Amount { get; set; }
        [DataMember()]
        public int ProductionRate { get; set; }
        [DataMember()]
        public IGoods Produces { get; set; }

        public PrimaryProducer()
        {
            Produces = new Goods();
        }

        public PrimaryProducer(string name, int amount, int productionRate, IGoods produces)
        {
            Name = name;
            Amount = amount;
            ProductionRate = productionRate;
            Produces = produces;
        }

        public override void AddKnownTypes(IList<Type> knownTypes)
        {
            knownTypes.Add(typeof(Goods));
        }
    }
}

using GameCore.Serialization;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization;

namespace GameCore
{
    [DataContract(Name = "Game", Namespace = "GameCore")]
    public class Game : SerializerBase<Game>, IGame
    {
        [DataMember()]
        public string Name { get; set; }
        [DataMember()]
        public List<IGoods> GoodsList { get; set; }
        [DataMember()]
        public List<IPrimaryProducer> PrimaryProducerList { get; set; }
        [DataMember()]
        public List<ISecondaryProducer> SecondaryProducerList { get; set; }

        public Game()
        {
            GoodsList = new List<IGoods>();
            PrimaryProducerList = new List<IPrimaryProducer>();
            SecondaryProducerList = new List<ISecondaryProducer>();
        }

        public override void AddKnownTypes(IList<Type> knownTypes)
        {
            knownTypes.Add(typeof(Goods));
            knownTypes.Add(typeof(PrimaryProducer));
            knownTypes.Add(typeof(SecondaryProducer));
        }
    }
}

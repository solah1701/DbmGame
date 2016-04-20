using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace GameCore.UnitTest
{
    [TestClass]
    public class SerializerTest
    {
        [TestMethod]
        public void Goods_Serialize_Deserialize()
        {
            var goods = new Goods { Name = "Test Goods" };
            Console.WriteLine("Original record: {0}", goods.Name);

            var stream1 = new MemoryStream();
            var serializer = new DataContractSerializer(typeof(Goods));
            serializer.WriteObject(stream1, goods);

            stream1.Position = 0;

            var goods2 = (Goods)serializer.ReadObject(stream1);

            Console.WriteLine("Deserialized record: {0}", goods2.Name);
        }

        [TestMethod]
        public void Game_Serialize_Deserialize()
        {
            var goods = new Goods { Name = "Test goods" };
            var goods1 = new Goods { Name = "Second Goods" };
            var game = new Game { Name = "Test Game", GoodsList = new List<IGoods> { goods, goods1 } };
            var knownTypes = new List<Type>();
            game.AddKnownTypes(knownTypes);
            Console.WriteLine("Original record: {0} - goods {1}, {2}", game.Name, game.GoodsList[0].Name, game.GoodsList[1].Name);

            var stream1 = new MemoryStream();
            var serializer = new DataContractSerializer(typeof(Game), knownTypes);
            serializer.WriteObject(stream1, game);

            stream1.Position = 0;

            var game2 = (Game)serializer.ReadObject(stream1);

            Console.WriteLine("Deserialized record: {0} - goods {1}, {2}", game2.Name, game2.GoodsList[0].Name, game2.GoodsList[1].Name);
        }

        [TestMethod]
        public void Game_Serialize_Deserialize_Internal()
        {
            var goods = new Goods { Name = "Test goods" };
            var goods1 = new Goods { Name = "Second Goods" };
            var game = new Game { Name = "Test Game", GoodsList = new List<IGoods> { goods, goods1 } };
            Console.WriteLine("Original record: {0} - goods {1}, {2}", game.Name, game.GoodsList[0].Name, game.GoodsList[1].Name);

            var stream1 = new MemoryStream();

            game.WriteObject(stream1);
            //serializer.WriteObject(stream1, game);

            stream1.Position = 0;

            var game2 = game.ReadObject(stream1);
            //var game2 = (Game)serializer.ReadObject(stream1);

            Console.WriteLine("Deserialized record: {0} - goods {1}, {2}", game2.Name, game2.GoodsList[0].Name, game2.GoodsList[1].Name);
        }

        [TestMethod]
        public void Game_Serialize_Deserialize_File()
        {
            const string fileName = @"C:\Users\Stephen\Documents\Visual Studio 2015\Projects\GameEditor\GameCore.UnitTest\TestResults\TestFile.xml";
            var goods = new Goods { Name = "Test goods" };
            var goods1 = new Goods { Name = "Second Goods" };
            var game = new Game { Name = "Test Game", GoodsList = new List<IGoods> { goods, goods1 } };
            Console.WriteLine("Original record: {0} - goods {1}, {2}", game.Name, game.GoodsList[0].Name, game.GoodsList[1].Name);

            using (var stream1 = new FileStream(fileName, FileMode.Create))
            {
                game.WriteObject(stream1);
            }
            //serializer.WriteObject(stream1, game);

            using (var stream2 = new FileStream(fileName, FileMode.Open))
            {
                var game2 = game.ReadObject(stream2);
                //var game2 = (Game)serializer.ReadObject(stream1);

                Console.WriteLine("Deserialized record: {0} - goods {1}, {2}", game2.Name, game2.GoodsList[0].Name, game2.GoodsList[1].Name);
            }
        }
    }
}

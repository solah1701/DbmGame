using GameEditor.IoC;
using GameEditor.Models;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System.Reflection;

namespace GameEditor.UnitTest
{
    [TestClass]
    public class NinjectTest
    {
        public class MyTestFirst
        {
            [Inject]
            public GameModel Model { get; private set; }

            public GameModel UseModel()
            {
                return Model;
            }

        }

        public class MyTestSecond
        {
            [Inject]
            public GameModel Model { get; private set; }

            public GameModel UseModel()
            {
                return Model;
            }
        }

        [TestMethod]
        public void TestSingleton()
        {
            var x = IoCContainer.Resolve<IGameModel>();
            x.Game.Name = "Test";
            var y = IoCContainer.Resolve<IGameModel>();

            Assert.AreEqual(x.Game.Name, y.Game.Name);
        }
    }
}

using System;
using Caliburn.Micro;
using GameEditor.Wcf.Harness.Wpf.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace GameEditor.WcfHarness.Wpf.UnitTest
{
    public abstract class UnitTestBase
    {
        public IEventAggregator EventAggregator { get; set; }
        public IGameModel GameModel { get; set; }

        [TestInitialize]
        public void Init()
        {
            EventAggregator = Substitute.For<IEventAggregator>();
            GameModel = Substitute.For<IGameModel>();
            Init(EventAggregator, GameModel);
        }

        public abstract void Init(IEventAggregator eventAggregator, IGameModel gameModel);
    }
}

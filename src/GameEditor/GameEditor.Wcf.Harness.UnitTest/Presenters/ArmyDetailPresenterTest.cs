using System;
using GameEditor.Wcf.Harness.Helpers;
using GameEditor.Wcf.Harness.Models;
using GameEditor.Wcf.Harness.Presenters;
using GameEditor.Wcf.Harness.Views;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace GameEditor.Wcf.Harness.UnitTest.Presenters
{
    [TestClass]
    public class ArmyDetailPresenterTest
    {
        private IArmyDetailPresenter SystemUnderTest { get; set; }
        private IGameModel GameModel { get; set; }
        private IEventAggregator EventAggregator { get; set; }
        private IArmyDetailView View { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            GameModel = Substitute.For<IGameModel>();
            EventAggregator = Substitute.For<IEventAggregator>();
            View = Substitute.For<IArmyDetailView>();
            SystemUnderTest = new ArmyDetailPresenter(EventAggregator, GameModel);
            SystemUnderTest.SetView(View);
        }

        private void SetInitialValues()
        {
            // Some Initial Values
            GameModel.CurrentArmyDefinitionId = 1;
            GameModel.CurrentArmyUnitDefinitionId = 2;
            GameModel.CurrentAllyDefinitionId = 3;
            GameModel.CurrentAllyArmyDefinitionId = 4;
        }

        [TestMethod]
        public void SelectArmyDetail_Does_Something()
        {
            // Arrange

            // Act

            // Assert

        }
    }
}

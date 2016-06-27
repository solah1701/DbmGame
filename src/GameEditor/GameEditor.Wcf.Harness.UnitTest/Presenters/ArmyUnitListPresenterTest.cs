using System;
using GameEditor.Wcf.Harness.Helpers;
using GameEditor.Wcf.Harness.Models;
using GameEditor.Wcf.Harness.Presenters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace GameEditor.Wcf.Harness.UnitTest.Presenters
{
    [TestClass]
    public class ArmyUnitListPresenterTest
    {
        private ArmyUnitListPresenter SystemUnderTest { get; set; }
        private IGameModel GameModel { get; set; }
        private IEventAggregator EventAggregator { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            GameModel = Substitute.For<IGameModel>();
            EventAggregator = Substitute.For<IEventAggregator>();
            SystemUnderTest = new ArmyUnitListPresenter(EventAggregator, GameModel);
        }

        private void SetInitialValues()
        {
            // Some Initial Values
            GameModel.CurrentArmyDefinitionId = 1;
            GameModel.CurrentArmyUnitDefinitionId = 2;
            GameModel.CurrentAllyArmyDefinitionId = 3;
        }

        [TestMethod]
        public void Constructor_Subscribes_To_EventAggregator()
        {
            // Arrange

            // Act

            // Assert
            EventAggregator.Received(1).Subscribe(SystemUnderTest);
        }

        [TestMethod]
        public void SelectUnitArmy_Leaves_The_CurrentArmyId_Unchanged()
        {
            // Arrange
            const int value = 5;
            SetInitialValues();
            var currentArmyId = GameModel.CurrentArmyDefinitionId;

            // Act
            SystemUnderTest.SelectUnitArmy(value);

            // Assert
            Assert.AreEqual(currentArmyId, GameModel.CurrentArmyDefinitionId);
        }

        [TestMethod]
        public void SelectUnitArmy_Sets_The_CurrentUnitId_To_value()
        {
            // Arrange
            const int value = 5;
            SetInitialValues();

            // Act
            SystemUnderTest.SelectUnitArmy(value);

            // Assert
            Assert.AreEqual(value, GameModel.CurrentArmyUnitDefinitionId);
        }

        [TestMethod]
        public void SelectUnitArmy_Leaves_The_CurrentAllyId_Unchanged()
        {
            // Arrange
            const int value = 5;
            SetInitialValues();
            var currentAllyId = GameModel.CurrentAllyArmyDefinitionId;

            // Act
            SystemUnderTest.SelectUnitArmy(value);

            // Assert
            Assert.AreEqual(currentAllyId, GameModel.CurrentAllyArmyDefinitionId);
        }
    }
}

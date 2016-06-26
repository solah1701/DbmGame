using System;
using GameEditor.Wcf.Harness.Helpers;
using GameEditor.Wcf.Harness.Models;
using GameEditor.Wcf.Harness.Presenters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace GameEditor.Wcf.Harness.UnitTest.Presenters
{
    [TestClass]
    public class AllyListPresenterTest
    {
        private AllyListPresenter SystemUnderTest { get; set; }
        private IGameModel GameModel { get; set; }
        private IEventAggregator EventAggregator { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            GameModel = Substitute.For<IGameModel>();
            EventAggregator = Substitute.For<IEventAggregator>();
            SystemUnderTest = new AllyListPresenter(EventAggregator, GameModel);
        }

        private void SetInitialValues()
        {
            // Some Initial Values
            GameModel.CurrentArmyDefinitionId = 1;
            GameModel.CurrentArmyUnitDefinitionId = 2;
            GameModel.CurrentAllyDefinitionId = 3;
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
        public void SelectArmy_Leaves_The_CurrentArmyId_Unchanged()
        {
            // Arrange
            const int value = 5;
            SetInitialValues();
            var currentArmyId = GameModel.CurrentArmyDefinitionId;

            // Act
            SystemUnderTest.SelectArmy(value);

            // Assert
            Assert.AreEqual(currentArmyId, GameModel.CurrentArmyDefinitionId);
        }

        [TestMethod]
        public void SelectArmy_Leaves_The_CurrentUnitId_Unchanged()
        {
            // Arrange
            const int value = 5;
            SetInitialValues();
            var currentUnitId = GameModel.CurrentArmyUnitDefinitionId;

            // Act
            SystemUnderTest.SelectArmy(value);

            // Assert
            Assert.AreEqual(currentUnitId, GameModel.CurrentArmyUnitDefinitionId);
        }

        [TestMethod]
        public void SelectArmy_Sets_The_CurrentAllyId_To_Value()
        {
            // Arrange
            const int value = 5;
            SetInitialValues();

            // Act
            SystemUnderTest.SelectArmy(value);

            // Assert
            Assert.AreEqual(value, GameModel.CurrentAllyDefinitionId);
        }
    }
}

using System;
using GameEditor.Wcf.Harness.Helpers;
using GameEditor.Wcf.Harness.Models;
using GameEditor.Wcf.Harness.Presenters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace GameEditor.Wcf.Harness.UnitTest.Presenters
{
    [TestClass]
    public class ArmyListPresenterTest
    {
        private ArmyListPresenter SystemUnderTest { get; set; }
        private IGameModel GameModel { get; set; }
        private IEventAggregator EventAggregator { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            GameModel = Substitute.For<IGameModel>();
            EventAggregator = Substitute.For<IEventAggregator>();
            SystemUnderTest = new ArmyListPresenter(EventAggregator, GameModel);
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
        public void SelectArmy_Sets_The_CurrentArmyId_To_Value()
        {
            // Arrange
            const int value = 5;
            SetInitialValues();

            // Act
            SystemUnderTest.SelectArmy(value);

            // Assert
            Assert.AreEqual(value, GameModel.CurrentArmyDefinitionId);
        }

        [TestMethod]
        public void SelectArmy_Sets_The_CurrentUnitId_To_Zero()
        {
            // Arrange
            const int value = 5;
            SetInitialValues();

            // Act
            SystemUnderTest.SelectArmy(value);

            // Assert
            Assert.AreEqual(0, GameModel.CurrentArmyUnitDefinitionId);
        }

        [TestMethod]
        public void SelectArmy_Sets_The_CurrentAllyId_To_Zero()
        {
            // Arrange
            const int value = 5;
            SetInitialValues();

            // Act
            SystemUnderTest.SelectArmy(value);

            // Assert
            Assert.AreEqual(0, GameModel.CurrentAllyDefinitionId);
        }
    }
}

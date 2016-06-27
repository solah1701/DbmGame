using System;
using GameEditor.Wcf.Harness.Helpers;
using GameEditor.Wcf.Harness.Models;
using GameEditor.Wcf.Harness.Presenters;
using GameEditor.Wcf.Harness.Views;
using GameEditor.Wcf.Harness.WarGameServiceReference;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace GameEditor.Wcf.Harness.UnitTest.Presenters
{
    [TestClass]
    public class AllyListPresenterTest
    {
        private IAllyListPresenter SystemUnderTest { get; set; }
        private IGameModel GameModel { get; set; }
        private IEventAggregator EventAggregator { get; set; }
        private IAllyListView View { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            GameModel = Substitute.For<IGameModel>();
            EventAggregator = Substitute.For<IEventAggregator>();
            View = Substitute.For<IAllyListView>();
            SystemUnderTest = new AllyListPresenter(EventAggregator, GameModel);
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
            SystemUnderTest.SelectArmy();

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
            SystemUnderTest.SelectArmy();

            // Assert
            Assert.AreEqual(currentUnitId, GameModel.CurrentArmyUnitDefinitionId);
        }

        [TestMethod]
        public void SelectArmy_Sets_The_CurrentAllyId_To_Value()
        {
            // Arrange
            const int value = 5;
            SetInitialValues();
            const string armyName = "ArmyName";
            var armyDefinition = new ArmyDefinition
            {
                ArmyName = armyName,
                Id = value,
                ArmyBook = 1,
                ArmyList = 2,
                MinYear = -3000,
                MaxYear = -2500
            };
            GameModel.GetArmyDefinition(armyName).Returns(armyDefinition);
            View.SelectedAlly.Returns(armyName);

            // Act
            SystemUnderTest.SelectArmy();

            // Assert
            Assert.AreEqual(value, GameModel.CurrentAllyArmyDefinitionId);
        }

        [TestMethod]
        public void SelectAlly_Sets_The_CurrentAllyId_To_Value()
        {
            // Arrange
            const int value = 5;
            SetInitialValues();
            var alliedArmyDefinition = new AlliedArmyDefinition
            {
                AllyName = "AllyName",
                Id = value,
                ArmyId = 15,
                ArmyBook = 1,
                ArmyList = 2,
                MinYear = -3000,
                MaxYear = -2500
            };
            GameModel.GetAlliedArmyDefinition(value).Returns(alliedArmyDefinition);

            // Act
            SystemUnderTest.SelectAlly(value);

            // Assert
            Assert.AreEqual(value, GameModel.CurrentAllyArmyDefinitionId);
        }

        [TestMethod]
        public void SelectArmy_Sets_The_CurrentAllyArmyId_To_Unchanged()
        {
            // Arrange
            const int value = 5;
            SetInitialValues();
            var currentAllyArmyId = GameModel.CurrentAllyArmyDefinitionId;

            // Act
            SystemUnderTest.SelectArmy();

            // Assert
            Assert.AreEqual(currentAllyArmyId, GameModel.CurrentAllyArmyDefinitionId);
        }
    }
}

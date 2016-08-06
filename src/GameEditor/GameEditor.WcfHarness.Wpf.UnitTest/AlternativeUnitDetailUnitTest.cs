using System;
using Caliburn.Micro;
using GameEditor.Wcf.Harness.Wpf.EventAggregators;
using GameEditor.Wcf.Harness.Wpf.Models;
using GameEditor.Wcf.Harness.Wpf.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace GameEditor.WcfHarness.Wpf.UnitTest
{
    [TestClass]
    public class AlternativeUnitDetailUnitTest
    {
        public AlternativeUnitDetailViewModel AlternativeUnitDetailViewModel { get; set; }
        public IEventAggregator EventAggregator { get; set; }
        public IGameModel GameModel { get; set; }

        [TestInitialize]
        public void Init()
        {
            EventAggregator = Substitute.For<IEventAggregator>();
            GameModel = Substitute.For<IGameModel>();
            AlternativeUnitDetailViewModel = new AlternativeUnitDetailViewModel(EventAggregator, GameModel);
        }

        [TestMethod]
        public void AlternativeUnitId_Is_Zero_Clears_CanCopy_CanDelete()
        {
            // Arrange
            var dirtyStatus = new CheckDirtyStatus();
            var altUnitId = 0;
            AlternativeUnitDetailViewModel.AlternativeUnitId = altUnitId;

            // Act
            AlternativeUnitDetailViewModel.Handle(dirtyStatus);

            // Assert
            Assert.IsFalse(AlternativeUnitDetailViewModel.CanCopy, "AlternativeUnitDetailViewModel.CanCopy");
            Assert.IsFalse(AlternativeUnitDetailViewModel.CanDelete, "AlternativeUnitDetailViewModel.CanDelete");
        }

        [TestMethod]
        public void AlternativeUnitId_Is_NonZero_Sets_CanCopy_CanDelete()
        {
            // Arrange
            var dirtyStatus = new CheckDirtyStatus();
            var altUnitId = 1;
            AlternativeUnitDetailViewModel.AlternativeUnitId = altUnitId;

            // Act
            AlternativeUnitDetailViewModel.Handle(dirtyStatus);

            // Assert
            Assert.IsTrue(AlternativeUnitDetailViewModel.CanCopy, "AlternativeUnitDetailViewModel.CanCopy");
            Assert.IsTrue(AlternativeUnitDetailViewModel.CanDelete, "AlternativeUnitDetailViewModel.CanDelete");
        }

        [TestMethod]
        public void AlternativeUnitName_Sets_CanUpdate()
        {
            // Arrange
            var dirtyStatus = new CheckDirtyStatus();
            var altUnitName = "Fred";
            AlternativeUnitDetailViewModel.AlternativeUnitName = altUnitName;

            // Act
            AlternativeUnitDetailViewModel.Handle(dirtyStatus);

            // Assert
            Assert.IsTrue(AlternativeUnitDetailViewModel.CanUpdate, "AlternativeUnitDetailViewModel.CanUpdate");
        }
    }
}

using System;
using Caliburn.Micro;
using GameEditor.Wcf.Harness.Wpf.EventAggregators;
using GameEditor.Wcf.Harness.Wpf.Models;
using GameEditor.Wcf.Harness.Wpf.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameEditor.WcfHarness.Wpf.UnitTest
{
    [TestClass]
    public class AllyDetailUnitTest : UnitTestBase
    {
        public AllyDetailViewModel AllyDetailViewModel { get; set; }

        public override void Init(IEventAggregator eventAggregator, IGameModel gameModel)
        {
            AllyDetailViewModel = new AllyDetailViewModel(eventAggregator, gameModel);
        }

        [TestMethod]
        public void Handle_Sets_AllyList_To_Disabled()
        {
            // Arrange
            var dirtyStatus = new CheckDirtyStatus();
            AllyDetailViewModel.AllyListControl.CanTextBox = true;

            // Act
            AllyDetailViewModel.Handle(dirtyStatus);

            // Assert
            Assert.IsFalse(AllyDetailViewModel.AllyListControl.CanTextBox);
        }
    }
}

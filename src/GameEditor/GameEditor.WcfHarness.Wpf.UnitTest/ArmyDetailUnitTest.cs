using Caliburn.Micro;
using GameEditor.Wcf.Harness.Wpf.EventAggregators;
using GameEditor.Wcf.Harness.Wpf.Models;
using GameEditor.Wcf.Harness.Wpf.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameEditor.WcfHarness.Wpf.UnitTest
{
    [TestClass]
    public class ArmyDetailUnitTest : UnitTestBase
    {
        public ArmyDetailViewModel ArmyDetailViewModel { get; set; }

        public override void Init(IEventAggregator eventAggregator, IGameModel gameModel)
        {
            ArmyDetailViewModel=new ArmyDetailViewModel(eventAggregator, gameModel);
        }

        [TestMethod]
        public void Handle_Sets_AlternativeUnitIdControl_To_Disabled()
        {
            // Arrange
            var dirtyStatus = new CheckDirtyStatus();
            ArmyDetailViewModel.ArmyIdControl.CanTextBox = true;

            // Act
            ArmyDetailViewModel.Handle(dirtyStatus);

            // Assert
            Assert.IsFalse(ArmyDetailViewModel.ArmyIdControl.CanTextBox);
        }
    }
}

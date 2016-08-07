using Caliburn.Micro;
using GameEditor.Wcf.Harness.Wpf.EventAggregators;
using GameEditor.Wcf.Harness.Wpf.Models;
using GameEditor.Wcf.Harness.Wpf.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace GameEditor.WcfHarness.Wpf.UnitTest
{
    [TestClass]
    public class ArmyUnitDetailUnitTest : UnitTestBase
    {
        public ArmyUnitDetailViewModel ArmyUnitDetailViewModel { get; set; }
        public IAlternativeUnitViewModel AlternativeUnitViewModel { get; set; }

        public override void Init(IEventAggregator eventAggregator, IGameModel gameModel)
        {
            AlternativeUnitViewModel = Substitute.For<IAlternativeUnitViewModel>();
            ArmyUnitDetailViewModel = new ArmyUnitDetailViewModel(eventAggregator, gameModel, AlternativeUnitViewModel);
        }

        [TestMethod]
        public void Handle_Sets_AlternativeUnitIdControl_To_Disabled()
        {
            // Arrange
            var dirtyStatus = new CheckDirtyStatus();
            ArmyUnitDetailViewModel.IdControl.CanTextBox = true;

            // Act
            ArmyUnitDetailViewModel.Handle(dirtyStatus);

            // Assert
            Assert.IsFalse(ArmyUnitDetailViewModel.IdControl.CanTextBox);
        }
    }
}

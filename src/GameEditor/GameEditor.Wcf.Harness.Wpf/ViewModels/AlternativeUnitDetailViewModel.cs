using Caliburn.Micro;
using GameEditor.Wcf.Harness.Wpf.Models;
using GameEditor.Wcf.Harness.Wpf.ViewModels.Base;
using GameEditor.Wcf.Harness.Wpf.Views.Interfaces;

namespace GameEditor.Wcf.Harness.Wpf.ViewModels
{
    public class AlternativeUnitDetailViewModel : DetailViewModel, IAlternativeScreenTabItem
    {
        public AlternativeUnitDetailViewModel(IEventAggregator eventAggregator, IGameModel gameModel) : base(eventAggregator, gameModel)
        {
            DisplayName = "Alt Detail";
        }

        public void ShowList() { }
    }
}
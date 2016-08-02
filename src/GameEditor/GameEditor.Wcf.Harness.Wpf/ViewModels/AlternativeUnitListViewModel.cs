using Caliburn.Micro;
using GameEditor.Wcf.Harness.Wpf.Models;
using GameEditor.Wcf.Harness.Wpf.ViewModels.Base;
using GameEditor.Wcf.Harness.Wpf.Views.Interfaces;

namespace GameEditor.Wcf.Harness.Wpf.ViewModels
{
    public class AlternativeUnitListViewModel : ListViewModel, IAlternativeScreenTabItem
    {
        public AlternativeUnitListViewModel(IEventAggregator eventAggregator, IGameModel gameModel) 
            : base(eventAggregator, gameModel)
        {
            DisplayName = "Alt List";
        }

        public override void PopulateList()
        {
            base.PopulateList();
        }

        public void Add() { }
    }
}
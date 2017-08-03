using Caliburn.Micro;
using GameEditor.Wcf.Harness.Wpf.Views.Interfaces;

namespace GameEditor.Wcf.Harness.Wpf.ViewModels
{
    public class AlternativeUnitViewModel : Conductor<IAlternativeScreenTabItem>.Collection.OneActive, IAlternativeUnitViewModel
    {
        public AlternativeUnitViewModel(IAlternativeUnitListViewModel listViewModel, IAlternativeUnitDetailViewModel detailViewModel)
        {
            Items.Add(listViewModel);
            Items.Add(detailViewModel);
        }
    }
}
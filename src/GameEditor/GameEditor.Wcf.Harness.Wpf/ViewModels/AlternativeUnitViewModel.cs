using Caliburn.Micro;
using GameEditor.Wcf.Harness.Wpf.Views.Interfaces;

namespace GameEditor.Wcf.Harness.Wpf.ViewModels
{
    public class AlternativeUnitViewModel : Conductor<IAlternativeScreenTabItem>.Collection.OneActive
    {
        public AlternativeUnitViewModel(AlternativeUnitListViewModel listViewModel, AlternativeUnitDetailViewModel detailViewModel)
        {
            Items.Add(listViewModel);
            Items.Add(detailViewModel);
        }
    }
}
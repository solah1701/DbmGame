using GameEditor.Wcf.Harness.Mvc;
using GameEditor.Wcf.Harness.Views;

namespace GameEditor.Wcf.Harness.Presenters
{
    public interface IAlternativeUnitDetailPresenter : IController<IAlternativeUnitDetailView>
    {
        void DeleteAlternativeUnitDetail();
        void UpdateAlternativeUnitDetail();
        void ShowList();
    }
}
using Caliburn.Micro;
using GameEditor.Wcf.Harness.Wpf.Models;
using GameEditor.Wcf.Harness.Wpf.ViewModels.Base;
using GameEditor.Wcf.Harness.Wpf.Views.Interfaces;
using GameEditor.Wcf.Harness.Wpf.WarGameServiceReference;

namespace GameEditor.Wcf.Harness.Wpf.ViewModels
{
    public sealed class AlternativeUnitListViewModel : ListViewModel, IAlternativeUnitListViewModel
    {
        private AlternativeUnitDefinition _selected;
        public BindableCollection<AlternativeUnitDefinition> AlternativeUnitDefinitions { get; }

        public AlternativeUnitDefinition SelectedAlternativeUnitDefinition
        {
            get { return _selected; }
            set
            {
                if (_selected == value) return;
                _selected = value; NotifyOfPropertyChange(() => SelectedAlternativeUnitDefinition);
                if (!IsUpdating && _selected != null) Select(_selected.Id);
            }
        }

        public AlternativeUnitListViewModel(IEventAggregator eventAggregator, IGameModel gameModel)
            : base(eventAggregator, gameModel)
        {
            DisplayName = "Alt List";
            AlternativeUnitDefinitions = new BindableCollection<AlternativeUnitDefinition>();
        }

        public override void PopulateList()
        {
#if !DESIGNMODE
            var items = GameModel.GetAlternativeUnitDefinitions();
            if (items == null) return;
            AlternativeUnitDefinitions.Clear();
            AlternativeUnitDefinitions.AddRange(items);
#endif
        }

        public override void Select(int id)
        {
            GameModel.CurrentAlternativeUnitDefinitionId = id;
            base.Select(id);
        }

        public override void Add()
        {
            base.Add();
        }
    }
}
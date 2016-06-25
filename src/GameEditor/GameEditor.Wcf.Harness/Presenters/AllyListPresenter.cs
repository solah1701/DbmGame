﻿//#define DESIGNMODE

using GameEditor.Wcf.Harness.EventAggregators;
using GameEditor.Wcf.Harness.Extensions;
using GameEditor.Wcf.Harness.Helpers;
using GameEditor.Wcf.Harness.Models;
using GameEditor.Wcf.Harness.Mvc;
using GameEditor.Wcf.Harness.Views;
using GameEditor.Wcf.Harness.WarGameServiceReference;

namespace GameEditor.Wcf.Harness.Presenters
{
    public class AllyListPresenter : Controller<IAllyListView>, IAllyListPresenter, IHandle<UpdateView>
    {
        private readonly IGameModel _model;
        private readonly IEventAggregator _event;

        public AllyListPresenter(IEventAggregator eventAggregator, IGameModel model)
        {
            _model = model;
            _event = eventAggregator;
            _event.Subscribe(this);
        }

        public void PopulateList()
        {
#if !DESIGNMODE
            var items = _model.GetArmyDefinitions();
            View.ArmyDefinitions = items;
#endif
        }

        public void SelectArmy(int armyId)
        {
            // Navigate to Detail page
            _model.CurrentArmyDefinitionId = armyId;
            _model.CurrentArmyUnitDefinitionId = 0;
            _event.PublishOnCurrentThread(new UpdateView());
        }

        public void UpdateArmy()
        {
            var ally = new AlliedArmyDefinition
            {
                AllyName = View.AllyName,
                MinYear = View.MinYear,
                MaxYear = View.MaxYear
            };
            _model.AddAllyDefinition(ally);
            _event.PublishOnCurrentThread(new UpdateView());
        }

        public void Handle(UpdateView message)
        {
            PopulateList();
        }
    }
}
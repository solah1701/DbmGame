﻿//#define DESIGNMODE

using System.Windows.Forms;
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

        protected override void InitialiseView()
        {
            base.InitialiseView();
            PopulateList();
        }

        public override void ViewChanged()
        {
            View.CanUpdate = View.AllyName != string.Empty && View.MinYear < View.MaxYear;
            View.CanDelete = _model.CurrentAllyDefinitionId != 0;
        }

        public void PopulateList()
        {
#if !DESIGNMODE
            var items = _model.GetFilteredAlliedArmyDefinitions(View.MinYear, View.MaxYear);
            if (items == null) return;
            View.AlliedArmyDefinitions = items.ConvertToStringArray();
#endif
        }

        private void ClearView()
        {
            View.AllyName = string.Empty;
            View.Book = 0;
            View.List = 0;
            View.MinYear = 0;
            View.MaxYear = 0;
        }

        public void SelectArmy()
        {
            // Navigate to Detail page
            var armyName = View.SelectedAlly;
            var army = _model.GetArmyDefinition(armyName);
            if (army == null) return;
            _model.CurrentAllyArmyDefinitionId = army.Id;
            View.Book = army.ArmyBook;
            View.List = army.ArmyList;
            ViewChanged();
            //_event.PublishOnCurrentThread(new UpdateView());
        }

        public void SelectAlly(int allyId)
        {
            var ally = _model.GetAlliedArmyDefinition(allyId);
            if (ally == null) return;
            _model.CurrentAllyDefinitionId = allyId;
            _model.CurrentAllyArmyDefinitionId = ally.ArmyId;
            View.AllyName = ally.AllyName;
            View.Book = ally.ArmyBook;
            View.List = ally.ArmyList;
            View.MinYear = ally.MinYear;
            View.MaxYear = ally.MaxYear;
            var army = _model.GetArmyDefinition(ally.ArmyId);
            if (army == null) return;
            View.SelectedAlly = army.ArmyName;
            View.Book = army.ArmyBook;
            View.List = army.ArmyList;
            ViewChanged();
        }

        public void UpdateArmy()
        {
            var ally = new AlliedArmyDefinition
            {
                Id = _model.CurrentAllyDefinitionId,
                AllyName = View.AllyName,
                ArmyBook = View.Book,
                ArmyList = View.List,
                MinYear = View.MinYear,
                MaxYear = View.MaxYear,
                ArmyId = _model.CurrentAllyArmyDefinitionId
            };
            _model.AddAllyDefinition(ally);
            _event.PublishOnCurrentThread(new UpdateView());
        }

        public void DeleteArmy()
        {
            _model.DeleteAllyDefinition(_model.CurrentAllyDefinitionId);
            ClearView();
            _event.PublishOnCurrentThread(new UpdateView());
        }

        public void Handle(UpdateView message)
        {
            if (_model.CurrentAllyDefinitionId == 0) ClearView();
            else
            {
                //PopulateList();
                SelectAlly(_model.CurrentAllyDefinitionId);
            }
            ViewChanged();
        }
    }
}
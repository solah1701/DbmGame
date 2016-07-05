using System;
using GameEditor.Wcf.Harness.EventAggregators;
using GameEditor.Wcf.Harness.Extensions;
using GameEditor.Wcf.Harness.Helpers;
using GameEditor.Wcf.Harness.Models;
using GameEditor.Wcf.Harness.Mvc;
using GameEditor.Wcf.Harness.Views;
using GameEditor.Wcf.Harness.WarGameServiceReference;

namespace GameEditor.Wcf.Harness.Presenters
{
    public class ArmyUnitDetailPresenter : Controller<IArmyUnitDetailView>, IArmyUnitDetailPresenter, IHandle<UpdateView>, IHandle<ShowAlternativeUnit>
    {
        private readonly IGameModel _model;
        private readonly IEventAggregator _event;

        public ArmyUnitDetailPresenter(IEventAggregator eventAggregator, IGameModel model)
        {
            _model = model;
            _event = eventAggregator;
            _event.Subscribe(this);
        }

        protected override void InitialiseView()
        {
            base.InitialiseView();
            View.DisciplineData = Enum.GetValues(typeof(DisciplineTypeEnum));
            View.UnitData = Enum.GetValues(typeof(UnitTypeEnum));
            View.DispositionData = Enum.GetValues(typeof(DispositionTypeEnum));
            View.GradeData = Enum.GetValues(typeof(GradeTypeEnum));
            ViewChanged();
        }

        public override void ViewChanged()
        {
            View.CanUpdate = View.ArmyUnitName != string.Empty && View.MaxCount != 0;
            View.CanCopy = View.ArmyUnitDefinitionId != 0;
            View.CanAddAlternative = View.ArmyUnitDefinitionId != 0;
            View.CanDelete = View.ArmyUnitDefinitionId != 0;
        }

        public void CopyArmyUnitDetail()
        {
            View.ArmyUnitDefinitionId = 0;
            ViewChanged();
        }

        private void ClearArmyUnitDetail()
        {
            View.ArmyUnitDefinitionId = 0;
            View.ArmyUnitName = string.Empty;
            View.Cost = 0;
            View.MinCount = 0;
            View.MaxCount = 0;
            View.MinYear = 0;
            View.MaxYear = 0;
            View.IsAlly = false;
            View.IsGeneral = false;
            View.IsChariot = false;
            View.IsDoubleElement = false;
            View.IsMountedInfantry = false;
            View.DisciplineType = 0;
            View.UnitType = 0;
            View.DispositionType = 0;
            View.GradeType = 0;
        }

        public void UpdateArmyUnitDetail()
        {
            var definition = new ArmyUnitDefinition
            {
                Id = View.ArmyUnitDefinitionId,
                UnitName = View.ArmyUnitName,
                Cost = View.Cost,
                MinCount = View.MinCount,
                MaxCount = View.MaxCount,
                MinYear = View.MinYear,
                MaxYear = View.MaxYear,
                IsAlly = View.IsAlly,
                IsGeneral = View.IsGeneral,
                IsChariot = View.IsChariot,
                IsDoubleElement = View.IsDoubleElement,
                IsMountedInfantry = View.IsMountedInfantry,
                DisciplineType = View.DisciplineType,
                UnitType = View.UnitType,
                DispositionType = View.DispositionType,
                GradeType = View.GradeType
            };
            View.ArmyUnitDefinitionId = _model.AddArmyUnitDefinition(definition);
            _event.PublishOnCurrentThread(new UpdateView());
        }

        public void DeleteArmyUnitDetail()
        {
            _model.DeleteArmyUnitDefinition(View.ArmyUnitDefinitionId);
            ClearArmyUnitDetail();
            _event.PublishOnCurrentThread(new UpdateView());
        }

        private void SelectArmyUnitDetail(int id)
        {
            var item = _model.GetArmyUnitDefinition(id);
            if (item == null) return;
            View.ArmyUnitDefinitionId = item.Id;
            View.ArmyUnitName = item.UnitName;
            View.Cost = item.Cost;
            View.MinCount = item.MinCount;
            View.MaxCount = item.MaxCount;
            View.MinYear = item.MinYear;
            View.MaxYear = item.MaxYear;
            View.IsAlly = item.IsAlly;
            View.IsGeneral = item.IsGeneral;
            View.IsChariot = item.IsChariot;
            View.IsDoubleElement = item.IsDoubleElement;
            View.IsMountedInfantry = item.IsMountedInfantry;
            View.DisciplineType = item.DisciplineType;
            View.UnitType = item.UnitType;
            View.DispositionType = item.DispositionType;
            View.GradeType = item.GradeType;
        }

        public void Handle(UpdateView message)
        {
            if (_model.CurrentArmyUnitDefinitionId == 0) ClearArmyUnitDetail();
            else SelectArmyUnitDetail(_model.CurrentArmyUnitDefinitionId);
            ViewChanged();
        }

        public void Handle(ShowAlternativeUnit message)
        {
            View.ShowAlternativeList = message.ShowList;
        }
    }
}
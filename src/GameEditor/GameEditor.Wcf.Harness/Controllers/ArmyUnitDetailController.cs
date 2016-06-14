﻿using GameEditor.Wcf.Harness.EventAggregators;
using GameEditor.Wcf.Harness.Extensions;
using GameEditor.Wcf.Harness.Helpers;
using GameEditor.Wcf.Harness.Models;
using GameEditor.Wcf.Harness.Mvc;
using GameEditor.Wcf.Harness.Views;
using GameEditor.Wcf.Harness.WarGameServiceReference;

namespace GameEditor.Wcf.Harness.Controllers
{
    public class ArmyUnitDetailController : Controller<IArmyUnitDetailView>, IArmyUnitDetailController, IHandle<UpdateView>
    {
        private readonly IGameModel _model;
        private readonly IEventAggregator _event;

        public ArmyUnitDetailController(IEventAggregator eventAggregator, IGameModel model)
        {
            _model = model;
            _event = eventAggregator;
            _event.Subscribe(this);
        }

        public void ClearArmyUnitDetail()
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
                MinCount=View.MinCount,
                MaxCount=View.MaxCount,
                MinYear=View.MinYear,
                MaxYear=View.MaxYear,
                IsAlly = View.IsAlly,
                IsGeneral = View.IsGeneral,
                IsChariot = View.IsChariot,
                IsDoubleElement=View.IsDoubleElement,
                IsMountedInfantry=View.IsMountedInfantry,
                DisciplineType=View.DisciplineType,
                UnitType=View.UnitType,
                DispositionType=View.DispositionType,
                GradeType = View.GradeType
            };
            View.ArmyUnitDefinitionId = _model.AddArmyUnitDefinitino(definition);
            _event.PublishOnCurrentThread(new UpdateView());
        }

        public void DeleteArmyUnitDetail()
        {
            _model.DeleteArmyDefinition(View.ArmyUnitDefinitionId);
            ClearArmyUnitDetail();
            _event.PublishOnCurrentThread(new UpdateView());
        }

        public void SelectArmyUnitDetail(int id)
        {
            var item = _model.GetArmyUnitDefinition(id);
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
        }
    }
}
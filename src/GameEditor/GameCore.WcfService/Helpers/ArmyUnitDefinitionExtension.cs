using System.Collections.Generic;
using System.Linq;
using GameCore.WcfService.DebellisMultitudinis;

namespace GameCore.WcfService.Helpers
{
    public static class ArmyUnitDefinitionExtension
    {
        public static ArmyUnitDefinitions GetArmyUnitDefinitions(this List<ArmyListUnitDefinition> definitions)
        {
            var result = new ArmyUnitDefinitions();
            result.AddRange(definitions.Select(armyListDefinition => armyListDefinition.GetArmyUnitDefinition()));
            return result;
        }

        public static ArmyUnitDefinition GetArmyUnitDefinition(this ArmyListUnitDefinition definition)
        {
            return new ArmyUnitDefinition
            {
                Id = definition.ArmyUnitDefinitionId,
                UnitName = definition.Name,
                Cost = definition.Cost,
                IsGeneral = definition.IsGeneral,
                IsChariot = definition.IsChariot,
                IsMountedInfantry = definition.IsMountedInfantry,
                IsAlly = definition.IsAlly,
                IsDoubleElement = definition.IsDoubleElement,
                MinCount = definition.MinCount,
                MaxCount = definition.MaxCount,
                MinYear = definition.MinYear,
                MaxYear = definition.MaxYear,
                UnitType = definition.UnitType,
                GradeType = definition.GradeType,
                DispositionType = definition.DispositionType,
                DisciplineType = definition.DisciplineType
            };
        }

        public static ArmyListUnitDefinition GetArmyUnitDefinition(this ArmyUnitDefinition definition)
        {
            return new ArmyListUnitDefinition
            {
                ArmyUnitDefinitionId = definition.Id,
                Name = definition.UnitName,
                Cost = definition.Cost,
                IsGeneral = definition.IsGeneral,
                IsChariot = definition.IsChariot,
                IsMountedInfantry = definition.IsMountedInfantry,
                IsAlly = definition.IsAlly,
                IsDoubleElement = definition.IsDoubleElement,
                MinCount = definition.MinCount,
                MaxCount = definition.MaxCount,
                MinYear = definition.MinYear,
                MaxYear = definition.MaxYear,
                UnitType = definition.UnitType,
                GradeType = definition.GradeType,
                DispositionType = definition.DispositionType,
                DisciplineType = definition.DisciplineType
            };
        }

        public static void SetArmyListUnitDefinition(this ArmyListUnitDefinition definition, ArmyUnitDefinition item)
        {
            definition.ArmyUnitDefinitionId = item.Id;
            definition.Name = item.UnitName;
            definition.Cost = item.Cost;
            definition.IsGeneral = item.IsGeneral;
            definition.IsChariot = item.IsChariot;
            definition.IsMountedInfantry = item.IsMountedInfantry;
            definition.IsAlly = item.IsAlly;
            definition.IsDoubleElement = item.IsDoubleElement;
            definition.MinCount = item.MinCount;
            definition.MaxCount = item.MaxCount;
            definition.MinYear = item.MinYear;
            definition.MaxYear = item.MaxYear;
            definition.UnitType = item.UnitType;
            definition.GradeType = item.GradeType;
            definition.DispositionType = item.DispositionType;
            definition.DisciplineType = item.DisciplineType;
        }

        public static ArmyListUnitDefinition UpdateArmyUnitDefinition(this ArmyUnitDefinition definition, ArmyListUnitDefinition original)
        {
            original.ArmyUnitDefinitionId = definition.Id;
            original.Name = definition.UnitName;
            original.Cost = definition.Cost;
            original.MinCount = definition.MinCount;
            original.MaxCount = definition.MaxCount;
            original.MinYear = definition.MinYear;
            original.MaxYear = definition.MaxYear;
            original.IsGeneral = definition.IsGeneral;
            original.IsAlly = definition.IsAlly;
            original.IsChariot = definition.IsChariot;
            original.IsDoubleElement = definition.IsDoubleElement;
            original.IsMountedInfantry = definition.IsMountedInfantry;
            original.DisciplineType = definition.DisciplineType;
            original.DispositionType = definition.DispositionType;
            original.UnitType = definition.UnitType;
            original.GradeType = definition.GradeType;

            return original;
        }
    }
}
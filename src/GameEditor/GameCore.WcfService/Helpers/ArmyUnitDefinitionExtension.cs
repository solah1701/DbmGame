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
                MaxYear = definition.MaxYear
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
                MaxYear = definition.MaxYear
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
        }
    }
}
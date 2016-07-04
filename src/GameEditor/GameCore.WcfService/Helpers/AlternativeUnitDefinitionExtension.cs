using System.Collections.Generic;
using System.Linq;
using GameCore.WcfService.DebellisMultitudinis;

namespace GameCore.WcfService.Helpers
{
    public static class AlternativeDefinitionExtension
    {
        public static AlternativeUnitDefinitions GetAlternativeUnitDefinitions(this List<AlternativeListUnitDefinition> definitions)
        {
            var result = new AlternativeUnitDefinitions();
            result.AddRange(definitions.Select<AlternativeListUnitDefinition, AlternativeUnitDefinition>(armyListDefinition => armyListDefinition.GetAlternativeUnitDefinition()));
            return result;
        }

        public static AlternativeUnitDefinition GetAlternativeUnitDefinition(this AlternativeListUnitDefinition definition)
        {
            return new AlternativeUnitDefinition
            {
                Id = definition.AlternativeUnitDefinitionId,
                Name = definition.Name,
                UnitId = definition.UnitId,
                AlternativeUnitId = definition.AlternativeUnitId,
                Upgrade = definition.Upgrade,
                MinPercent = definition.MinPercent,
                MaxPercent = definition.MinPercent
            };
        }

        public static AlternativeListUnitDefinition GetAlternativeUnitDefinition(this AlternativeUnitDefinition definition)
        {
            return new AlternativeListUnitDefinition
            {
                AlternativeUnitDefinitionId = definition.Id,
                Name = definition.Name,
                UnitId = definition.UnitId,
                AlternativeUnitId = definition.AlternativeUnitId,
                Upgrade = definition.Upgrade,
                MinPercent = definition.MinPercent,
                MaxPercent = definition.MinPercent
            };
        }

        public static void SetAlliedArmyListDefinition(this AlternativeListUnitDefinition definition, AlternativeUnitDefinition item)
        {
            definition.AlternativeUnitDefinitionId = item.Id;
            definition.Name = item.Name;
            definition.UnitId = item.UnitId;
            definition.AlternativeUnitId = item.AlternativeUnitId;
            definition.Upgrade = item.Upgrade;
            definition.MinPercent = item.MinPercent;
            definition.MaxPercent = item.MinPercent;
        }

        public static AlternativeListUnitDefinition UpdateAlternativeUnitDefinition(this AlternativeUnitDefinition definition, AlternativeListUnitDefinition original)
        {
            original.AlternativeUnitDefinitionId = definition.Id;
            original.Name = definition.Name;
            original.UnitId = definition.UnitId;
            original.AlternativeUnitId = definition.AlternativeUnitId;
            original.Upgrade = definition.Upgrade;
            original.MinPercent = definition.MinPercent;
            original.MaxPercent = definition.MinPercent;

            return original;
        }
    }
}
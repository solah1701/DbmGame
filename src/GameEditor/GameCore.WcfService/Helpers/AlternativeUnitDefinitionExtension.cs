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
            result.AddRange(definitions.Select(armyListDefinition => armyListDefinition.GetAlternativeUnitDefinition()));
            return result;
        }

        public static AlternativeUnitDefinition GetAlternativeUnitDefinition(this AlternativeListUnitDefinition definition)
        {
            return new AlternativeUnitDefinition
            {
                Id = definition.AlternativeUnitDefinitionId,
                Name = definition.Name,
                AlternativeUnitId = definition.AlternativeUnitId,
                Upgrade = definition.Upgrade,
                MinValue = definition.MinValue,
                MaxValue = definition.MaxValue,
                Percent = definition.Percent
            };
        }

        public static AlternativeListUnitDefinition GetAlternativeUnitDefinition(this AlternativeUnitDefinition definition)
        {
            return new AlternativeListUnitDefinition
            {
                AlternativeUnitDefinitionId = definition.Id,
                Name = definition.Name,
                AlternativeUnitId = definition.AlternativeUnitId,
                Upgrade = definition.Upgrade,
                MinValue = definition.MinValue,
                MaxValue = definition.MaxValue,
                Percent = definition.Percent
            };
        }

        public static void SetAlternativeUnitListDefinition(this AlternativeListUnitDefinition definition, AlternativeUnitDefinition item)
        {
            definition.AlternativeUnitDefinitionId = item.Id;
            definition.Name = item.Name;
            definition.AlternativeUnitId = item.AlternativeUnitId;
            definition.Upgrade = item.Upgrade;
            definition.MinValue = item.MinValue;
            definition.MaxValue = item.MaxValue;
            definition.Percent = item.Percent;
        }

        public static AlternativeListUnitDefinition UpdateAlternativeUnitDefinition(this AlternativeUnitDefinition definition, AlternativeListUnitDefinition original)
        {
            original.AlternativeUnitDefinitionId = definition.Id;
            original.Name = definition.Name;
            original.AlternativeUnitId = definition.AlternativeUnitId;
            original.Upgrade = definition.Upgrade;
            original.MinValue = definition.MinValue;
            original.MaxValue = definition.MaxValue;
            original.Percent = definition.Percent;

            return original;
        }
    }
}
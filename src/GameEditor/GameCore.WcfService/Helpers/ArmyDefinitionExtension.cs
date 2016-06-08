using System;
using System.Collections.Generic;
using System.Linq;
using GameCore.WcfService.DebellisMultitudinis;

namespace GameCore.WcfService.Helpers
{
    public static class ArmyDefinitionExtension
    {
        public static ArmyDefinitions GetArmyDefinitions(this List<ArmyListDefinition> definitions)
        {
            var result = new ArmyDefinitions();
            result.AddRange(definitions.Select(armyListDefinition => armyListDefinition.GetArmyDefinition()));
            return result;
        }

        public static ArmyDefinition GetArmyDefinition(this ArmyListDefinition definition)
        {
            return new ArmyDefinition
            {
                Id = definition.ArmyListDefinitionId.ToString(),
                ArmyName = definition.Name,
                ArmyBook = definition.Book.ToString(),
                ArmyList = definition.List.ToString(),
                MinYear = definition.MinYear,
                MaxYear = definition.MaxYear
            };
        }

        public static ArmyListDefinition GetArmyListDefinition(this ArmyDefinition definition)
        {
            return new ArmyListDefinition
            {
                ArmyListDefinitionId = definition.Id == null ? 0 : int.Parse(definition.Id),
                Name = definition.ArmyName,
                Book = int.Parse(definition.ArmyBook),
                List = int.Parse(definition.ArmyList),
                MinYear = definition.MinYear,
                MaxYear = definition.MaxYear
            };
        }

        public static void SetArmyListDefinition(this ArmyListDefinition definition, ArmyDefinition item)
        {
            definition.ArmyListDefinitionId = int.Parse(item.Id);
            definition.Name = item.ArmyName;
            definition.Book = int.Parse(item.ArmyBook);
            definition.List = int.Parse(item.ArmyList);
            definition.MinYear = item.MinYear;
            definition.MaxYear = item.MaxYear;
        }
    }
}
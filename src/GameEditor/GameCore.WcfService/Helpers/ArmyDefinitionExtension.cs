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
                Id = definition.ArmyListDefinitionId,
                ArmyName = definition.Name,
                ArmyBook = definition.Book,
                ArmyList = definition.List,
                MinYear = definition.MinYear,
                MaxYear = definition.MaxYear,
                Notes = definition.Notes
            };
        }

        public static ArmyListDefinition GetArmyListDefinition(this ArmyDefinition definition)
        {
            return new ArmyListDefinition
            {
                ArmyListDefinitionId = definition.Id,
                Name = definition.ArmyName,
                Book = definition.ArmyBook,
                List = definition.ArmyList,
                MinYear = definition.MinYear,
                MaxYear = definition.MaxYear,
                Notes = definition.Notes
            };
        }

        public static void SetArmyListDefinition(this ArmyListDefinition definition, ArmyDefinition item)
        {
            definition.ArmyListDefinitionId = item.Id;
            definition.Name = item.ArmyName;
            definition.Book = item.ArmyBook;
            definition.List = item.ArmyList;
            definition.MinYear = item.MinYear;
            definition.MaxYear = item.MaxYear;
            definition.Notes = item.Notes;
        }
    }
}
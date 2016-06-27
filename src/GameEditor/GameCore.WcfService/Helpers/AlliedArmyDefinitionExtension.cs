using System.Collections.Generic;
using System.Linq;
using GameCore.WcfService.DebellisMultitudinis;

namespace GameCore.WcfService.Helpers
{
    public static class AlliedArmyDefinitionExtension
    {
        public static AlliedArmyDefinitions GetAlliedArmyDefinitions(this List<AlliedArmyListDefinition> definitions)
        {
            var result = new AlliedArmyDefinitions();
            result.AddRange(definitions.Select(armyListDefinition => armyListDefinition.GetAlliedArmyDefinition()));
            return result;
        }

        public static AlliedArmyDefinition GetAlliedArmyDefinition(this AlliedArmyListDefinition definition)
        {
            return new AlliedArmyDefinition
            {
                Id = definition.AlliedArmyListDefinitionId,
                AllyName = definition.Name,
                ArmyBook = definition.Book,
                ArmyList = definition.List,
                MinYear = definition.MinYear,
                MaxYear = definition.MaxYear
            };
        }

        public static AlliedArmyListDefinition GetAlliedArmyDefinition(this AlliedArmyDefinition definition)
        {
            return new AlliedArmyListDefinition
            {
                AlliedArmyListDefinitionId = definition.Id,
                Name = definition.AllyName,
                Book = definition.ArmyBook,
                List = definition.ArmyList,
                MinYear = definition.MinYear,
                MaxYear = definition.MaxYear
            };
        }

        public static void SetAlliedArmyListDefinition(this AlliedArmyListDefinition definition, AlliedArmyDefinition item)
        {
            definition.AlliedArmyListDefinitionId = item.Id;
            definition.Name = item.AllyName;
            definition.Book = item.ArmyBook;
            definition.List = item.ArmyList;
            definition.MinYear = item.MinYear;
            definition.MaxYear = item.MaxYear;
        }

        public static AlliedArmyListDefinition UpdateAlliedArmyDefinition(this AlliedArmyDefinition definition, AlliedArmyListDefinition original)
        {
            original.AlliedArmyListDefinitionId = definition.Id;
            original.Name = definition.AllyName;
            original.Book = definition.ArmyBook;
            original.List = definition.ArmyList;
            original.MinYear = definition.MinYear;
            original.MaxYear = definition.MaxYear;

            return original;
        }
    }
}
using System.Linq;
using System.Windows.Forms;
using GameEditor.Wcf.Harness.WarGameServiceReference;

namespace GameEditor.Wcf.Harness.Extensions
{
    public static class ArmyDefinitionsExtension
    {
        public static ListViewItem[] ConvertToListViewItems(this ArmyDefinitions definitions)
        {
            return definitions.Select(armyDefinition => new[]
            {
                armyDefinition.Id.ToString(), armyDefinition.ArmyName, armyDefinition.ArmyBook.ToString(), armyDefinition.ArmyList.ToString()
            }).Select(subItem => new ListViewItem(subItem)).ToArray();
        }

        public static ListViewItem[] ConvertToListViewItems(this ArmyUnitDefinitions definitions)
        {
            return definitions.Select(armyDefinition => new[]
            {
                armyDefinition.Id.ToString(),
                armyDefinition.UnitName,
                armyDefinition.DisciplineType.ToString(),
                armyDefinition.DispositionType.ToString(),
                armyDefinition.UnitType.ToString(),
                armyDefinition.Cost.ToString(),
                armyDefinition.MinCount.ToString(),
                armyDefinition.MaxCount.ToString()
            }).Select(subItem => new ListViewItem(subItem)).ToArray();
        }
    }
}
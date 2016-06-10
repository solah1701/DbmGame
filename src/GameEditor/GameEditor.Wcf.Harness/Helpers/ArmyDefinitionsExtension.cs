using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GameEditor.Wcf.Harness.WarGameServiceReference;

namespace GameEditor.Wcf.Harness.Helpers
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
    }
}
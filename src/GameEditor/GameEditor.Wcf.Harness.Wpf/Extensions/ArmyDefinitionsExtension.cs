using System.Collections.Generic;
using System.Linq;
using GameEditor.Wcf.Harness.Wpf.WarGameServiceReference;

namespace GameEditor.Wcf.Harness.Wpf.Extensions
{
    public static class ArmyDefinitionsExtension
    {
        public static List<string> ConvertToStringList(this ArmyUnitDefinitions definitions, int excludeId)
        {
            return definitions?.Where(unit => unit.Id != excludeId).Select(unit => unit.UnitName).ToList() ?? new List<string>();
        }
    }
}
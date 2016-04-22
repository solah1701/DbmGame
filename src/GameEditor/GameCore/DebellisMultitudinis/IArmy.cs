using System.Collections.Generic;

namespace GameCore.DebellisMultitudinis
{
    public interface IArmy : INamedItem
    {
         List<IUnit> Units { get; set; }
    }
}
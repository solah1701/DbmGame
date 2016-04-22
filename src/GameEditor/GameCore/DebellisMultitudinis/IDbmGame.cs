using System.Collections.Generic;

namespace GameCore.DebellisMultitudinis
{
    public interface IDbmGame : INamedItem
    {
        List<IConstructableUnit> ConstructableUnits { get; set; }
    }
}
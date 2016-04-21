using System.Collections.Generic;

namespace GameCore
{
    public interface IBuilding
    {
        Dictionary<IGoods, int> ConstructionCost { get; set; }
        Dictionary<IMaintenance, int> MaintenanceCost { get; set; } 
    }
}
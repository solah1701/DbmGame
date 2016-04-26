using GameCore.DebellisMultitudinis.Enumerations;

namespace GameCore.DebellisMultitudinis
{
    public interface IDbmUnit
    {
        bool IsGeneral { get; set; }
        bool IsChariot { get; set; }
        bool IsMountedInfantry { get; set; }
        bool IsAlly { get; set; }
        bool IsShooting { get; set; }
        DisciplineTypeEnum DisciplineType { get; set; }
        UnitTypeEnum UnitType { get; set; }
        GradeTypeEnum GradeType { get; set; }
        DispositionTypeEnum DispositionType { get; }
        int GetAttackValue(IDbmUnit opposingDbmUnit);
    }
}
using GameCore.DebellisMultitudinis.Enumerations;

namespace GameCore.DebellisMultitudinis
{
    public interface IDbmUnit
    {
        UnitTypeEnum UnitType { get; set; }
        GradeTypeEnum GradeType { get; set; }
        DispositionTypeEnum DispositionType { get; }
    }
}
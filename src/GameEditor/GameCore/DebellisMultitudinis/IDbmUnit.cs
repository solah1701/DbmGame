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
        bool IsFortified { get; set; }
        bool IsElevated { get; set; }
        bool IsDoubleElement { get; set; }
        bool IsContactThisRound { get; set; }
        bool IsMobile { get; set; }
        bool IsUnladenNaval { get; set; }
        int EnemyOverlapCount { get; set; }
        int RearSupportCount { get; set; }
        int EnemySupportShootingCount { get; set; }
        IDbmUnit SupportingDbmUnit { get; set; }
        FortificationTypeEnum FortificationType { get; set; }
        TerrainGoingEnum TerrainGoing { get; set; }
        DisciplineTypeEnum DisciplineType { get; set; }
        UnitTypeEnum UnitType { get; set; }
        GradeTypeEnum GradeType { get; set; }
        DispositionTypeEnum DispositionType { get; }
        int GetAttackValue(IDbmUnit opposingDbmUnit);
        int GetRearSupportingFactor(IDbmUnit opposingDbmUnit);
        int GetTacticalFactor(IDbmUnit opposingDbmUnit);
        int GetGradingFactor(IDbmUnit opposingDbmUnit, int score, int opponentScore);
        CombatOutcomeEnum GetCombatOutcome(IDbmUnit opposingDbmUnit, int score, int opponentScore);
    }
}
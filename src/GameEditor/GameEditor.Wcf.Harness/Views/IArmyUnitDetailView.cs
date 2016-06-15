using System;
using GameEditor.Wcf.Harness.WarGameServiceReference;

namespace GameEditor.Wcf.Harness.Views
{
    public interface IArmyUnitDetailView
    {
        int ArmyUnitDefinitionId { get; set; }
        string ArmyUnitName { get; set; }
        decimal? Cost { get; set; }
        bool IsGeneral { get; set; }
        bool IsChariot { get; set; }
        bool IsMountedInfantry { get; set; }
        bool IsAlly { get; set; }
        bool IsDoubleElement { get; set; }
        int MinCount { get; set; }
        int MaxCount { get; set; }
        int MinYear { get; set; }
        int MaxYear { get; set; }
        DisciplineTypeEnum DisciplineType { get; set; }
        UnitTypeEnum UnitType { get; set; }
        GradeTypeEnum GradeType { get; set; }
        DispositionTypeEnum DispositionType { get; set; }
        Array DisciplineData { set; }
        Array UnitData { set; }
        Array GradeData { set; }
        Array DispositionData { set; }
    }
}
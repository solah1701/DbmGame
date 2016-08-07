using GameEditor.Wcf.Harness.Wpf.Views.Interfaces;
using GameEditor.Wcf.Harness.Wpf.WarGameServiceReference;

namespace GameEditor.Wcf.Harness.Wpf.ViewModels
{
    public interface IArmyUnitDetailViewModel : IDetailView
    {
        int ArmyUnitDefinitionId { get; set; }
        string ArmyUnitName { get; set; }
        decimal? Cost { get; set; }
        int MinCount { get; set; }
        int MaxCount { get; set; }
        int MinYear { get; set; }
        int MaxYear { get; set; }
        bool IsAlly { get; set; }
        bool IsGeneral { get; set; }
        bool IsChariot { get; set; }
        bool IsDoubleElement { get; set; }
        bool IsMountedInfantry { get; set; }
        DisciplineTypeEnum DisciplineType { get; set; }
        UnitTypeEnum UnitType { get; set; }
        DispositionTypeEnum DispositionType { get; set; }
        GradeTypeEnum GradeType { get; set; }
    }
}
using GameEditor.Wcf.Harness.Wpf.WarGameServiceReference;

namespace GameEditor.Wcf.Harness.Wpf.Views.Interfaces
{
    public interface IArmyUnitDetailView
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

        bool CanUpdate { get; set; }
        bool CanCopy { get; set; }
        bool CanDelete { get; set; }

        void Add();
        void Delete();
        void Update();
        void SelectDetail(int id);
        void ClearDetail();
    }
}
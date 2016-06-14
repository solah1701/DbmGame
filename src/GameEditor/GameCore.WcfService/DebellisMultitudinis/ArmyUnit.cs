using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GameCore.DebellisMultitudinis.Enumerations;
using GameCore.WcfService.DebellisMultitudinis.Enumerations;

namespace GameCore.WcfService.DebellisMultitudinis
{
    [Table("ArmyUnit")]
    public class ArmyUnit
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ArmyUnitId { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        public decimal? Cost { get; set; }
        public bool IsGeneral { get; set; }
        public bool IsChariot { get; set; }
        public bool IsMountedInfantry { get; set; }
        public bool IsMounted { get; set; }
        public bool IsAlly { get; set; }
        public bool IsShooting { get; set; }
        public bool IsFortified { get; set; }
        public bool IsElevated { get; set; }
        public bool IsDoubleElement { get; set; }
        public bool IsContactThisRound { get; set; }
        public bool IsMobile { get; set; }
        public bool IsUnladenNaval { get; set; }
        public int EnemyOverlapCount { get; set; }
        public int RearSupportCount { get; set; }
        public int EnemySupportShootingCount { get; set; }
        public int SupportingDbmUnitId { get; set; }
        public TerrainGoingEnum TerrainGoing { get; set; }
        public FortificationTypeEnum FortificationType { get; set; }
        public DisciplineTypeEnum DisciplineType { get; set; }
        public UnitTypeEnum UnitType { get; set; }
        public GradeTypeEnum GradeType { get; set; }
        public DispositionTypeEnum DispositionType { get; set; }

        public virtual ArmyCommand ArmyCommand { get; set; }
        public virtual ArmyCommandGroup ArmyCommandGroup { get; set; }
        public virtual ArmyUnit SupportingDbmUnit { get; set; }
    }
}
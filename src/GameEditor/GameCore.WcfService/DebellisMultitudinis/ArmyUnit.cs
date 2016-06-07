using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GameCore.DebellisMultitudinis.Enumerations;

namespace GameCore.WcfService.DebellisMultitudinis
{
    [Table("ArmyUnit")]
    public class ArmyUnit
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ArmyUnitId { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        public int Attack { get; set; }
        public int Defence { get; set; }
        public int Move { get; set; }
        public int Range { get; set; }
        public int Speed { get; set; }
        public int Stamina { get; set; }
        public int Level { get; set; }
        public int Morale { get; set; }
        public decimal? Cost { get; set; }
        public int Upkeep { get; set; }
        public int ConstructionTime { get; set; }
        public bool IsGeneral { get; set; }
        public bool IsChariot { get; set; }
        public bool IsMountedInfantry { get; set; }
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
        public int TerrainGoingId { get; set; }
        public int FortifiationTypeId { get; set; }
        public int DisicplineTypeId { get; set; }
        public int UnitTypeId { get; set; }
        public int GradeTypeId { get; set; }
        public int DispositionTypeId { get; set; }

        public virtual ArmyCommand ArmyCommand { get; set; }
        public virtual ArmyCommandGroup ArmyCommandGroup { get; set; }
        public virtual ArmyUnit SupportingDbmUnit { get; set; }
        public virtual TerrainGoingEnum TerrainGoing { get; set; }
        public virtual FortificationTypeEnum FortificationType { get; set; }
        public virtual DisciplineTypeEnum DisciplineType { get; set; }
        public virtual UnitTypeEnum UnitType { get; set; }
        public virtual GradeTypeEnum GradeType { get; set; }
        public virtual DispositionTypeEnum DispositionType { get; set; }
    }
}
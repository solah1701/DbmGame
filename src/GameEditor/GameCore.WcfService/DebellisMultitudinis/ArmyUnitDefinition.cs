using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GameCore.DebellisMultitudinis.Enumerations;

namespace GameCore.WcfService.DebellisMultitudinis
{
    [Table("ArmyUnitDefinition")]
    public class ArmyListUnitDefinition
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ArmyUnitDefinitionId { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        public decimal? Cost { get; set; }
        public bool IsGeneral { get; set; }
        public bool IsChariot { get; set; }
        public bool IsMountedInfantry { get; set; }
        public bool IsAlly { get; set; }
        public bool IsDoubleElement { get; set; }
        public int MinCount { get; set; }
        public int MaxCount { get; set; }
        public int MinYear { get; set; }
        public int MaxYear { get; set; }
        public DisciplineTypeEnum DisciplineType { get; set; }
        public UnitTypeEnum UnitType { get; set; }
        public GradeTypeEnum GradeType { get; set; }
        public DispositionTypeEnum DispositionType { get; set; }

        public virtual ArmyListDefinition ArmyListDefinition { get; set; }
    }
}
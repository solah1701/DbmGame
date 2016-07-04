using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameCore.WcfService.DebellisMultitudinis
{
    [Table("AlternativeUnitDefnition")]
    public class AlternativeListUnitDefinition
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int AlternativeUnitDefinitionId { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        public bool Upgrade { get; set; }
        public int UnitId { get; set; }
        public int AlternativeUnitId { get; set; }
        public int MinPercent { get; set; }
        public int MaxPercent { get; set; }

        //public virtual ArmyUnitDefinition ArmyUnitDefinition { get; set; }
    }
}
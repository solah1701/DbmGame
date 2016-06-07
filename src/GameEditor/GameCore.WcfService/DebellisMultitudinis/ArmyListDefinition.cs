using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameCore.WcfService.DebellisMultitudinis
{
    [Table("ArmyListDefinition")]
    public class ArmyListDefinition
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ArmyListDefinitionId { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        public int Book { get; set; }
        public int List { get; set; }
        public int MinYear { get; set; }
        public int MaxYear { get; set; }
        public string Notes { get; set; }
    }
}
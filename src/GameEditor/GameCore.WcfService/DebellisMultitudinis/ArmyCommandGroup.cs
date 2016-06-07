using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameCore.WcfService.DebellisMultitudinis
{
    [Table("ArmyCommandGroup")]
    public class ArmyCommandGroup
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int ArmyCommandGroupId { get; set; }
        [StringLength(255)]
        public string Name { get; set; }

        public virtual ArmyCommand ArmyCommand { get; set; }
        public virtual List<ArmyUnit> ArmyUnits { get; set; }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GameCore.Wcf.DebellisMultitudinis;

namespace GameCore.WcfService.DebellisMultitudinis
{
    [Table("ArmyCommand")]
    public class ArmyCommand
    {
         [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
         public int ArmyCommandId { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public int ArmyId { get; set; }

        public virtual Army Army { get; set; }
        public virtual List<ArmyCommandGroup> ArmyCommandGroups { get; set; } 
        public virtual List<ArmyUnit> ArmyUnits { get; set; } 
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameCore.Wcf.DebellisMultitudinis
{
    [Table("Army")]
    public class Army
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ArmyId { get; set; }
        [StringLength(255)]
        public string Name { get; set; }

        public int BattleId { get; set; }

        public virtual List<ArmyCommand> ArmyCommand { get; set; }
        public virtual Battle Battle { get; set; }
    }
}
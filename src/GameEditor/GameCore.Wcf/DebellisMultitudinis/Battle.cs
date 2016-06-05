using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameCore.Wcf.DebellisMultitudinis
{
    [Table("Battle")]
    public class Battle
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BattleId { get; set; }

        [StringLength(255)]
        public int Name { get; set; }
        public int DbmGameId { get; set; }

        public virtual DbmGame DbmGame { get; set; }
        public virtual List<GameCore.DebellisMultitudinis.Army> Armies { get; set; }
    }
}
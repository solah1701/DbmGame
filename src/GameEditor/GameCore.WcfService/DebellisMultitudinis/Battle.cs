using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GameCore.Wcf.DebellisMultitudinis;

namespace GameCore.WcfService.DebellisMultitudinis
{
    [Table("Battle")]
    public class Battle
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BattleId { get; set; }

        [StringLength(255)]
        public string Name { get; set; }
        public int DbmGameId { get; set; }

        public virtual DbmGame DbmGame { get; set; }
        public virtual List<Army> Armies { get; set; }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameCore.Wcf.DebellisMultitudinis
{
    [Table("DbmGame")]
    public class DbmGame
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DbmGameId { get; set; }
        [StringLength(255)]
        public string Name { get; set; }

        public virtual List<Battle> Battles { get; set; }
    }
}
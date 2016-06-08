using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameCore.WcfService.DebellisMultitudinis
{
    [Table("DbmGame")]
    public class DbmGame
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int DbmGameId { get; set; }
        [StringLength(255)]
        public string Name { get; set; }

        public virtual List<Battle> Battles { get; set; }
    }
}
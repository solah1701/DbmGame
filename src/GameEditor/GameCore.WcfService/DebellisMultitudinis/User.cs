using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameCore.WcfService.DebellisMultitudinis
{
    [Table("User")]
    public partial class User
    {
        [Key]
        public int UserId { get; set; }

        [StringLength(255)]
        public string Name { get; set; }
    }
}

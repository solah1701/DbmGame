using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameCore.WcfService.DebellisMultitudinis
{
    [Table("AlliedArmyListDefinition")]
    public class AlliedArmyListDefinition
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int AlliedArmyListDefinitionId { get; set; }
        public string Name { get; set; }
        public int Book { get; set; }
        public int List { get; set; }
        public int MinYear { get; set; }
        public int MaxYear { get; set; }

        public virtual ArmyListDefinition ArmyListDefinition { get; set; }
    }
}
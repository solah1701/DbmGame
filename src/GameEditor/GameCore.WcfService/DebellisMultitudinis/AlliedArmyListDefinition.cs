using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameCore.WcfService.DebellisMultitudinis
{
    [Table("AlliedArmyListDefinition")]
    public class AlliedArmyListDefinition
    {
        [Key]
        public int AlliedArmyListDefinitionId { get; set; }
        public string Name { get; set; }
        public int MinYear { get; set; }
        public int MaxYear { get; set; }

        public virtual List<ArmyListDefinition> ArmyListDefinitions { get; set; }
    }
}
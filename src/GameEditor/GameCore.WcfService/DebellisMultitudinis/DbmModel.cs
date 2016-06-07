using System.Data.Entity;

namespace GameCore.WcfService.DebellisMultitudinis
{
    public class DbmModel : DbContext, IDbmModel
    {
        public DbmModel(): base("DbmGame")
        {
            
        }

        public virtual DbSet<Army> Armies { get; set; } 
        public virtual DbSet<ArmyCommand> ArmyCommands { get; set; } 
        public virtual DbSet<ArmyCommandGroup> ArmyCommandGroups { get; set; } 
        public virtual DbSet<ArmyUnit> ArmyUnits { get; set; } 
        public virtual DbSet<Battle> Battles { get; set; }
        public virtual DbSet<DbmGame> DbmGames { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public void SaveDbChanges()
        {
            SaveChanges();
        }

        public virtual DbSet<ArmyListDefinition> ArmyListDefinitions { get; set; }
        public virtual DbSet<ArmyListUnitDefinition> ArmyUnitDefinitions { get; set; } 
    }
}
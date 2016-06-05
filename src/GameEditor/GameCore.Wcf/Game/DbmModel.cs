using System.Data.Entity;

namespace GameCore.Wcf.DebellisMultitudinis
{
    public class DbmModel : DbContext
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
    }
}
using System.Data.Entity;

namespace GameCore.WcfService.DebellisMultitudinis
{
    public interface IDbmModel
    {
        DbSet<Army> Armies { get; set; }
        DbSet<ArmyCommandGroup> ArmyCommandGroups { get; set; }
        DbSet<ArmyCommand> ArmyCommands { get; set; }
        DbSet<ArmyListDefinition> ArmyListDefinitions { get; set; }
        DbSet<ArmyListUnitDefinition> ArmyUnitDefinitions { get; set; }
        DbSet<AlliedArmyListDefinition> AlliedArmyListDefinitions { get; set; }
        DbSet<ArmyUnit> ArmyUnits { get; set; }
        DbSet<Battle> Battles { get; set; }
        DbSet<DbmGame> DbmGames { get; set; }
        DbSet<User> Users { get; set; }

        void SaveDbChanges();
    }
}
namespace GameCore.WcfService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBM_ArmyLists : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ArmyUnit", "IsMounted", c => c.Boolean(nullable: false));
            DropColumn("dbo.ArmyUnit", "Attack");
            DropColumn("dbo.ArmyUnit", "Defence");
            DropColumn("dbo.ArmyUnit", "Move");
            DropColumn("dbo.ArmyUnit", "Range");
            DropColumn("dbo.ArmyUnit", "Speed");
            DropColumn("dbo.ArmyUnit", "Stamina");
            DropColumn("dbo.ArmyUnit", "Level");
            DropColumn("dbo.ArmyUnit", "Morale");
            DropColumn("dbo.ArmyUnit", "Upkeep");
            DropColumn("dbo.ArmyUnit", "ConstructionTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ArmyUnit", "ConstructionTime", c => c.Int(nullable: false));
            AddColumn("dbo.ArmyUnit", "Upkeep", c => c.Int(nullable: false));
            AddColumn("dbo.ArmyUnit", "Morale", c => c.Int(nullable: false));
            AddColumn("dbo.ArmyUnit", "Level", c => c.Int(nullable: false));
            AddColumn("dbo.ArmyUnit", "Stamina", c => c.Int(nullable: false));
            AddColumn("dbo.ArmyUnit", "Speed", c => c.Int(nullable: false));
            AddColumn("dbo.ArmyUnit", "Range", c => c.Int(nullable: false));
            AddColumn("dbo.ArmyUnit", "Move", c => c.Int(nullable: false));
            AddColumn("dbo.ArmyUnit", "Defence", c => c.Int(nullable: false));
            AddColumn("dbo.ArmyUnit", "Attack", c => c.Int(nullable: false));
            DropColumn("dbo.ArmyUnit", "IsMounted");
        }
    }
}

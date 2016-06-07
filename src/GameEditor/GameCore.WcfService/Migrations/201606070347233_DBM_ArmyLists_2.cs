namespace GameCore.WcfService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBM_ArmyLists_2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ArmyListDefinition", "Book", c => c.Int(nullable: false));
            AddColumn("dbo.ArmyListDefinition", "List", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ArmyListDefinition", "List");
            DropColumn("dbo.ArmyListDefinition", "Book");
        }
    }
}

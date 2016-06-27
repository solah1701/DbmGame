namespace GameCore.WcfService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlliedArmyList_3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AlliedArmyListDefinition", "Book", c => c.Int(nullable: false));
            AddColumn("dbo.AlliedArmyListDefinition", "List", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AlliedArmyListDefinition", "List");
            DropColumn("dbo.AlliedArmyListDefinition", "Book");
        }
    }
}

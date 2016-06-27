namespace GameCore.WcfService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlliedArmyList_4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AlliedArmyListDefinition", "ArmyId", c => c.Int(nullable: false));
            CreateIndex("dbo.AlliedArmyListDefinition", "ArmyId");
            //AddForeignKey("dbo.AlliedArmyListDefinition", "ArmyId", "dbo.ArmyListDefinition", "ArmyListDefinitionId");
        }

        public override void Down()
        {
            //DropForeignKey("dbo.AlliedArmyListDefinition", "ArmyId", "dbo.ArmyListDefinition");
            DropIndex("dbo.AlliedArmyListDefinition", new[] { "ArmyId" });
            DropColumn("dbo.AlliedArmyListDefinition", "ArmyId");
        }
    }
}

namespace GameCore.WcfService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArmyCommandGroupReference : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ArmyUnit", "ArmyCommandGroup_ArmyCommandGroupId", c => c.Int());
            CreateIndex("dbo.ArmyUnit", "ArmyCommandGroup_ArmyCommandGroupId");
            AddForeignKey("dbo.ArmyUnit", "ArmyCommandGroup_ArmyCommandGroupId", "dbo.ArmyCommandGroup", "ArmyCommandGroupId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArmyUnit", "ArmyCommandGroup_ArmyCommandGroupId", "dbo.ArmyCommandGroup");
            DropIndex("dbo.ArmyUnit", new[] { "ArmyCommandGroup_ArmyCommandGroupId" });
            DropColumn("dbo.ArmyUnit", "ArmyCommandGroup_ArmyCommandGroupId");
        }
    }
}

namespace GameCore.WcfService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlliedArmyList_2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ArmyListDefinitionAlliedArmyListDefinitions", "ArmyListDefinition_ArmyListDefinitionId", "dbo.ArmyListDefinition");
            DropForeignKey("dbo.ArmyListDefinitionAlliedArmyListDefinitions", "AlliedArmyListDefinition_AlliedArmyListDefinitionId", "dbo.AlliedArmyListDefinition");
            DropIndex("dbo.ArmyListDefinitionAlliedArmyListDefinitions", new[] { "ArmyListDefinition_ArmyListDefinitionId" });
            DropIndex("dbo.ArmyListDefinitionAlliedArmyListDefinitions", new[] { "AlliedArmyListDefinition_AlliedArmyListDefinitionId" });
            AddColumn("dbo.AlliedArmyListDefinition", "ArmyListDefinition_ArmyListDefinitionId", c => c.Int());
            CreateIndex("dbo.AlliedArmyListDefinition", "ArmyListDefinition_ArmyListDefinitionId");
            AddForeignKey("dbo.AlliedArmyListDefinition", "ArmyListDefinition_ArmyListDefinitionId", "dbo.ArmyListDefinition", "ArmyListDefinitionId");
            DropTable("dbo.ArmyListDefinitionAlliedArmyListDefinitions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ArmyListDefinitionAlliedArmyListDefinitions",
                c => new
                    {
                        ArmyListDefinition_ArmyListDefinitionId = c.Int(nullable: false),
                        AlliedArmyListDefinition_AlliedArmyListDefinitionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ArmyListDefinition_ArmyListDefinitionId, t.AlliedArmyListDefinition_AlliedArmyListDefinitionId });
            
            DropForeignKey("dbo.AlliedArmyListDefinition", "ArmyListDefinition_ArmyListDefinitionId", "dbo.ArmyListDefinition");
            DropIndex("dbo.AlliedArmyListDefinition", new[] { "ArmyListDefinition_ArmyListDefinitionId" });
            DropColumn("dbo.AlliedArmyListDefinition", "ArmyListDefinition_ArmyListDefinitionId");
            CreateIndex("dbo.ArmyListDefinitionAlliedArmyListDefinitions", "AlliedArmyListDefinition_AlliedArmyListDefinitionId");
            CreateIndex("dbo.ArmyListDefinitionAlliedArmyListDefinitions", "ArmyListDefinition_ArmyListDefinitionId");
            AddForeignKey("dbo.ArmyListDefinitionAlliedArmyListDefinitions", "AlliedArmyListDefinition_AlliedArmyListDefinitionId", "dbo.AlliedArmyListDefinition", "AlliedArmyListDefinitionId", cascadeDelete: true);
            AddForeignKey("dbo.ArmyListDefinitionAlliedArmyListDefinitions", "ArmyListDefinition_ArmyListDefinitionId", "dbo.ArmyListDefinition", "ArmyListDefinitionId", cascadeDelete: true);
        }
    }
}

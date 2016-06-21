namespace GameCore.WcfService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlliedArmyList : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlliedArmyListDefinition",
                c => new
                    {
                        AlliedArmyListDefinitionId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MinYear = c.Int(nullable: false),
                        MaxYear = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AlliedArmyListDefinitionId);
            
            CreateTable(
                "dbo.ArmyListDefinitionAlliedArmyListDefinitions",
                c => new
                    {
                        ArmyListDefinition_ArmyListDefinitionId = c.Int(nullable: false),
                        AlliedArmyListDefinition_AlliedArmyListDefinitionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ArmyListDefinition_ArmyListDefinitionId, t.AlliedArmyListDefinition_AlliedArmyListDefinitionId })
                .ForeignKey("dbo.ArmyListDefinition", t => t.ArmyListDefinition_ArmyListDefinitionId, cascadeDelete: true)
                .ForeignKey("dbo.AlliedArmyListDefinition", t => t.AlliedArmyListDefinition_AlliedArmyListDefinitionId, cascadeDelete: true)
                .Index(t => t.ArmyListDefinition_ArmyListDefinitionId)
                .Index(t => t.AlliedArmyListDefinition_AlliedArmyListDefinitionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArmyListDefinitionAlliedArmyListDefinitions", "AlliedArmyListDefinition_AlliedArmyListDefinitionId", "dbo.AlliedArmyListDefinition");
            DropForeignKey("dbo.ArmyListDefinitionAlliedArmyListDefinitions", "ArmyListDefinition_ArmyListDefinitionId", "dbo.ArmyListDefinition");
            DropIndex("dbo.ArmyListDefinitionAlliedArmyListDefinitions", new[] { "AlliedArmyListDefinition_AlliedArmyListDefinitionId" });
            DropIndex("dbo.ArmyListDefinitionAlliedArmyListDefinitions", new[] { "ArmyListDefinition_ArmyListDefinitionId" });
            DropTable("dbo.ArmyListDefinitionAlliedArmyListDefinitions");
            DropTable("dbo.AlliedArmyListDefinition");
        }
    }
}

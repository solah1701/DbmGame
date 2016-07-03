namespace GameCore.WcfService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlternativeUnits : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlternativeUnitDefnition",
                c => new
                    {
                        AlternativeUnitDefinitionId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        Upgrade = c.Boolean(nullable: false),
                        UnitId = c.Int(nullable: false),
                        AlternativeUnitId = c.Int(nullable: false),
                        MinPercent = c.Int(nullable: false),
                        MaxPercent = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AlternativeUnitDefinitionId);
            
            AddColumn("dbo.ArmyUnitDefinition", "AlternativeUnitDefinition_AlternativeUnitDefinitionId", c => c.Int());
            CreateIndex("dbo.ArmyUnitDefinition", "AlternativeUnitDefinition_AlternativeUnitDefinitionId");
            AddForeignKey("dbo.ArmyUnitDefinition", "AlternativeUnitDefinition_AlternativeUnitDefinitionId", "dbo.AlternativeUnitDefnition", "AlternativeUnitDefinitionId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArmyUnitDefinition", "AlternativeUnitDefinition_AlternativeUnitDefinitionId", "dbo.AlternativeUnitDefnition");
            DropIndex("dbo.ArmyUnitDefinition", new[] { "AlternativeUnitDefinition_AlternativeUnitDefinitionId" });
            DropColumn("dbo.ArmyUnitDefinition", "AlternativeUnitDefinition_AlternativeUnitDefinitionId");
            DropTable("dbo.AlternativeUnitDefnition");
        }
    }
}

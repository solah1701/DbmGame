namespace GameCore.WcfService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlternativeUnits1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ArmyUnitDefinition", "AlternativeUnitDefinition_AlternativeUnitDefinitionId", "dbo.AlternativeUnitDefnition");
            DropIndex("dbo.ArmyUnitDefinition", new[] { "AlternativeUnitDefinition_AlternativeUnitDefinitionId" });
            AddColumn("dbo.AlternativeUnitDefnition", "ArmyListUnitDefinition_ArmyUnitDefinitionId", c => c.Int());
            CreateIndex("dbo.AlternativeUnitDefnition", "ArmyListUnitDefinition_ArmyUnitDefinitionId");
            AddForeignKey("dbo.AlternativeUnitDefnition", "ArmyListUnitDefinition_ArmyUnitDefinitionId", "dbo.ArmyUnitDefinition", "ArmyUnitDefinitionId");
            DropColumn("dbo.ArmyUnitDefinition", "AlternativeUnitDefinition_AlternativeUnitDefinitionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ArmyUnitDefinition", "AlternativeUnitDefinition_AlternativeUnitDefinitionId", c => c.Int());
            DropForeignKey("dbo.AlternativeUnitDefnition", "ArmyListUnitDefinition_ArmyUnitDefinitionId", "dbo.ArmyUnitDefinition");
            DropIndex("dbo.AlternativeUnitDefnition", new[] { "ArmyListUnitDefinition_ArmyUnitDefinitionId" });
            DropColumn("dbo.AlternativeUnitDefnition", "ArmyListUnitDefinition_ArmyUnitDefinitionId");
            CreateIndex("dbo.ArmyUnitDefinition", "AlternativeUnitDefinition_AlternativeUnitDefinitionId");
            AddForeignKey("dbo.ArmyUnitDefinition", "AlternativeUnitDefinition_AlternativeUnitDefinitionId", "dbo.AlternativeUnitDefnition", "AlternativeUnitDefinitionId");
        }
    }
}

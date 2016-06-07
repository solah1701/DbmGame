namespace GameCore.WcfService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBM_ArmyLists_1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArmyListDefinition",
                c => new
                    {
                        ArmyListDefinitionId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        MinYear = c.Int(nullable: false),
                        MaxYear = c.Int(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.ArmyListDefinitionId);
            
            CreateTable(
                "dbo.ArmyUnitDefinition",
                c => new
                    {
                        ArmyUnitDefinitionId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        Cost = c.Decimal(precision: 18, scale: 2),
                        IsGeneral = c.Boolean(nullable: false),
                        IsChariot = c.Boolean(nullable: false),
                        IsMountedInfantry = c.Boolean(nullable: false),
                        IsAlly = c.Boolean(nullable: false),
                        IsDoubleElement = c.Boolean(nullable: false),
                        MinCount = c.Int(nullable: false),
                        MaxCount = c.Int(nullable: false),
                        MinYear = c.Int(nullable: false),
                        MaxYear = c.Int(nullable: false),
                        DisciplineType = c.Int(nullable: false),
                        UnitType = c.Int(nullable: false),
                        GradeType = c.Int(nullable: false),
                        DispositionType = c.Int(nullable: false),
                        ArmyListDefinition_ArmyListDefinitionId = c.Int(),
                    })
                .PrimaryKey(t => t.ArmyUnitDefinitionId)
                .ForeignKey("dbo.ArmyListDefinition", t => t.ArmyListDefinition_ArmyListDefinitionId)
                .Index(t => t.ArmyListDefinition_ArmyListDefinitionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArmyUnitDefinition", "ArmyListDefinition_ArmyListDefinitionId", "dbo.ArmyListDefinition");
            DropIndex("dbo.ArmyUnitDefinition", new[] { "ArmyListDefinition_ArmyListDefinitionId" });
            DropTable("dbo.ArmyUnitDefinition");
            DropTable("dbo.ArmyListDefinition");
        }
    }
}

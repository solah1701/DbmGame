namespace GameCore.WcfService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Enumerations : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ArmyUnit", "TerrainGoingId");
            DropColumn("dbo.ArmyUnit", "FortifiationTypeId");
            DropColumn("dbo.ArmyUnit", "DisicplineTypeId");
            DropColumn("dbo.ArmyUnit", "UnitTypeId");
            DropColumn("dbo.ArmyUnit", "GradeTypeId");
            DropColumn("dbo.ArmyUnit", "DispositionTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ArmyUnit", "DispositionTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.ArmyUnit", "GradeTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.ArmyUnit", "UnitTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.ArmyUnit", "DisicplineTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.ArmyUnit", "FortifiationTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.ArmyUnit", "TerrainGoingId", c => c.Int(nullable: false));
        }
    }
}

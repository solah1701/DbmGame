namespace GameCore.WcfService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlternativeUnits2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AlternativeUnitDefnition", "MinValue", c => c.Int(nullable: false));
            AddColumn("dbo.AlternativeUnitDefnition", "MaxValue", c => c.Int(nullable: false));
            AddColumn("dbo.AlternativeUnitDefnition", "Percent", c => c.Boolean(nullable: false));
            DropColumn("dbo.AlternativeUnitDefnition", "MinPercent");
            DropColumn("dbo.AlternativeUnitDefnition", "MaxPercent");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AlternativeUnitDefnition", "MaxPercent", c => c.Int(nullable: false));
            AddColumn("dbo.AlternativeUnitDefnition", "MinPercent", c => c.Int(nullable: false));
            DropColumn("dbo.AlternativeUnitDefnition", "Percent");
            DropColumn("dbo.AlternativeUnitDefnition", "MaxValue");
            DropColumn("dbo.AlternativeUnitDefnition", "MinValue");
        }
    }
}

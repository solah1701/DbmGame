namespace GameCore.WcfService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlternativeUnits3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AlternativeUnitDefnition", "UnitId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AlternativeUnitDefnition", "UnitId", c => c.Int(nullable: false));
        }
    }
}

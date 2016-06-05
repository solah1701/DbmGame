namespace GameCore.WcfService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Army",
                c => new
                    {
                        ArmyId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        BattleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ArmyId)
                .ForeignKey("dbo.Battle", t => t.BattleId, cascadeDelete: true)
                .Index(t => t.BattleId);
            
            CreateTable(
                "dbo.ArmyCommand",
                c => new
                    {
                        ArmyCommandId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        ArmyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ArmyCommandId)
                .ForeignKey("dbo.Army", t => t.ArmyId, cascadeDelete: true)
                .Index(t => t.ArmyId);
            
            CreateTable(
                "dbo.ArmyCommandGroup",
                c => new
                    {
                        ArmyCommandGroupId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        ArmyCommandId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ArmyCommandGroupId)
                .ForeignKey("dbo.ArmyCommand", t => t.ArmyCommandId, cascadeDelete: true)
                .Index(t => t.ArmyCommandId);
            
            CreateTable(
                "dbo.ArmyUnit",
                c => new
                    {
                        ArmyUnitId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        Attack = c.Int(nullable: false),
                        Defence = c.Int(nullable: false),
                        Move = c.Int(nullable: false),
                        Range = c.Int(nullable: false),
                        Speed = c.Int(nullable: false),
                        Stamina = c.Int(nullable: false),
                        Level = c.Int(nullable: false),
                        Morale = c.Int(nullable: false),
                        Cost = c.Decimal(precision: 18, scale: 2),
                        Upkeep = c.Int(nullable: false),
                        ConstructionTime = c.Int(nullable: false),
                        IsGeneral = c.Boolean(nullable: false),
                        IsChariot = c.Boolean(nullable: false),
                        IsMountedInfantry = c.Boolean(nullable: false),
                        IsAlly = c.Boolean(nullable: false),
                        IsShooting = c.Boolean(nullable: false),
                        IsFortified = c.Boolean(nullable: false),
                        IsElevated = c.Boolean(nullable: false),
                        IsDoubleElement = c.Boolean(nullable: false),
                        IsContactThisRound = c.Boolean(nullable: false),
                        IsMobile = c.Boolean(nullable: false),
                        IsUnladenNaval = c.Boolean(nullable: false),
                        EnemyOverlapCount = c.Int(nullable: false),
                        RearSupportCount = c.Int(nullable: false),
                        EnemySupportShootingCount = c.Int(nullable: false),
                        SupportingDbmUnitId = c.Int(nullable: false),
                        TerrainGoingId = c.Int(nullable: false),
                        FortifiationTypeId = c.Int(nullable: false),
                        DisicplineTypeId = c.Int(nullable: false),
                        UnitTypeId = c.Int(nullable: false),
                        GradeTypeId = c.Int(nullable: false),
                        DispositionTypeId = c.Int(nullable: false),
                        TerrainGoing = c.Int(nullable: false),
                        FortificationType = c.Int(nullable: false),
                        DisciplineType = c.Int(nullable: false),
                        UnitType = c.Int(nullable: false),
                        GradeType = c.Int(nullable: false),
                        DispositionType = c.Int(nullable: false),
                        SupportingDbmUnit_ArmyUnitId = c.Int(),
                        ArmyCommand_ArmyCommandId = c.Int(),
                    })
                .PrimaryKey(t => t.ArmyUnitId)
                .ForeignKey("dbo.ArmyUnit", t => t.SupportingDbmUnit_ArmyUnitId)
                .ForeignKey("dbo.ArmyCommand", t => t.ArmyCommand_ArmyCommandId)
                .Index(t => t.SupportingDbmUnit_ArmyUnitId)
                .Index(t => t.ArmyCommand_ArmyCommandId);
            
            CreateTable(
                "dbo.Battle",
                c => new
                    {
                        BattleId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        DbmGameId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BattleId)
                .ForeignKey("dbo.DbmGame", t => t.DbmGameId, cascadeDelete: true)
                .Index(t => t.DbmGameId);
            
            CreateTable(
                "dbo.DbmGame",
                c => new
                    {
                        DbmGameId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.DbmGameId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Battle", "DbmGameId", "dbo.DbmGame");
            DropForeignKey("dbo.Army", "BattleId", "dbo.Battle");
            DropForeignKey("dbo.ArmyUnit", "ArmyCommand_ArmyCommandId", "dbo.ArmyCommand");
            DropForeignKey("dbo.ArmyUnit", "SupportingDbmUnit_ArmyUnitId", "dbo.ArmyUnit");
            DropForeignKey("dbo.ArmyCommandGroup", "ArmyCommandId", "dbo.ArmyCommand");
            DropForeignKey("dbo.ArmyCommand", "ArmyId", "dbo.Army");
            DropIndex("dbo.Battle", new[] { "DbmGameId" });
            DropIndex("dbo.ArmyUnit", new[] { "ArmyCommand_ArmyCommandId" });
            DropIndex("dbo.ArmyUnit", new[] { "SupportingDbmUnit_ArmyUnitId" });
            DropIndex("dbo.ArmyCommandGroup", new[] { "ArmyCommandId" });
            DropIndex("dbo.ArmyCommand", new[] { "ArmyId" });
            DropIndex("dbo.Army", new[] { "BattleId" });
            DropTable("dbo.User");
            DropTable("dbo.DbmGame");
            DropTable("dbo.Battle");
            DropTable("dbo.ArmyUnit");
            DropTable("dbo.ArmyCommandGroup");
            DropTable("dbo.ArmyCommand");
            DropTable("dbo.Army");
        }
    }
}

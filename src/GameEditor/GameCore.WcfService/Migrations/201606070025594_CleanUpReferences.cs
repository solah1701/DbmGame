namespace GameCore.WcfService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CleanUpReferences : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ArmyCommand", "ArmyId", "dbo.Army");
            DropForeignKey("dbo.Army", "BattleId", "dbo.Battle");
            DropForeignKey("dbo.ArmyCommandGroup", "ArmyCommandId", "dbo.ArmyCommand");
            DropForeignKey("dbo.Battle", "DbmGameId", "dbo.DbmGame");
            DropIndex("dbo.Army", new[] { "BattleId" });
            DropIndex("dbo.ArmyCommand", new[] { "ArmyId" });
            DropIndex("dbo.ArmyCommandGroup", new[] { "ArmyCommandId" });
            DropIndex("dbo.Battle", new[] { "DbmGameId" });
            RenameColumn(table: "dbo.ArmyCommand", name: "ArmyId", newName: "Army_ArmyId");
            RenameColumn(table: "dbo.Army", name: "BattleId", newName: "Battle_BattleId");
            RenameColumn(table: "dbo.ArmyCommandGroup", name: "ArmyCommandId", newName: "ArmyCommand_ArmyCommandId");
            RenameColumn(table: "dbo.Battle", name: "DbmGameId", newName: "DbmGame_DbmGameId");
            AlterColumn("dbo.Army", "Battle_BattleId", c => c.Int());
            AlterColumn("dbo.ArmyCommand", "Army_ArmyId", c => c.Int());
            AlterColumn("dbo.ArmyCommandGroup", "ArmyCommand_ArmyCommandId", c => c.Int());
            AlterColumn("dbo.Battle", "DbmGame_DbmGameId", c => c.Int());
            CreateIndex("dbo.Army", "Battle_BattleId");
            CreateIndex("dbo.ArmyCommand", "Army_ArmyId");
            CreateIndex("dbo.ArmyCommandGroup", "ArmyCommand_ArmyCommandId");
            CreateIndex("dbo.Battle", "DbmGame_DbmGameId");
            AddForeignKey("dbo.ArmyCommand", "Army_ArmyId", "dbo.Army", "ArmyId");
            AddForeignKey("dbo.Army", "Battle_BattleId", "dbo.Battle", "BattleId");
            AddForeignKey("dbo.ArmyCommandGroup", "ArmyCommand_ArmyCommandId", "dbo.ArmyCommand", "ArmyCommandId");
            AddForeignKey("dbo.Battle", "DbmGame_DbmGameId", "dbo.DbmGame", "DbmGameId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Battle", "DbmGame_DbmGameId", "dbo.DbmGame");
            DropForeignKey("dbo.ArmyCommandGroup", "ArmyCommand_ArmyCommandId", "dbo.ArmyCommand");
            DropForeignKey("dbo.Army", "Battle_BattleId", "dbo.Battle");
            DropForeignKey("dbo.ArmyCommand", "Army_ArmyId", "dbo.Army");
            DropIndex("dbo.Battle", new[] { "DbmGame_DbmGameId" });
            DropIndex("dbo.ArmyCommandGroup", new[] { "ArmyCommand_ArmyCommandId" });
            DropIndex("dbo.ArmyCommand", new[] { "Army_ArmyId" });
            DropIndex("dbo.Army", new[] { "Battle_BattleId" });
            AlterColumn("dbo.Battle", "DbmGame_DbmGameId", c => c.Int(nullable: false));
            AlterColumn("dbo.ArmyCommandGroup", "ArmyCommand_ArmyCommandId", c => c.Int(nullable: false));
            AlterColumn("dbo.ArmyCommand", "Army_ArmyId", c => c.Int(nullable: false));
            AlterColumn("dbo.Army", "Battle_BattleId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Battle", name: "DbmGame_DbmGameId", newName: "DbmGameId");
            RenameColumn(table: "dbo.ArmyCommandGroup", name: "ArmyCommand_ArmyCommandId", newName: "ArmyCommandId");
            RenameColumn(table: "dbo.Army", name: "Battle_BattleId", newName: "BattleId");
            RenameColumn(table: "dbo.ArmyCommand", name: "Army_ArmyId", newName: "ArmyId");
            CreateIndex("dbo.Battle", "DbmGameId");
            CreateIndex("dbo.ArmyCommandGroup", "ArmyCommandId");
            CreateIndex("dbo.ArmyCommand", "ArmyId");
            CreateIndex("dbo.Army", "BattleId");
            AddForeignKey("dbo.Battle", "DbmGameId", "dbo.DbmGame", "DbmGameId", cascadeDelete: true);
            AddForeignKey("dbo.ArmyCommandGroup", "ArmyCommandId", "dbo.ArmyCommand", "ArmyCommandId", cascadeDelete: true);
            AddForeignKey("dbo.Army", "BattleId", "dbo.Battle", "BattleId", cascadeDelete: true);
            AddForeignKey("dbo.ArmyCommand", "ArmyId", "dbo.Army", "ArmyId", cascadeDelete: true);
        }
    }
}

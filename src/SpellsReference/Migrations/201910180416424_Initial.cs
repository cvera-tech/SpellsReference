namespace SpellsReference.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Spellbook",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Spell",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Level = c.Int(nullable: false),
                        School = c.Int(nullable: false),
                        CastingTime = c.String(nullable: false),
                        Range = c.String(nullable: false),
                        Verbal = c.Boolean(nullable: false),
                        Somatic = c.Boolean(nullable: false),
                        Materials = c.String(),
                        Duration = c.String(nullable: false),
                        Ritual = c.Boolean(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false, maxLength: 255),
                        HashedPassword = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Email, unique: true);
            
            CreateTable(
                "dbo.SpellbookSpell",
                c => new
                    {
                        SpellbookId = c.Int(nullable: false),
                        SpellId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SpellbookId, t.SpellId })
                .ForeignKey("dbo.Spellbook", t => t.SpellbookId, cascadeDelete: true)
                .ForeignKey("dbo.Spell", t => t.SpellId, cascadeDelete: true)
                .Index(t => t.SpellbookId)
                .Index(t => t.SpellId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SpellbookSpell", "SpellId", "dbo.Spell");
            DropForeignKey("dbo.SpellbookSpell", "SpellbookId", "dbo.Spellbook");
            DropIndex("dbo.SpellbookSpell", new[] { "SpellId" });
            DropIndex("dbo.SpellbookSpell", new[] { "SpellbookId" });
            DropIndex("dbo.User", new[] { "Email" });
            DropTable("dbo.SpellbookSpell");
            DropTable("dbo.User");
            DropTable("dbo.Spell");
            DropTable("dbo.Spellbook");
        }
    }
}

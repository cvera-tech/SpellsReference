using Microsoft.EntityFrameworkCore.Migrations;

namespace SpellsReferenceCore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Spellbooks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spellbooks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Spells",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    School = table.Column<int>(nullable: false),
                    CastingTime = table.Column<string>(nullable: false),
                    Range = table.Column<string>(nullable: false),
                    Verbal = table.Column<bool>(nullable: false),
                    Somatic = table.Column<bool>(nullable: false),
                    Materials = table.Column<string>(nullable: true),
                    Duration = table.Column<string>(nullable: false),
                    Ritual = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    SpellbookId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spells", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Spells_Spellbooks_SpellbookId",
                        column: x => x.SpellbookId,
                        principalTable: "Spellbooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpellbookSpell",
                columns: table => new
                {
                    SpellbookId = table.Column<int>(nullable: false),
                    SpellId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellbookSpell", x => new { x.SpellbookId, x.SpellId });
                    table.ForeignKey(
                        name: "FK_SpellbookSpell_Spells_SpellId",
                        column: x => x.SpellId,
                        principalTable: "Spells",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpellbookSpell_Spellbooks_SpellbookId",
                        column: x => x.SpellbookId,
                        principalTable: "Spellbooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpellbookSpell_SpellId",
                table: "SpellbookSpell",
                column: "SpellId");

            migrationBuilder.CreateIndex(
                name: "IX_Spells_SpellbookId",
                table: "Spells",
                column: "SpellbookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpellbookSpell");

            migrationBuilder.DropTable(
                name: "Spells");

            migrationBuilder.DropTable(
                name: "Spellbooks");
        }
    }
}

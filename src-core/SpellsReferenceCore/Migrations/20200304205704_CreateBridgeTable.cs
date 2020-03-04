using Microsoft.EntityFrameworkCore.Migrations;

namespace SpellsReferenceCore.Migrations
{
    public partial class CreateBridgeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpellbookSpell_Spells_SpellId",
                table: "SpellbookSpell");

            migrationBuilder.DropForeignKey(
                name: "FK_SpellbookSpell_Spellbooks_SpellbookId",
                table: "SpellbookSpell");

            migrationBuilder.DropForeignKey(
                name: "FK_Spells_Spellbooks_SpellbookId",
                table: "Spells");

            migrationBuilder.DropIndex(
                name: "IX_Spells_SpellbookId",
                table: "Spells");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpellbookSpell",
                table: "SpellbookSpell");

            migrationBuilder.DropColumn(
                name: "SpellbookId",
                table: "Spells");

            migrationBuilder.RenameTable(
                name: "SpellbookSpell",
                newName: "SpellbookSpells");

            migrationBuilder.RenameIndex(
                name: "IX_SpellbookSpell_SpellId",
                table: "SpellbookSpells",
                newName: "IX_SpellbookSpells_SpellId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpellbookSpells",
                table: "SpellbookSpells",
                columns: new[] { "SpellbookId", "SpellId" });

            migrationBuilder.AddForeignKey(
                name: "FK_SpellbookSpells_Spells_SpellId",
                table: "SpellbookSpells",
                column: "SpellId",
                principalTable: "Spells",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpellbookSpells_Spellbooks_SpellbookId",
                table: "SpellbookSpells",
                column: "SpellbookId",
                principalTable: "Spellbooks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpellbookSpells_Spells_SpellId",
                table: "SpellbookSpells");

            migrationBuilder.DropForeignKey(
                name: "FK_SpellbookSpells_Spellbooks_SpellbookId",
                table: "SpellbookSpells");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpellbookSpells",
                table: "SpellbookSpells");

            migrationBuilder.RenameTable(
                name: "SpellbookSpells",
                newName: "SpellbookSpell");

            migrationBuilder.RenameIndex(
                name: "IX_SpellbookSpells_SpellId",
                table: "SpellbookSpell",
                newName: "IX_SpellbookSpell_SpellId");

            migrationBuilder.AddColumn<int>(
                name: "SpellbookId",
                table: "Spells",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpellbookSpell",
                table: "SpellbookSpell",
                columns: new[] { "SpellbookId", "SpellId" });

            migrationBuilder.CreateIndex(
                name: "IX_Spells_SpellbookId",
                table: "Spells",
                column: "SpellbookId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpellbookSpell_Spells_SpellId",
                table: "SpellbookSpell",
                column: "SpellId",
                principalTable: "Spells",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpellbookSpell_Spellbooks_SpellbookId",
                table: "SpellbookSpell",
                column: "SpellbookId",
                principalTable: "Spellbooks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Spells_Spellbooks_SpellbookId",
                table: "Spells",
                column: "SpellbookId",
                principalTable: "Spellbooks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

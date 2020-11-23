using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorApp4s.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Operator",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pasture",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    OperatorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pasture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pasture_Operator_OperatorId",
                        column: x => x.OperatorId,
                        principalTable: "Operator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Field",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    PastureId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Field", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Field_Pasture_PastureId",
                        column: x => x.PastureId,
                        principalTable: "Pasture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Field_PastureId",
                table: "Field",
                column: "PastureId");

            migrationBuilder.CreateIndex(
                name: "IX_Pasture_OperatorId",
                table: "Pasture",
                column: "OperatorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Field");

            migrationBuilder.DropTable(
                name: "Pasture");

            migrationBuilder.DropTable(
                name: "Operator");
        }
    }
}

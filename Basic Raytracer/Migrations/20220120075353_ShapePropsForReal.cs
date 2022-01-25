using Microsoft.EntityFrameworkCore.Migrations;

namespace Basic_Raytracer.Migrations
{
    public partial class ShapePropsForReal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShapePros",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ShapeID = table.Column<int>(type: "INTEGER", nullable: false),
                    PropertyName = table.Column<string>(type: "TEXT", nullable: true),
                    ProperyValue = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShapePros", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ShapePros_Shapes_ShapeID",
                        column: x => x.ShapeID,
                        principalTable: "Shapes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShapePros_ShapeID",
                table: "ShapePros",
                column: "ShapeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShapePros");
        }
    }
}

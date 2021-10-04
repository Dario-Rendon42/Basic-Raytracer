using Microsoft.EntityFrameworkCore.Migrations;

namespace Basic_Raytracer.Migrations
{
    public partial class AddModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Scenes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SceneName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scenes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ShapeTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ShapeTypeName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShapeTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Shapes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ShapeName = table.Column<string>(type: "TEXT", nullable: true),
                    ShapeTypeID = table.Column<int>(type: "INTEGER", nullable: false),
                    SceneID = table.Column<int>(type: "INTEGER", nullable: false),
                    OriginX = table.Column<double>(type: "REAL", nullable: false),
                    OriginY = table.Column<double>(type: "REAL", nullable: false),
                    OriginZ = table.Column<double>(type: "REAL", nullable: false),
                    ColorRed = table.Column<int>(type: "INTEGER", nullable: false),
                    ColorGreen = table.Column<int>(type: "INTEGER", nullable: false),
                    ColorBlue = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shapes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Shapes_Scenes_SceneID",
                        column: x => x.SceneID,
                        principalTable: "Scenes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shapes_ShapeTypes_ShapeTypeID",
                        column: x => x.ShapeTypeID,
                        principalTable: "ShapeTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shapes_SceneID",
                table: "Shapes",
                column: "SceneID");

            migrationBuilder.CreateIndex(
                name: "IX_Shapes_ShapeTypeID",
                table: "Shapes",
                column: "ShapeTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shapes");

            migrationBuilder.DropTable(
                name: "Scenes");

            migrationBuilder.DropTable(
                name: "ShapeTypes");
        }
    }
}

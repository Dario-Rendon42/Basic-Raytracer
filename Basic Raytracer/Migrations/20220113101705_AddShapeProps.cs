using Microsoft.EntityFrameworkCore.Migrations;

namespace Basic_Raytracer.Migrations
{
    public partial class AddShapeProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cameras",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    sceneID = table.Column<int>(type: "INTEGER", nullable: true),
                    OriginX = table.Column<double>(type: "REAL", nullable: false),
                    OriginY = table.Column<double>(type: "REAL", nullable: false),
                    OriginZ = table.Column<double>(type: "REAL", nullable: false),
                    SubjectX = table.Column<double>(type: "REAL", nullable: false),
                    SubjectY = table.Column<double>(type: "REAL", nullable: false),
                    SubjectZ = table.Column<double>(type: "REAL", nullable: false),
                    FOV = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cameras", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cameras_Scenes_sceneID",
                        column: x => x.sceneID,
                        principalTable: "Scenes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cameras_sceneID",
                table: "Cameras",
                column: "sceneID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cameras");
        }
    }
}

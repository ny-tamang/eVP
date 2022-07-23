using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace evp.Data.Migrations
{
    public partial class models_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessVisaForm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessVisaForm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentVisaForm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentVisaForm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TouristVisaForm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TouristVisaForm", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessVisaForm");

            migrationBuilder.DropTable(
                name: "StudentVisaForm");

            migrationBuilder.DropTable(
                name: "TouristVisaForm");
        }
    }
}

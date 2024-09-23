using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatosEEF.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "telefonos",
                columns: table => new
                {
                    ntelefono = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: false),
                    nombre = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    direccion = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    observaciones = table.Column<string>(type: "varchar(240)", unicode: false, maxLength: 240, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__telefono__F9137AFE1B6AFC39", x => x.ntelefono);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "telefonos");
        }
    }
}

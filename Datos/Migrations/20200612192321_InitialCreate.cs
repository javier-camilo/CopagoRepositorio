using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Copagos",
                columns: table => new
                {
                    IdentificacionPaciente = table.Column<string>(nullable: false),
                    ValorServicio = table.Column<double>(nullable: false),
                    SalarioTrabajador = table.Column<double>(nullable: false),
                    Porcentaje = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Copagos", x => x.IdentificacionPaciente);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Copagos");
        }
    }
}

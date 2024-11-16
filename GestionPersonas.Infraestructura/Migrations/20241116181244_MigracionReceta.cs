using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionRecetas.Infraestructura.Migrations
{
    /// <inheritdoc />
    public partial class MigracionReceta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recetas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    NombrePaciente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Medico = table.Column<int>(type: "int", nullable: false),
                    NombreMedico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HistoriaClinica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dosis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duracion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Instrucciones = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Medicamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ViaAdministracion = table.Column<int>(type: "int", nullable: false),
                    EstadoReceta = table.Column<int>(type: "int", nullable: false),
                    ObservacionesPlanTratamiento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diagnostico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaReceta = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Calle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Barrio = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Departamento = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Municipio = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recetas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recetas");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestfin.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comunidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CIF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Domicilio_TipoVia = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Domicilio_Calle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Domicilio_Numero = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Domicilio_Piso = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Domicilio_Portal = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Domicilio_Puerta = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comunidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Propiedades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComundiadId = table.Column<int>(type: "int", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Domicilio_TipoVia = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Domicilio_Calle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Domicilio_Numero = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Domicilio_Piso = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Domicilio_Portal = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Domicilio_Puerta = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propiedades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Propietarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Domicilio_TipoVia = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Domicilio_Calle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Domicilio_Numero = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Domicilio_Piso = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Domicilio_Portal = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Domicilio_Puerta = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propietarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Conceptos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComunidadId = table.Column<int>(type: "int", nullable: false),
                    RepartoId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conceptos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conceptos_Comunidades_ComunidadId",
                        column: x => x.ComunidadId,
                        principalTable: "Comunidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Repartos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComunidadId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Enteros = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repartos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Repartos_Comunidades_ComunidadId",
                        column: x => x.ComunidadId,
                        principalTable: "Comunidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParticipacionRepartos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComunidadId = table.Column<int>(type: "int", nullable: false),
                    PropiedadId = table.Column<int>(type: "int", nullable: false),
                    RepartoId = table.Column<int>(type: "int", nullable: false),
                    Participacion = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipacionRepartos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParticipacionRepartos_Propiedades_PropiedadId",
                        column: x => x.PropiedadId,
                        principalTable: "Propiedades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropietariosPropiedades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropietarioId = table.Column<int>(type: "int", nullable: false),
                    PropiedadId = table.Column<int>(type: "int", nullable: false),
                    Coeficiente = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    Principal = table.Column<bool>(type: "bit", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropietariosPropiedades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropietariosPropiedades_Propiedades_PropiedadId",
                        column: x => x.PropiedadId,
                        principalTable: "Propiedades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropietariosPropiedades_Propietarios_PropietarioId",
                        column: x => x.PropietarioId,
                        principalTable: "Propietarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conceptos_ComunidadId",
                table: "Conceptos",
                column: "ComunidadId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParticipacionRepartos_PropiedadId",
                table: "ParticipacionRepartos",
                column: "PropiedadId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PropietariosPropiedades_PropiedadId",
                table: "PropietariosPropiedades",
                column: "PropiedadId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PropietariosPropiedades_PropietarioId",
                table: "PropietariosPropiedades",
                column: "PropietarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Repartos_ComunidadId",
                table: "Repartos",
                column: "ComunidadId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conceptos");

            migrationBuilder.DropTable(
                name: "ParticipacionRepartos");

            migrationBuilder.DropTable(
                name: "PropietariosPropiedades");

            migrationBuilder.DropTable(
                name: "Repartos");

            migrationBuilder.DropTable(
                name: "Propiedades");

            migrationBuilder.DropTable(
                name: "Propietarios");

            migrationBuilder.DropTable(
                name: "Comunidades");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestfin.Migrations
{
    /// <inheritdoc />
    public partial class Inluirtablasrecibos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recibo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComunidadId = table.Column<int>(type: "int", nullable: false),
                    PropiedadId = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Importe = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recibo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReciboDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReciboId = table.Column<int>(type: "int", nullable: false),
                    Texto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Importe = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReciboDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReciboDetalle_Recibo_ReciboId",
                        column: x => x.ReciboId,
                        principalTable: "Recibo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReciboHistoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReciboId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Motivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoInicial = table.Column<int>(type: "int", nullable: false),
                    EstadoFinal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReciboHistoria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReciboHistoria_Recibo_ReciboId",
                        column: x => x.ReciboId,
                        principalTable: "Recibo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReciboPago",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReciboId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Importe = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    MetodoPago = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReciboPago", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReciboPago_Recibo_ReciboId",
                        column: x => x.ReciboId,
                        principalTable: "Recibo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReciboDetalle_ReciboId",
                table: "ReciboDetalle",
                column: "ReciboId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReciboHistoria_ReciboId",
                table: "ReciboHistoria",
                column: "ReciboId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReciboPago_ReciboId",
                table: "ReciboPago",
                column: "ReciboId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReciboDetalle");

            migrationBuilder.DropTable(
                name: "ReciboHistoria");

            migrationBuilder.DropTable(
                name: "ReciboPago");

            migrationBuilder.DropTable(
                name: "Recibo");
        }
    }
}

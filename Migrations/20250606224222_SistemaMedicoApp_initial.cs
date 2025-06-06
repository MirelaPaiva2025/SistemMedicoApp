using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaMedicoApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class SistemaMedicoApp_initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EXAME",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRICAO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TIPOEXAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DATAEXAME = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DATAENTREGARESULTADO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    STATUSEXAME = table.Column<int>(type: "int", nullable: false),
                    OBSERVACOES = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXAME", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PACIENTE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DATA_NASCIMENTO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ENDERECO = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    GENERO = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PACIENTE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PEDIDOEXAME",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PACIENTEID = table.Column<int>(type: "int", nullable: false),
                    ExameId = table.Column<int>(type: "int", nullable: false),
                    DATAPEDIDO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MEDICOSOLICITANTE = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SITUACAOPEDIDOEXAME = table.Column<int>(type: "int", nullable: false),
                    OBSERVACOES = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PEDIDOEXAME", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PEDIDOEXAME_PACIENTE_PACIENTEID",
                        column: x => x.PACIENTEID,
                        principalTable: "PACIENTE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ITENSPEDIDOEXAME",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PEDIDOEXAMEID = table.Column<int>(type: "int", nullable: false),
                    EXAMEID = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    OBSERVACOES = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ITENSPEDIDOEXAME", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ITENSPEDIDOEXAME_EXAME_EXAMEID",
                        column: x => x.EXAMEID,
                        principalTable: "EXAME",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ITENSPEDIDOEXAME_PEDIDOEXAME_PEDIDOEXAMEID",
                        column: x => x.PEDIDOEXAMEID,
                        principalTable: "PEDIDOEXAME",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ITENSPEDIDOEXAME_EXAMEID",
                table: "ITENSPEDIDOEXAME",
                column: "EXAMEID");

            migrationBuilder.CreateIndex(
                name: "IX_ITENSPEDIDOEXAME_PEDIDOEXAMEID",
                table: "ITENSPEDIDOEXAME",
                column: "PEDIDOEXAMEID");

            migrationBuilder.CreateIndex(
                name: "IX_PEDIDOEXAME_PACIENTEID",
                table: "PEDIDOEXAME",
                column: "PACIENTEID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ITENSPEDIDOEXAME");

            migrationBuilder.DropTable(
                name: "EXAME");

            migrationBuilder.DropTable(
                name: "PEDIDOEXAME");

            migrationBuilder.DropTable(
                name: "PACIENTE");
        }
    }
}

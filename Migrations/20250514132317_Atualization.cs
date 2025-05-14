using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mottu.Migrations
{
    /// <inheritdoc />
    public partial class Atualization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Ano",
                schema: "RM557481",
                table: "Motos",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_Filial",
                schema: "RM557481",
                table: "Motos",
                type: "NUMBER(10)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id_Sensor",
                schema: "RM557481",
                table: "Motos",
                type: "NUMBER(10)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Filiais",
                schema: "RM557481",
                columns: table => new
                {
                    Id_Filial = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Endereco = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Cidade = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filiais", x => x.Id_Filial);
                });

            migrationBuilder.CreateTable(
                name: "Operadores",
                schema: "RM557481",
                columns: table => new
                {
                    Id_Operador = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CPF = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Login = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operadores", x => x.Id_Operador);
                });

            migrationBuilder.CreateTable(
                name: "Sensores",
                schema: "RM557481",
                columns: table => new
                {
                    Id_Sensor = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Codigo_Tag = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Data_Ativacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensores", x => x.Id_Sensor);
                });

            migrationBuilder.CreateTable(
                name: "StatusVagas",
                schema: "RM557481",
                columns: table => new
                {
                    Id_Status = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Descricao_Status = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusVagas", x => x.Id_Status);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                schema: "RM557481",
                columns: table => new
                {
                    Id_Usuario = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Login = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Senha_Hash = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Perfil = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id_Usuario);
                });

            migrationBuilder.CreateTable(
                name: "Vagas",
                schema: "RM557481",
                columns: table => new
                {
                    Id_Vaga = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Numero_Vaga = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Id_Status = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    Id_Filial = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vagas", x => x.Id_Vaga);
                    table.ForeignKey(
                        name: "FK_Vagas_Filiais_Id_Filial",
                        column: x => x.Id_Filial,
                        principalSchema: "RM557481",
                        principalTable: "Filiais",
                        principalColumn: "Id_Filial",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vagas_StatusVagas_Id_Status",
                        column: x => x.Id_Status,
                        principalSchema: "RM557481",
                        principalTable: "StatusVagas",
                        principalColumn: "Id_Status");
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                schema: "RM557481",
                columns: table => new
                {
                    Id_Log = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Id_Usuario = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Acao_Realizada = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Data_Hora = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id_Log);
                    table.ForeignKey(
                        name: "FK_Logs_Usuarios_Id_Usuario",
                        column: x => x.Id_Usuario,
                        principalSchema: "RM557481",
                        principalTable: "Usuarios",
                        principalColumn: "Id_Usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movimentacoes",
                schema: "RM557481",
                columns: table => new
                {
                    Id_Mov = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Id_Moto = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Id_Vaga = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Entrada = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Saida = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    Id_Operador = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimentacoes", x => x.Id_Mov);
                    table.ForeignKey(
                        name: "FK_Movimentacoes_Motos_Id_Moto",
                        column: x => x.Id_Moto,
                        principalSchema: "RM557481",
                        principalTable: "Motos",
                        principalColumn: "Id_Moto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movimentacoes_Operadores_Id_Operador",
                        column: x => x.Id_Operador,
                        principalSchema: "RM557481",
                        principalTable: "Operadores",
                        principalColumn: "Id_Operador",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movimentacoes_Vagas_Id_Vaga",
                        column: x => x.Id_Vaga,
                        principalSchema: "RM557481",
                        principalTable: "Vagas",
                        principalColumn: "Id_Vaga",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Motos_Id_Filial",
                schema: "RM557481",
                table: "Motos",
                column: "Id_Filial");

            migrationBuilder.CreateIndex(
                name: "IX_Motos_Id_Sensor",
                schema: "RM557481",
                table: "Motos",
                column: "Id_Sensor");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_Id_Usuario",
                schema: "RM557481",
                table: "Logs",
                column: "Id_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacoes_Id_Moto",
                schema: "RM557481",
                table: "Movimentacoes",
                column: "Id_Moto");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacoes_Id_Operador",
                schema: "RM557481",
                table: "Movimentacoes",
                column: "Id_Operador");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacoes_Id_Vaga",
                schema: "RM557481",
                table: "Movimentacoes",
                column: "Id_Vaga");

            migrationBuilder.CreateIndex(
                name: "IX_Vagas_Id_Filial",
                schema: "RM557481",
                table: "Vagas",
                column: "Id_Filial");

            migrationBuilder.CreateIndex(
                name: "IX_Vagas_Id_Status",
                schema: "RM557481",
                table: "Vagas",
                column: "Id_Status");

            migrationBuilder.AddForeignKey(
                name: "FK_Motos_Filiais_Id_Filial",
                schema: "RM557481",
                table: "Motos",
                column: "Id_Filial",
                principalSchema: "RM557481",
                principalTable: "Filiais",
                principalColumn: "Id_Filial");

            migrationBuilder.AddForeignKey(
                name: "FK_Motos_Sensores_Id_Sensor",
                schema: "RM557481",
                table: "Motos",
                column: "Id_Sensor",
                principalSchema: "RM557481",
                principalTable: "Sensores",
                principalColumn: "Id_Sensor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motos_Filiais_Id_Filial",
                schema: "RM557481",
                table: "Motos");

            migrationBuilder.DropForeignKey(
                name: "FK_Motos_Sensores_Id_Sensor",
                schema: "RM557481",
                table: "Motos");

            migrationBuilder.DropTable(
                name: "Logs",
                schema: "RM557481");

            migrationBuilder.DropTable(
                name: "Movimentacoes",
                schema: "RM557481");

            migrationBuilder.DropTable(
                name: "Sensores",
                schema: "RM557481");

            migrationBuilder.DropTable(
                name: "Usuarios",
                schema: "RM557481");

            migrationBuilder.DropTable(
                name: "Operadores",
                schema: "RM557481");

            migrationBuilder.DropTable(
                name: "Vagas",
                schema: "RM557481");

            migrationBuilder.DropTable(
                name: "Filiais",
                schema: "RM557481");

            migrationBuilder.DropTable(
                name: "StatusVagas",
                schema: "RM557481");

            migrationBuilder.DropIndex(
                name: "IX_Motos_Id_Filial",
                schema: "RM557481",
                table: "Motos");

            migrationBuilder.DropIndex(
                name: "IX_Motos_Id_Sensor",
                schema: "RM557481",
                table: "Motos");

            migrationBuilder.DropColumn(
                name: "Ano",
                schema: "RM557481",
                table: "Motos");

            migrationBuilder.DropColumn(
                name: "Id_Filial",
                schema: "RM557481",
                table: "Motos");

            migrationBuilder.DropColumn(
                name: "Id_Sensor",
                schema: "RM557481",
                table: "Motos");
        }
    }
}

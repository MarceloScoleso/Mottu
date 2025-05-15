using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mottu.Migrations
{
    /// <inheritdoc />
    public partial class AjustesModeloVagaEstacionamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motos_Filiais_Id_Filial",
                schema: "RM557481",
                table: "Motos");

            migrationBuilder.DropForeignKey(
                name: "FK_Movimentacoes_Vagas_Id_Vaga",
                schema: "RM557481",
                table: "Movimentacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Vagas_Filiais_Id_Filial",
                schema: "RM557481",
                table: "Vagas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vagas_StatusVagas_Id_Status",
                schema: "RM557481",
                table: "Vagas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vagas",
                schema: "RM557481",
                table: "Vagas");

            migrationBuilder.RenameTable(
                name: "Vagas",
                schema: "RM557481",
                newName: "VagasEstacionamento",
                newSchema: "RM557481");

            migrationBuilder.RenameColumn(
                name: "Id_Usuario",
                schema: "RM557481",
                table: "Usuarios",
                newName: "ID_USUARIO");

            migrationBuilder.RenameIndex(
                name: "IX_Vagas_Id_Status",
                schema: "RM557481",
                table: "VagasEstacionamento",
                newName: "IX_VagasEstacionamento_Id_Status");

            migrationBuilder.RenameIndex(
                name: "IX_Vagas_Id_Filial",
                schema: "RM557481",
                table: "VagasEstacionamento",
                newName: "IX_VagasEstacionamento_Id_Filial");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao_Status",
                schema: "RM557481",
                table: "StatusVagas",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<string>(
                name: "Codigo_Tag",
                schema: "RM557481",
                table: "Sensores",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<int>(
                name: "Id_Status",
                schema: "RM557481",
                table: "VagasEstacionamento",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeFilial",
                schema: "RM557481",
                table: "VagasEstacionamento",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StatusDescricao",
                schema: "RM557481",
                table: "VagasEstacionamento",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VagasEstacionamento",
                schema: "RM557481",
                table: "VagasEstacionamento",
                column: "Id_Vaga");

            migrationBuilder.AddForeignKey(
                name: "FK_Motos_Filiais_Id_Filial",
                schema: "RM557481",
                table: "Motos",
                column: "Id_Filial",
                principalSchema: "RM557481",
                principalTable: "Filiais",
                principalColumn: "Id_Filial",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movimentacoes_VagasEstacionamento_Id_Vaga",
                schema: "RM557481",
                table: "Movimentacoes",
                column: "Id_Vaga",
                principalSchema: "RM557481",
                principalTable: "VagasEstacionamento",
                principalColumn: "Id_Vaga",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VagasEstacionamento_Filiais_Id_Filial",
                schema: "RM557481",
                table: "VagasEstacionamento",
                column: "Id_Filial",
                principalSchema: "RM557481",
                principalTable: "Filiais",
                principalColumn: "Id_Filial",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VagasEstacionamento_StatusVagas_Id_Status",
                schema: "RM557481",
                table: "VagasEstacionamento",
                column: "Id_Status",
                principalSchema: "RM557481",
                principalTable: "StatusVagas",
                principalColumn: "Id_Status",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motos_Filiais_Id_Filial",
                schema: "RM557481",
                table: "Motos");

            migrationBuilder.DropForeignKey(
                name: "FK_Movimentacoes_VagasEstacionamento_Id_Vaga",
                schema: "RM557481",
                table: "Movimentacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_VagasEstacionamento_Filiais_Id_Filial",
                schema: "RM557481",
                table: "VagasEstacionamento");

            migrationBuilder.DropForeignKey(
                name: "FK_VagasEstacionamento_StatusVagas_Id_Status",
                schema: "RM557481",
                table: "VagasEstacionamento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VagasEstacionamento",
                schema: "RM557481",
                table: "VagasEstacionamento");

            migrationBuilder.DropColumn(
                name: "NomeFilial",
                schema: "RM557481",
                table: "VagasEstacionamento");

            migrationBuilder.DropColumn(
                name: "StatusDescricao",
                schema: "RM557481",
                table: "VagasEstacionamento");

            migrationBuilder.RenameTable(
                name: "VagasEstacionamento",
                schema: "RM557481",
                newName: "Vagas",
                newSchema: "RM557481");

            migrationBuilder.RenameColumn(
                name: "ID_USUARIO",
                schema: "RM557481",
                table: "Usuarios",
                newName: "Id_Usuario");

            migrationBuilder.RenameIndex(
                name: "IX_VagasEstacionamento_Id_Status",
                schema: "RM557481",
                table: "Vagas",
                newName: "IX_Vagas_Id_Status");

            migrationBuilder.RenameIndex(
                name: "IX_VagasEstacionamento_Id_Filial",
                schema: "RM557481",
                table: "Vagas",
                newName: "IX_Vagas_Id_Filial");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao_Status",
                schema: "RM557481",
                table: "StatusVagas",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Codigo_Tag",
                schema: "RM557481",
                table: "Sensores",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id_Status",
                schema: "RM557481",
                table: "Vagas",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vagas",
                schema: "RM557481",
                table: "Vagas",
                column: "Id_Vaga");

            migrationBuilder.AddForeignKey(
                name: "FK_Motos_Filiais_Id_Filial",
                schema: "RM557481",
                table: "Motos",
                column: "Id_Filial",
                principalSchema: "RM557481",
                principalTable: "Filiais",
                principalColumn: "Id_Filial");

            migrationBuilder.AddForeignKey(
                name: "FK_Movimentacoes_Vagas_Id_Vaga",
                schema: "RM557481",
                table: "Movimentacoes",
                column: "Id_Vaga",
                principalSchema: "RM557481",
                principalTable: "Vagas",
                principalColumn: "Id_Vaga",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vagas_Filiais_Id_Filial",
                schema: "RM557481",
                table: "Vagas",
                column: "Id_Filial",
                principalSchema: "RM557481",
                principalTable: "Filiais",
                principalColumn: "Id_Filial",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vagas_StatusVagas_Id_Status",
                schema: "RM557481",
                table: "Vagas",
                column: "Id_Status",
                principalSchema: "RM557481",
                principalTable: "StatusVagas",
                principalColumn: "Id_Status");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mottu.Migrations
{
    /// <inheritdoc />
    public partial class AjusteRelacionamentoSensor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Usuarios_Id_Usuario",
                schema: "RM557481",
                table: "Logs");

            migrationBuilder.DropForeignKey(
                name: "FK_Motos_Sensor_IoT_Id_Sensor",
                schema: "RM557481",
                table: "Motos");

            migrationBuilder.DropForeignKey(
                name: "FK_Movimentacoes_Motos_Id_Moto",
                schema: "RM557481",
                table: "Movimentacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Movimentacoes_Operadores_Id_Operador",
                schema: "RM557481",
                table: "Movimentacoes");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Usuarios_Id_Usuario",
                schema: "RM557481",
                table: "Logs",
                column: "Id_Usuario",
                principalSchema: "RM557481",
                principalTable: "Usuarios",
                principalColumn: "ID_USUARIO",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Motos_Sensor_IoT_Id_Sensor",
                schema: "RM557481",
                table: "Motos",
                column: "Id_Sensor",
                principalSchema: "RM557481",
                principalTable: "Sensor_IoT",
                principalColumn: "Id_Sensor",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movimentacoes_Motos_Id_Moto",
                schema: "RM557481",
                table: "Movimentacoes",
                column: "Id_Moto",
                principalSchema: "RM557481",
                principalTable: "Motos",
                principalColumn: "Id_Moto",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movimentacoes_Operadores_Id_Operador",
                schema: "RM557481",
                table: "Movimentacoes",
                column: "Id_Operador",
                principalSchema: "RM557481",
                principalTable: "Operadores",
                principalColumn: "Id_Operador",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movimentacoes_VagasEstacionamento_Id_Vaga",
                schema: "RM557481",
                table: "Movimentacoes",
                column: "Id_Vaga",
                principalSchema: "RM557481",
                principalTable: "VagasEstacionamento",
                principalColumn: "Id_Vaga",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VagasEstacionamento_Filiais_Id_Filial",
                schema: "RM557481",
                table: "VagasEstacionamento",
                column: "Id_Filial",
                principalSchema: "RM557481",
                principalTable: "Filiais",
                principalColumn: "Id_Filial",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VagasEstacionamento_StatusVagas_Id_Status",
                schema: "RM557481",
                table: "VagasEstacionamento",
                column: "Id_Status",
                principalSchema: "RM557481",
                principalTable: "StatusVagas",
                principalColumn: "Id_Status",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Usuarios_Id_Usuario",
                schema: "RM557481",
                table: "Logs");

            migrationBuilder.DropForeignKey(
                name: "FK_Motos_Sensor_IoT_Id_Sensor",
                schema: "RM557481",
                table: "Motos");

            migrationBuilder.DropForeignKey(
                name: "FK_Movimentacoes_Motos_Id_Moto",
                schema: "RM557481",
                table: "Movimentacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Movimentacoes_Operadores_Id_Operador",
                schema: "RM557481",
                table: "Movimentacoes");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Usuarios_Id_Usuario",
                schema: "RM557481",
                table: "Logs",
                column: "Id_Usuario",
                principalSchema: "RM557481",
                principalTable: "Usuarios",
                principalColumn: "ID_USUARIO",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Motos_Sensor_IoT_Id_Sensor",
                schema: "RM557481",
                table: "Motos",
                column: "Id_Sensor",
                principalSchema: "RM557481",
                principalTable: "Sensor_IoT",
                principalColumn: "Id_Sensor");

            migrationBuilder.AddForeignKey(
                name: "FK_Movimentacoes_Motos_Id_Moto",
                schema: "RM557481",
                table: "Movimentacoes",
                column: "Id_Moto",
                principalSchema: "RM557481",
                principalTable: "Motos",
                principalColumn: "Id_Moto",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movimentacoes_Operadores_Id_Operador",
                schema: "RM557481",
                table: "Movimentacoes",
                column: "Id_Operador",
                principalSchema: "RM557481",
                principalTable: "Operadores",
                principalColumn: "Id_Operador",
                onDelete: ReferentialAction.Cascade);

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
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mottu.Migrations
{
    /// <inheritdoc />
    public partial class AddSensorIoTMapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motos_Sensores_Id_Sensor",
                schema: "RM557481",
                table: "Motos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sensores",
                schema: "RM557481",
                table: "Sensores");

            migrationBuilder.RenameTable(
                name: "Sensores",
                schema: "RM557481",
                newName: "Sensor_IoT",
                newSchema: "RM557481");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sensor_IoT",
                schema: "RM557481",
                table: "Sensor_IoT",
                column: "Id_Sensor");

            migrationBuilder.AddForeignKey(
                name: "FK_Motos_Sensor_IoT_Id_Sensor",
                schema: "RM557481",
                table: "Motos",
                column: "Id_Sensor",
                principalSchema: "RM557481",
                principalTable: "Sensor_IoT",
                principalColumn: "Id_Sensor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motos_Sensor_IoT_Id_Sensor",
                schema: "RM557481",
                table: "Motos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sensor_IoT",
                schema: "RM557481",
                table: "Sensor_IoT");

            migrationBuilder.RenameTable(
                name: "Sensor_IoT",
                schema: "RM557481",
                newName: "Sensores",
                newSchema: "RM557481");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sensores",
                schema: "RM557481",
                table: "Sensores",
                column: "Id_Sensor");

            migrationBuilder.AddForeignKey(
                name: "FK_Motos_Sensores_Id_Sensor",
                schema: "RM557481",
                table: "Motos",
                column: "Id_Sensor",
                principalSchema: "RM557481",
                principalTable: "Sensores",
                principalColumn: "Id_Sensor");
        }
    }
}

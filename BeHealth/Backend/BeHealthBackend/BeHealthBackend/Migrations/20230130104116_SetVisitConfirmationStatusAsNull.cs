using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeHealthBackend.Migrations
{
    public partial class SetVisitConfirmationStatusAsNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Confirmed",
                table: "Visit",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.UpdateData(
                table: "Visit",
                keyColumn: "Id",
                keyValue: -4,
                column: "Confirmed",
                value: null);

            migrationBuilder.UpdateData(
                table: "Visit",
                keyColumn: "Id",
                keyValue: -3,
                column: "Confirmed",
                value: null);

            migrationBuilder.UpdateData(
                table: "Visit",
                keyColumn: "Id",
                keyValue: -2,
                column: "Confirmed",
                value: null);

            migrationBuilder.UpdateData(
                table: "Visit",
                keyColumn: "Id",
                keyValue: -1,
                column: "Confirmed",
                value: null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Confirmed",
                table: "Visit",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Visit",
                keyColumn: "Id",
                keyValue: -4,
                column: "Confirmed",
                value: false);

            migrationBuilder.UpdateData(
                table: "Visit",
                keyColumn: "Id",
                keyValue: -3,
                column: "Confirmed",
                value: false);

            migrationBuilder.UpdateData(
                table: "Visit",
                keyColumn: "Id",
                keyValue: -2,
                column: "Confirmed",
                value: false);

            migrationBuilder.UpdateData(
                table: "Visit",
                keyColumn: "Id",
                keyValue: -1,
                column: "Confirmed",
                value: false);
        }
    }
}

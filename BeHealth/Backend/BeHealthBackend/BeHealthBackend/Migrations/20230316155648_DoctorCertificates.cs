using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeHealthBackend.Migrations
{
    public partial class DoctorCertificates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Certificate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    Filename = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DoctorId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Certificate_Persons_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Certificate_Persons_DoctorId1",
                        column: x => x.DoctorId1,
                        principalTable: "Persons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Certificate_DoctorId",
                table: "Certificate",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificate_DoctorId1",
                table: "Certificate",
                column: "DoctorId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Certificate");
        }
    }
}

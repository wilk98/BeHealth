using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeHealthBackend.Migrations
{
    public partial class inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "varchar(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clinic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clinic_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Specialist = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(9)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctor_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Pesel = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(9)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patient_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClinicDoctor",
                columns: table => new
                {
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClinicId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicDoctor", x => new { x.DoctorId, x.ClinicId });
                    table.ForeignKey(
                        name: "FK_ClinicDoctor_Clinic_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClinicDoctor_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ClinicPatient",
                columns: table => new
                {
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClinicId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicPatient", x => new { x.PatientId, x.ClinicId });
                    table.ForeignKey(
                        name: "FK_ClinicPatient_Clinic_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClinicPatient_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DoctorPatient",
                columns: table => new
                {
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorPatient", x => new { x.PatientId, x.DoctorId });
                    table.ForeignKey(
                        name: "FK_DoctorPatient_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorPatient_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Visit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visit_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Visit_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "PostalCode", "Street" },
                values: new object[,]
                {
                    { new Guid("29d60fbf-2e9d-4cb1-b183-2392378941af"), "Warszawa", "01-401", " ul. Górczewska 82" },
                    { new Guid("3d4f37e9-4d2e-4a86-9b2f-679fcbd103a9"), "Łódź", "91-503", "ul. Górczewska 82" },
                    { new Guid("69d34af1-2911-4721-a9c7-815a3ad63ecd"), "Gdańsk", "80-680", "ul. Nadwiślańska 112" },
                    { new Guid("9030a7cf-dcbc-492a-af58-114be534139c"), "Gdynia", "81-515", "ul. Kasztanowa 113" }
                });

            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "Id", "AddressId", "Email", "FirstName", "LastName", "PhoneNumber", "Specialist" },
                values: new object[] { new Guid("25a4cbb5-b31c-40b6-a536-396abdc1833d"), new Guid("9030a7cf-dcbc-492a-af58-114be534139c"), "EugeniuszKaminski@dayrep.com", "Eugeniusz", "Kamiński", "519439105", 9 });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "Id", "AddressId", "Email", "FirstName", "LastName", "Pesel", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("1ef9d268-e925-483d-b854-6ed17ba81f81"), new Guid("69d34af1-2911-4721-a9c7-815a3ad63ecd"), "AdelajdaZielinska@teleworm.us", "Adelajda", "Zielinska", 380923623, "692435107" },
                    { new Guid("2f9343e6-667c-4f86-9f10-86019aed7c62"), new Guid("3d4f37e9-4d2e-4a86-9b2f-679fcbd103a9"), "JakubGrabowski@rhyta.com", "Jakub", "Grabowski", 500501563, "531556254" },
                    { new Guid("a3fbe5f5-11bf-41f2-9aa0-578720514df3"), new Guid("29d60fbf-2e9d-4cb1-b183-2392378941af"), "WitoldKwiatkowski@armyspy.com", "Witołd", "Kwiatkowski", 990819957, "784251125    " }
                });

            migrationBuilder.InsertData(
                table: "Visit",
                columns: new[] { "Id", "DoctorId", "Duration", "Name", "PatientId", "VisitDate" },
                values: new object[,]
                {
                    { -4, new Guid("25a4cbb5-b31c-40b6-a536-396abdc1833d"), 60, "Terapia Orthokine", new Guid("1ef9d268-e925-483d-b854-6ed17ba81f81"), new DateTime(2023, 1, 2, 12, 30, 0, 0, DateTimeKind.Utc) },
                    { -3, new Guid("25a4cbb5-b31c-40b6-a536-396abdc1833d"), 45, "Terapia osoczem bogatym w czynniki wzrostu- PRP", new Guid("2f9343e6-667c-4f86-9f10-86019aed7c62"), new DateTime(2023, 1, 1, 13, 30, 0, 0, DateTimeKind.Utc) },
                    { -2, new Guid("25a4cbb5-b31c-40b6-a536-396abdc1833d"), 60, "Konsultacja reumatologiczna", new Guid("a3fbe5f5-11bf-41f2-9aa0-578720514df3"), new DateTime(2023, 1, 1, 12, 10, 0, 0, DateTimeKind.Utc) },
                    { -1, new Guid("25a4cbb5-b31c-40b6-a536-396abdc1833d"), 65, "Konsultacja ortopedyczna + USG", new Guid("1ef9d268-e925-483d-b854-6ed17ba81f81"), new DateTime(2023, 1, 1, 11, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clinic_AddressId",
                table: "Clinic",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClinicDoctor_ClinicId",
                table: "ClinicDoctor",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicPatient_ClinicId",
                table: "ClinicPatient",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_AddressId",
                table: "Doctor",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DoctorPatient_DoctorId",
                table: "DoctorPatient",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_AddressId",
                table: "Patient",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Visit_DoctorId",
                table: "Visit",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Visit_PatientId",
                table: "Visit",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClinicDoctor");

            migrationBuilder.DropTable(
                name: "ClinicPatient");

            migrationBuilder.DropTable(
                name: "DoctorPatient");

            migrationBuilder.DropTable(
                name: "Visit");

            migrationBuilder.DropTable(
                name: "Clinic");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}

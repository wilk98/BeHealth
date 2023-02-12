using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeHealthBackend.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: false)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Specialist = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Education = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Services = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Role = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(9)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pesel = table.Column<string>(type: "varchar(11)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(9)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    ClinicId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicDoctor", x => new { x.DoctorId, x.ClinicId });
                    table.ForeignKey(
                        name: "FK_ClinicDoctor_Clinic_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinic",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClinicDoctor_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClinicPatient",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    ClinicId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicPatient", x => new { x.PatientId, x.ClinicId });
                    table.ForeignKey(
                        name: "FK_ClinicPatient_Clinic_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinic",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClinicPatient_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorPatient",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorPatient", x => new { x.PatientId, x.DoctorId });
                    table.ForeignKey(
                        name: "FK_DoctorPatient_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DoctorPatient_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Visit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    VisitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Confirmed = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visit_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Visit_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "PostalCode", "Street" },
                values: new object[,]
                {
                    { 1, "Gdańsk", "80-680", "ul. Nadwiślańska 112" },
                    { 2, "Gdynia", "81-515", "ul. Kasztanowa 113" },
                    { 3, "Warszawa", "01-401", " ul. Górczewska 82" },
                    { 4, "Warszawa", "01-401", " ul. Akacjowa 22" },
                    { 5, "Łódź", "91-503", "ul. Górna 82" }
                });

            migrationBuilder.InsertData(
                table: "Clinic",
                columns: new[] { "Id", "AddressId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, 5, "Zapraszamy", "Klinika Uśmiechu" },
                    { 2, 2, "Lecz się u nas!", "Klinika Zdrowia" }
                });

            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "Id", "AddressId", "Description", "Education", "Email", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "Role", "Services", "Specialist" },
                values: new object[,]
                {
                    { 1, 1, null, null, "EugeniuszKaminski@dayrep.com", "Eugeniusz", "Kamiński", "azxsdcvfrewq", "519439105", 1, null, "Oculist" },
                    { 2, 2, null, null, "SamKaczyński@dayrep.com", "Sam", "Kaczyński", "azxsdbfymhsrewq", "123432567", 1, null, "Cardiologist" }
                });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "Id", "AddressId", "Email", "FirstName", "LastName", "PasswordHash", "Pesel", "PhoneNumber", "Role" },
                values: new object[,]
                {
                    { 1, 1, "AdelajdaZielinska@teleworm.us", "Adelajda", "Zielinska", "azxsdcvfrewqthb", "12345678901", "692435107", 2 },
                    { 2, 2, "WitoldKwiatkowski@armyspy.com", "Witołd", "Kwiatkowski", "azxsdcvfrewq12", "12345678901", "784251125", 2 },
                    { 3, 3, "Wolny23@armyspy.com", "Arni", "Umbala", "azxsdcvfrewqfsa", "12345678901", "879654239", 2 },
                    { 4, 4, "JakubGrabowski@rhyta.com", "Jakub", "Grabowski", "azxsdcvfavssw", "12345678901", "531556254", 2 }
                });

            migrationBuilder.InsertData(
                table: "ClinicDoctor",
                columns: new[] { "ClinicId", "DoctorId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "ClinicPatient",
                columns: new[] { "ClinicId", "PatientId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 3 },
                    { 2, 4 }
                });

            migrationBuilder.InsertData(
                table: "DoctorPatient",
                columns: new[] { "DoctorId", "PatientId" },
                values: new object[] { 2, 4 });

            migrationBuilder.InsertData(
                table: "Visit",
                columns: new[] { "Id", "Confirmed", "DoctorId", "Duration", "Name", "PatientId", "VisitDate" },
                values: new object[,]
                {
                    { 1, null, 1, 65, "Konsultacja ortopedyczna + USG", 1, new DateTime(2023, 1, 1, 11, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, null, 1, 60, "Konsultacja reumatologiczna", 1, new DateTime(2023, 1, 1, 12, 10, 0, 0, DateTimeKind.Utc) },
                    { 3, null, 1, 45, "Terapia osoczem bogatym w czynniki wzrostu- PRP", 2, new DateTime(2023, 1, 1, 13, 30, 0, 0, DateTimeKind.Utc) },
                    { 4, null, 1, 60, "Terapia Orthokine", 3, new DateTime(2023, 1, 2, 12, 30, 0, 0, DateTimeKind.Utc) }
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

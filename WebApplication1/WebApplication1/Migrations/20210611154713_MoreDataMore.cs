using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class MoreDataMore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "IdDoctor", "Email", "FirstName", "LastName" },
                values: new object[] { 3, "bigosek@gmail.com", "Leon", "Spater" });

            migrationBuilder.InsertData(
                table: "Medicaments",
                columns: new[] { "IdMedicament", "Description", "Name", "Type" },
                values: new object[,]
                {
                    { 3, "Mocny przeciwbólowy i przeciwzapalny", "DIPHROPOS", "Steryd" },
                    { 4, "Nitro dla facetów", "VIAGRA", "Wzmacniający" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "IdPatient", "Birthdate", "FirstName", "LastName" },
                values: new object[] { 3, new DateTime(1965, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marek", "Zieliński" });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "IdPerscription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[] { 2, new DateTime(2021, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1 });

            migrationBuilder.InsertData(
                table: "PrescriptionsWithMedicaments",
                columns: new[] { "IdMedicament", "IdPrescription", "Details", "Dose" },
                values: new object[] { 2, 1, "3x/dzień", 3 });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "IdPerscription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[] { 3, new DateTime(2021, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2 });

            migrationBuilder.InsertData(
                table: "PrescriptionsWithMedicaments",
                columns: new[] { "IdMedicament", "IdPrescription", "Details", "Dose" },
                values: new object[] { 4, 1, "Tylko w nagłych przypadkach", 1 });

            migrationBuilder.InsertData(
                table: "PrescriptionsWithMedicaments",
                columns: new[] { "IdMedicament", "IdPrescription", "Details", "Dose" },
                values: new object[] { 3, 2, "Regularnie i do końca życia", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "IdPerscription",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PrescriptionsWithMedicaments",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "PrescriptionsWithMedicaments",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "PrescriptionsWithMedicaments",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "IdPerscription",
                keyValue: 2);
        }
    }
}

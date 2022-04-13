using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientService.Migrations
{
    public partial class UpdateTable_PatientApoointment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsComplete",
                table: "PatientAppointment",
                newName: "IsCompleted");

            migrationBuilder.AddColumn<string>(
                name: "BloodGroup",
                table: "PatientAppointment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DiagnosisDetails",
                table: "PatientAppointment",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BloodGroup",
                table: "PatientAppointment");

            migrationBuilder.DropColumn(
                name: "DiagnosisDetails",
                table: "PatientAppointment");

            migrationBuilder.RenameColumn(
                name: "IsCompleted",
                table: "PatientAppointment",
                newName: "IsComplete");
        }
    }
}

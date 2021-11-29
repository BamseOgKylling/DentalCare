using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalCare.Migrations
{
    public partial class AddUniqueIndexToSSN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Patients_SSN",
                table: "Patients",
                column: "SSN",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Patients_SSN",
                table: "Patients");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace RakicDental.Migrations
{
    public partial class addingSpecializations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Specialization",
                table: "Dentists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Dentists",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "LastName", "Specialization" },
                values: new object[] { "Rakić", "Oralni hirurg" });

            migrationBuilder.UpdateData(
                table: "Dentists",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "LastName", "Specialization" },
                values: new object[] { "Rakić", "Protetičar" });

            migrationBuilder.UpdateData(
                table: "Dentists",
                keyColumn: "Id",
                keyValue: 3,
                column: "Specialization",
                value: "Ortodont");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Specialization",
                table: "Dentists");

            migrationBuilder.UpdateData(
                table: "Dentists",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastName",
                value: "Rakic");

            migrationBuilder.UpdateData(
                table: "Dentists",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastName",
                value: "Rakic");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tickets.DL.Migrations
{
    public partial class newdblab : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "developers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "developers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "developers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "developers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "developers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "ai" },
                    { 2, "os" },
                    { 3, "pd" },
                    { 4, "sa" },
                    { 5, "os" }
                });

            migrationBuilder.InsertData(
                table: "developers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "ali" },
                    { 2, "ahmed" },
                    { 3, "sara" },
                    { 4, "aya" },
                    { 5, "alyaa" }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "DepartmentId", "Description", "Title" },
                values: new object[,]
                {
                    { 1, 1, "ticket discription", "ticket title" },
                    { 2, 2, "ticket discription", "ticket title" },
                    { 3, 3, "ticket discription", "ticket title" },
                    { 4, 4, "ticket discription", "ticket title" },
                    { 5, 5, "ticket discription", "ticket title" }
                });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class seedingDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Brokers",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Marwan" },
                    { 2, "George" },
                    { 3, "Youssef" },
                    { 4, "Nadim" },
                    { 5, "Begad" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ID", "BrokerID", "Name" },
                values: new object[,]
                {
                    { 1, 2, "Mario" },
                    { 2, 2, "Mark" },
                    { 3, 4, "Ali" },
                    { 4, 3, "Fady" },
                    { 5, 3, "Tarek" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brokers",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Brokers",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Brokers",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Brokers",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Brokers",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ID",
                keyValue: 5);
        }
    }
}

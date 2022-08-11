using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class ForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Orders_BrokerID",
                table: "Orders",
                column: "BrokerID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientID",
                table: "Orders",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StockID",
                table: "Orders",
                column: "StockID");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_BrokerID",
                table: "Clients",
                column: "BrokerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Brokers_BrokerID",
                table: "Clients",
                column: "BrokerID",
                principalTable: "Brokers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Brokers_BrokerID",
                table: "Orders",
                column: "BrokerID",
                principalTable: "Brokers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Clients_ClientID",
                table: "Orders",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Stocks_StockID",
                table: "Orders",
                column: "StockID",
                principalTable: "Stocks",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Brokers_BrokerID",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Brokers_BrokerID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Clients_ClientID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Stocks_StockID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_BrokerID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ClientID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_StockID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Clients_BrokerID",
                table: "Clients");
        }
    }
}

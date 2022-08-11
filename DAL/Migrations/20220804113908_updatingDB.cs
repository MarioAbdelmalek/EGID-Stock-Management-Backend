using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class updatingDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Brokers_BrokerID",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Brokers_BrokerID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Clients_PersonID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_BrokerID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PersonID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Clients_BrokerID",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "PersonID",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "BrokerID",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClientID",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "BrokerID",
                table: "Clients",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientID",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "BrokerID",
                table: "Orders",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "PersonID",
                table: "Orders",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BrokerID",
                table: "Clients",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BrokerID",
                table: "Orders",
                column: "BrokerID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PersonID",
                table: "Orders",
                column: "PersonID");

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
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Brokers_BrokerID",
                table: "Orders",
                column: "BrokerID",
                principalTable: "Brokers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Clients_PersonID",
                table: "Orders",
                column: "PersonID",
                principalTable: "Clients",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

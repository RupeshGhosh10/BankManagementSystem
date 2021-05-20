using Microsoft.EntityFrameworkCore.Migrations;

namespace BankManagementSystem.Data.Migrations
{
    public partial class BankAcount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BankAccountType",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Deposit",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IdentificationDocumentNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IdentificationProofType",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "BankAccountId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BankAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankAccountType = table.Column<int>(type: "int", nullable: false),
                    Deposit = table.Column<double>(type: "float", nullable: false),
                    IdentificationProofType = table.Column<int>(type: "int", nullable: false),
                    IdentificationDocumentNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NomineeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NomineeAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BankAccountId",
                table: "AspNetUsers",
                column: "BankAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_BankAccounts_BankAccountId",
                table: "AspNetUsers",
                column: "BankAccountId",
                principalTable: "BankAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_BankAccounts_BankAccountId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "BankAccounts");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_BankAccountId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BankAccountId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "BankAccountType",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Deposit",
                table: "AspNetUsers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "IdentificationDocumentNumber",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IdentificationProofType",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

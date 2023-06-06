using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Automated_Voting_System.Migrations
{
    /// <inheritdoc />
    public partial class someMOdfications2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Address_AddressId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_AddressId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Person");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Person",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Person_AddressId",
                table: "Person",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Address_AddressId",
                table: "Person",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

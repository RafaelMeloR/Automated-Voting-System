using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Automated_Voting_System.Migrations
{
    /// <inheritdoc />
    public partial class someMOdfications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_AspNetUsers_UserId1",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_UserId1",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Person");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Person",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Person_UserId",
                table: "Person",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_AspNetUsers_UserId",
                table: "Person",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_AspNetUsers_UserId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_UserId",
                table: "Person");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Person",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Person",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_UserId1",
                table: "Person",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_AspNetUsers_UserId1",
                table: "Person",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}

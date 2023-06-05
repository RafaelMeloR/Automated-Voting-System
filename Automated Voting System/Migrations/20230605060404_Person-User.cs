using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Automated_Voting_System.Migrations
{
    /// <inheritdoc />
    public partial class PersonUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Person",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_AspNetUsers_UserId1",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_UserId1",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Person");
        }
    }
}

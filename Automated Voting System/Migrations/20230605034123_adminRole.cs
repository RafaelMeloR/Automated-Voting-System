using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Automated_Voting_System.Migrations
{
    /// <inheritdoc />
    public partial class adminRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            IF NOT EXISTS(select Id from AspNetRoles where Id='58317e6c-2ff5-41e7-b0e4-dcab6d2e6302')
            BEGIN
            insert AspNetRoles(Id,Name,NormalizedName) Values('58317e6c-2ff5-41e7-b0e4-dcab6d2e6302','admin','ADMIN')
            END
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE AspNetRoles where Id='58317e6c-2ff5-41e7-b0e4-dcab6d2e6302'");
        }
    }
}

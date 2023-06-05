using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Automated_Voting_System.Migrations
{
    /// <inheritdoc />
    public partial class politicalPartiesRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            IF NOT EXISTS(select Id from AspNetRoles where Id='aad7e709-77a3-489a-98e1-a4e768a8d5a7')
            BEGIN
            insert AspNetRoles(Id,Name,NormalizedName) Values('aad7e709-77a3-489a-98e1-a4e768a8d5a7','politicalParties','POLITICALPARITES')
            END
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE AspNetRoles where Id='aad7e709-77a3-489a-98e1-a4e768a8d5a7'");
        }
    }
}

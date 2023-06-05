using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Automated_Voting_System.Migrations
{
    /// <inheritdoc />
    public partial class candidatesRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            IF NOT EXISTS(select Id from AspNetRoles where Id='2c24aa6e-a96a-40d1-a80a-78554d91a32a')
            BEGIN
            insert AspNetRoles(Id,Name,NormalizedName) Values('2c24aa6e-a96a-40d1-a80a-78554d91a32a','candidates','CANDIDATES')
            END
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE AspNetRoles where Id='2c24aa6e-a96a-40d1-a80a-78554d91a32a'");
        }
    }
}

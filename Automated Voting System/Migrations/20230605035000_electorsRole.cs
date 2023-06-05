using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Automated_Voting_System.Migrations
{
    /// <inheritdoc />
    public partial class electorsRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            IF NOT EXISTS(select Id from AspNetRoles where Id='db7f676a-dc84-4518-a35a-c9d14d3ccadb')
            BEGIN
            insert AspNetRoles(Id,Name,NormalizedName) Values('db7f676a-dc84-4518-a35a-c9d14d3ccadb','electors','ELECTORS')
            END
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE AspNetRoles where Id='db7f676a-dc84-4518-a35a-c9d14d3ccadb'");
        }
    }
}

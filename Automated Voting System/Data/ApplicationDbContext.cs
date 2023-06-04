using Automated_Voting_System.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Automated_Voting_System.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Person> Person { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Candidate> Candidate { get; set; }
        public DbSet<Elector> Elector { get; set; }
        public DbSet<PoliticalParty> PoliticalParty { get; set; }
    }
}

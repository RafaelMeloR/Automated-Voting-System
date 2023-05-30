using Automated_Voting_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Automated_Voting_System.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Person> Person { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Candidate> Candidate { get; set; }
        public DbSet<Elector> Elector { get; set; }
        public DbSet<PoliticalParty> PoliticalParty { get; set; }
    }
}
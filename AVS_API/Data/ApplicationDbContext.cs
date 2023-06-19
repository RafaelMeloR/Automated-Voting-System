using AVS_API.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;


namespace AVS_API.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base()
        {
        }
        public DbSet<Person> Person { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Candidate> Candidate { get; set; }
        public DbSet<Elector> Elector { get; set; }
        public DbSet<PoliticalParty> PoliticalParty { get; set; }
    }
}

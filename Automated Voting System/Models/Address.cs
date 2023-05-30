using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Automated_Voting_System.Models
{
    public class Address
    {
        public int Id { get; set; }
        int CivicNumber { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        [Unicode]
        [StringLength(6)]
        public string Thoroughfare { get; set; }
        [Required]
        [StringLength(50)]
        public string ApartmentNumber { get; set; }
        [Required]
        [Unicode]
        [StringLength(10)]
        public string City { get; set; }
        [Required]
        public int PersonId { get; set; }
        [Required]
        public List<Person> Person { get; set; }
    }
}

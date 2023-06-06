using Automated_Voting_System.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Automated_Voting_System.Models
{
    public class SignUpViewModeleMore
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        [StringLength(50)]
        [Required]
        public string LastName { get; set; }
        [StringLength(50)]
        [Required]
        public string MarriedName { get; set; }
        public string Gender { get; set; }
        [StringLength(20)]
        [Required]
        public DateTime bornDate { get; set; }
        [Required]
        public string Email { get; set; }
        [StringLength(50)]
        public int Phone { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public bool isActive { get; set; }
        public int UserId { get; set; }
        public IdentityUser User { get; set; }
    }
}

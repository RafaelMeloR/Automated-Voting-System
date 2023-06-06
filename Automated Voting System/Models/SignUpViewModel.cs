using Automated_Voting_System.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Automated_Voting_System.Models
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage = "Field {0} is Required")]
        [EmailAddress(ErrorMessage = "Must be a valid email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Field {0} is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /****/
         
        public string Name { get; set; } 
        public string LastName { get; set; } 
        public string MarriedName { get; set; }
        public string Gender { get; set; } 
        public DateTime bornDate { get; set; } 
        public int Phone { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public bool isActive { get; set; }
        public int UserId { get; set; }
        public IdentityUser User { get; set; }

        /****/
         
        int CivicNumber { get; set; } 
        public string PostalCode { get; set; } 
        public string Thoroughfare { get; set; } 
        public string ApartmentNumber { get; set; } 
        public string City { get; set; } 
        public int PersonId { get; set; } 
        public List<Person> Person { get; set; }
    }
}

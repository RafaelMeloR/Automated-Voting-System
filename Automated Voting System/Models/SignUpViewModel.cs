using Automated_Voting_System.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        //----------------Person
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    
        public string Name { get; set; }
    
        public string LastName { get; set; }
        public int Phone { get; set; }
        public string Gender { get; set; }
        public string MarriedName { get; set; }
    
        public DateTime bornDate { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressId { get; set; }
        public bool isActive { get; set; }
        public string UserId { get; set; } 

        //----------------Address
         
      
        public string PostalCode { get; set; }
     
        public string Thoroughfare { get; set; }
      
        public string ApartmentNumber { get; set; }
   
        public string City { get; set; }

        public int PersonId { get; set; }

        //------Role

        public string role { get; set; }

    }
}

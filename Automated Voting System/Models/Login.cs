using System.ComponentModel.DataAnnotations;

namespace Automated_Voting_System.Models
{
    public class Login
    {
        [Required(ErrorMessage ="Field {0} is Required")]
        [EmailAddress(ErrorMessage ="Must be a valid email address")]
        public String Email { get; set; }
        [Required(ErrorMessage = "Field {0} is Required")]
        [DataType(DataType.Password)]
        public String Password { get; set; }
        public DateTime LastLogin { get; set; }

    }
}

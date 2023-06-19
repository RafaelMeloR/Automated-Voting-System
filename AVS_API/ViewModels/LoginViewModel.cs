using System.ComponentModel.DataAnnotations;

namespace AVS_API.ViewModels
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "Field {0} is Required")]
        [EmailAddress(ErrorMessage = "Must be a valid email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Field {0} is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember me")]
        public bool rememberMe { get; set; }

    }
}

﻿using System.ComponentModel.DataAnnotations;

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
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace AVS_Desktop.Models
{ 
    public class Person
    {
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
        public bool isActive { get; set; }
        public string UserId { get; set; } 
        public string ProfilePhoto { get; set; }

    }
}

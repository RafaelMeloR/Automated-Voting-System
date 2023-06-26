using System;
using System.ComponentModel.DataAnnotations;

namespace AVS_API.Models
{ 
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string LastName { get; set; } 
        public string MarriedName { get; set; }
        public string Gender { get; set; } 
        public DateTime bornDate { get; set; } 
        public string Email { get; set; } 
        public string Phone { get; set; } 
        public bool isActive { get; set; }
        public string UserId { get; set; } 
        public string ProfilePhoto { get; set; }

    }
}

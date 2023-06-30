using AVS_Desktop.Models;
using System;
using System.Diagnostics.CodeAnalysis;

namespace AVS_Desktop.ViewModels
{
    public class ElectorViewModel
    {
        public int IdPerson { get; set; }
        public string Name { get; set; } 
        public string LastName { get; set; } 
        public string Gender { get; set; } 
        public DateTime bornDate { get; set; } 
        public string Email { get; set; } 
        public string Phone { get; set; } 
        public bool isActive { get; set; }
        public string UserId { get; set; } 
        public string UserName { get; set; } 
        public string ProfilePhoto { get; set; }
        public string idElector { get; set; } 
        public string ElectoralMunicipality { get; set; }
        public string ElectoralDistrict { get; set; }
        public bool isActiveElector { get; set; }  
        public int PersonId { get; set; } 
        public int IdAddress { get; set; }
        int CivicNumber { get; set; }
        public string PostalCode { get; set; }
        public string Thoroughfare { get; set; }
        public string ApartmentNumber { get; set; }
        public string City { get; set; } 

    }
}

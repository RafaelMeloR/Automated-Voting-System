using AVS_Desktop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVS_Desktop.ViewModels
{
    internal class CandidateViewModel
    {
        public int IdPerson { get; set; }
        public string Name { get; set; } 
        public string LastName { get; set; } 
        public string Gender { get; set; } 
        public DateTime bornDate { get; set; } 
        public string Email { get; set; } 
        public int Phone { get; set; } 
        public bool isActive { get; set; }
        public string UserId { get; set; } 
        public string UserName { get; set; }
        [AllowNull] 
        public string ProfilePhoto { get; set; }
        public Guid IdCandidate { get; set; }
        public int PoliticalPartyId { get; set; }
        public PoliticalParty PoliticalParty { get; set; }
        public string ElectoralPosition { get; set; }
        public string ElectoralMunicipality { get; set; }
        public string ElectoralDistrict { get; set; }
        public bool isActiveCandidate { get; set; } 
        public string NamePoliticalParty { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; } 
        public int IdAddress { get; set; }
        int CivicNumber { get; set; }
        public string PostalCode { get; set; }
        public string Thoroughfare { get; set; }
        public string ApartmentNumber { get; set; }
        public string City { get; set; } 

    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace AVS_API.Models
{
    public class Candidate
    {
        public Guid Id { get; set; }
        public int PoliticalPartyId { get; set; } 
        public string ElectoralPosition { get; set; } 
        public string ElectoralMunicipality { get; set; } 
        public string ElectoralDistrict { get; set; } 
        public bool isActive { get; set; } 
        public int PersonId { get; set; } 
    }
}

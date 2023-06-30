using System;
using System.ComponentModel.DataAnnotations;

namespace AVS_API.Models
{ 
    public class Elector
    {
        public String id { get; set; }
        public int PersonId { get; set; }
        public string ElectoralMunicipality { get; set; } 
        public string ElectoralDistrict { get; set; } 
        public bool isActive { get; set; }

    }
}

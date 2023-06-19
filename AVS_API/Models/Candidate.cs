using System.ComponentModel.DataAnnotations;

namespace AVS_API.Models
{
    public class Candidate
    {
        public Guid Id { get; set; }
        public int PoliticalPartyId { get; set; }
        public PoliticalParty PoliticalParty { get; set; }
        public string ElectoralPosition { get; set; }
        [Required]
        public string ElectoralMunicipality { get; set; }
        [Required]
        public string ElectoralDistrict { get; set; }
        [Required]
        public bool isActive { get; set; }
        [Required]
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}

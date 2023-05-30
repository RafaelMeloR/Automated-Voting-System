using System.ComponentModel.DataAnnotations;

namespace Automated_Voting_System.Models
{
    public class Elector
    {
        public Guid id { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public string ElectoralMunicipality { get; set; }
        [Required]
        public string ElectoralDistrict { get; set; }
        [Required]
        public bool isActive { get; set; }

    }
}

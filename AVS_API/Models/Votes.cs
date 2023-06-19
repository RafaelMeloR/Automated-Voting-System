using System.ComponentModel.DataAnnotations;

namespace AVS_API.Models
{
    public class Votes
    {
        [Required]
        public Guid id { get; set; }
        [Required]
        public Guid ElectorId { get; set; }
        [Required]
        public Elector Elector { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public bool vote { get; set; }

    }
}

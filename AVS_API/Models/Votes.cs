using System;
using System.ComponentModel.DataAnnotations;

namespace AVS_API.Models
{
    public class Votes
    { 
        public Guid id { get; set; } 
        public Guid ElectorId { get; set; } 
        public Elector Elector { get; set; } 
        public DateTime Date { get; set; }
        public bool vote { get; set; }

    }
}

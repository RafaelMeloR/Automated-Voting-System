using System.ComponentModel.DataAnnotations.Schema;

namespace AVS_API.Models
{
    public class Address
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        int CivicNumber { get; set; }
        public string PostalCode { get; set; }
        public string Thoroughfare { get; set; }
        public string ApartmentNumber { get; set; }
        public string City { get; set; }
        public int PersonId { get; set; }
        /* [Required]
        
         [Required]
         public List<Person> Person { get; set; }*/
    }
}

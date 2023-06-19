using AVS_API.ViewModels;

namespace AVS_API.Models
{
    public class PersonResponse
    {
        public int statusCode { get; set; }
        public string statusMessage { get; set; }

        public Person person { get; set; }
        public List<Person> people { get; set; }

        public personViewModel users { get; set; }

        
    }
}

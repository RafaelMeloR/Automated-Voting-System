using AVS_API.ViewModels;

namespace AVS_API.Models.response
{
    public class PersonResponse
    {
        public int statusCode { get; set; }
        public string statusMessage { get; set; }

        public PersonViewModel person { get; set; }
        public List<PersonViewModel> people { get; set; }

        public PersonViewModel users { get; set; }

        public Person personM { get; set; }
        public List<Person> peopleM { get; set; }


    }
}

using AVS_Desktop.ViewModels;
using System.Collections.Generic;

namespace AVS_Desktop.Models.response
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

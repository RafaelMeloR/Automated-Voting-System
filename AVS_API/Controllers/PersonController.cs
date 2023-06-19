using AVS_API.Models;
using AVS_API.ViewModels;
using Azure;
using Microsoft.AspNetCore.Mvc; 

namespace AVS_API.Controllers
{
    public class PersonController : ControllerBase
    {


       
        private readonly IConfiguration _configuration;
        public PersonController(IConfiguration configuration) 
        {
            this._configuration = configuration;
        }

        [HttpGet]
        [Route("GetAllPeople")]
        public PersonResponse GetAllPeople()
        {
            PersonResponse response = new PersonResponse();
            PersonApplication app = new PersonApplication();
            response =  app.GetAllPeople();
            return response;
        }

        [HttpGet]
        [Route("GetPersonById/{id}")]
        public PersonResponse GetPersonById(int id)
        {
            PersonResponse response = new PersonResponse();
            PersonApplication app = new PersonApplication();
            response = app.GetPersonById(id);
            return response;
        }

        [HttpPost]
        [Route("AddPersonAsync")]
        public Task<PersonResponse> AddPersonAsync(personViewModel person)
        {
            PersonApplication app = new PersonApplication();
            Task<PersonResponse> response = app.AddPersonAsync(person);
            return response;

        }


    }
}

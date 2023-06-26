using AVS_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace AVS_API.Controllers
{
    public class Controller : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public Controller(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        [HttpGet]
        [Route("SelectPeople")]
        public PersonResponse SelectPeople()
        {
            PersonResponse response = new PersonResponse();
            Application app = new Application();
            response = app.SelectPeople();
            return response;
        }

        [HttpGet]
        [Route("SelectPeopleValidation")]
        public PersonResponse SelectPeopleValidation()
        {
            PersonResponse response = new PersonResponse();
            Application app = new Application();
            response = app.SelectPeopleValidation();
            return response;
        }

        [HttpGet]
        [Route("SelectPeopleByNameValidation/{name}")]
        public PersonResponse SelectPeopleByNameValidation(string name)
        {
            PersonResponse response = new PersonResponse();
            Application app = new Application();
            response = app.SelectPeopleByNameValidation(name);
            return response;
        }

        [HttpGet]
        [Route("SelectPeopleByName/{name}")]
        public PersonResponse SelectPeopleByName(string name)
        {
            PersonResponse response = new PersonResponse();
            Application app = new Application();
            response = app.SelectPeopleByName(name);
            return response;
        }

        [HttpGet]
        [Route("SelectIdPersonByUserId/{gui}")]
        public PersonResponse SelectIdPersonByUserId(string gui)
        {
            PersonResponse response = new PersonResponse();
            Application app = new Application();
            response = app.SelectIdPersonByUserId(gui);
            return response;
        }


        [HttpGet]
        [Route("SelectNamePersonById/{id}")]
        public PersonResponse SelectNamePersonById(int id)
        {
            PersonResponse response = new PersonResponse();
            Application app = new Application();
            response = app.SelectNamePersonById(id);
            return response;
        }


        [HttpGet]
        [Route("SelectPersonUserID/{email}")]
        public async Task<PersonResponse> SelectPersonUserID(string email)
        {
            PersonResponse response = new PersonResponse();
            Application app = new Application();
            response = await app.SelectPersonUserID(email);
            return response;
        }

        [HttpGet]
        [Route("SelectRoleIdFromUsers/{email}")]
        public PersonResponse SelectRoleIdFromUsers(string email)
        {
            PersonResponse response = new PersonResponse();
            Application app = new Application();
            response = app.SelectRoleIdFromUsers(email);
            return response;
        }

        [HttpGet]
        [Route("Login/{email}")]
        public PersonResponse Login(string email)
        {
            PersonResponse response = new PersonResponse();
            Application app = new Application();
            response = app.Login(email);
            return response;
        }

        [HttpGet]
        [Route("getLastIdInserted/")]
        public async Task<PersonResponse> getLastIdInserted()
        {
            PersonResponse response = new PersonResponse();
            Application app = new Application();
            response =await app.getLastIdInserted();
            return response;
        }

        [HttpGet]
        [Route("SelectRoleName/{roleId}")]
        public RoleResponse SelectRoleName(string roleId)
        {
            RoleResponse response = new RoleResponse();
            Application app = new Application();
            response = app.SelectRoleName(roleId);
            return response;
        }

        [HttpGet]
        [Route("SelectRoleIdFromRole/{roleName}")]
        public async Task<RoleResponse> SelectRoleIdFromRole(string roleName)
        {
            RoleResponse response = new RoleResponse();
            Application app = new Application();
            response = await app.SelectRoleIdFromRole(roleName);
            return response;
        }

        [HttpGet]
        [Route("selectIdPoliticalPartyByName/{Name}")]
        public PoliticalPartyResponse selectIdPoliticalPartyByName(string Name)
        {
            PoliticalPartyResponse response = new PoliticalPartyResponse();
            Application app = new Application();
            response = app.selectIdPoliticalPartyByName(Name);
            return response;
        }

        [HttpGet]
        [Route("selectPoliticalPartyByName/{Name}")]
        public PoliticalPartyResponse selectPoliticalPartyByName(string Name)
        {
            PoliticalPartyResponse response = new PoliticalPartyResponse();
            Application app = new Application();
            response = app.selectPoliticalPartyByName(Name);
            return response;
        }

        [HttpGet]
        [Route("selectLastIdInsertedPoliticalParty")]
        public PoliticalPartyResponse selectLastIdInsertedPoliticalParty()
        {
            PoliticalPartyResponse response = new PoliticalPartyResponse();
            Application app = new Application();
            response = app.selectLastIdInsertedPoliticalParty();
            return response;
        }

        [HttpGet]
        [Route("selectPoliticalsParties")]
        public PoliticalPartyResponse selectPoliticalsParties()
        {
            PoliticalPartyResponse response = new PoliticalPartyResponse();
            Application app = new Application();
            response = app.selectPoliticalsParties();
            return response;
        }
        // [HttpPost]
        //   [Route("AddPersonAsync")]
        /*public Task<PersonResponse> AddPersonAsync(PersonViewModel person)
        {
            PersonApplication app = new PersonApplication();
           // Task<PersonResponse> response = app.AddPersonAsync(person);
           // return response;

        }*/


    }
}

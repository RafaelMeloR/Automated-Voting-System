using AVS_API.Models;
using AVS_API.Models.response;
using AVS_Desktop.ViewModels; 
using Microsoft.AspNetCore.Mvc;

namespace AVS_API.Controllers
{ 
    [ApiController]
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

        [HttpGet]
        [Route("SelectCandidates")]
        public CandidateResponse SelectCandidates()
        {
            CandidateResponse response = new CandidateResponse();
            Application app = new Application();
            response = app.SelectCandidates();
            return response;
        }

        [HttpGet]
        [Route("SelectCandidateByName/{name}")]
        public CandidateResponse SelectCandidateByName(string name)
        {
            CandidateResponse response = new CandidateResponse();
            Application app = new Application();
            response = app.SelectCandidateByName(name);
            return response;
        }

        [HttpGet]
        [Route("SelectCandidateformation/{personId}")]
        public async Task<CandidateResponse> SelectCandidateformation(int personId)
        {
            CandidateResponse response = new CandidateResponse();
            Application app = new Application();
            response = await app.SelectCandidateformation(personId);
            return response;
        }


        [HttpGet]
        [Route("SelectAllCandidateformation/")]
        public async Task<CandidateResponse> SelectAllCandidateformation()
        {
            CandidateResponse response = new CandidateResponse();
            Application app = new Application();
            response = await app.SelectAllCandidateformation();
            return response;
        }

        [HttpGet]
        [Route("SelectElectors")]
        public ElectorResponse SelectElectors()
        {
            ElectorResponse response = new ElectorResponse();
            Application app = new Application();
            response = app.SelectElectors();
            return response;
        }

        [HttpGet]
        [Route("SelectElectorsByName/{name}")]
        public ElectorResponse SelectElectorsByName(string name)
        {
            ElectorResponse response = new ElectorResponse();
            Application app = new Application();
            response = app.SelectElectorsByName(name);
            return response;
        }

        [HttpGet]
        [Route("SelectElectorInformation/{PersonId}")]
        public ElectorResponse SelectElectorInformation(int PersonId)
        {
            ElectorResponse response = new ElectorResponse();
            Application app = new Application();
            response = app.SelectElectorInformation(PersonId);
            return response;
        }

        [HttpGet]
        [Route("ValidateElector/{guid}")]
        public PoolElectorsResponse ValidateElector(string guid)
        {
            PoolElectorsResponse response = new PoolElectorsResponse();
            Application app = new Application();
            response = app.ValidateElector(guid);
            return response;
        }

        [HttpGet]
        [Route("SelectPoolElector/{hash}")]
        public PoolElectorsResponse SelectPoolElector(string hash)
        {
            PoolElectorsResponse response = new PoolElectorsResponse();
            Application app = new Application();
            response = app.SelectPoolElector(hash);
            return response;
        }


        [HttpGet]
        [Route("SelectAllHashPoolElector/")]
        public PoolElectorsResponse SelectAllHashPoolElector()
        {
            PoolElectorsResponse response = new PoolElectorsResponse();
            Application app = new Application();
            response = app.SelectAllHashPoolElector();
            return response;
        }

        [HttpGet]
        [Route("CountVotes/{candidates}")]
        public CountVotesResponse CountVotes(List<Candidate> candidates)
        {
            CountVotesResponse response = new CountVotesResponse();
            Application app = new Application();
            response = app.CountVotes(candidates);
            return response;
        }

        [HttpGet]
        [Route("SelectPersonByEmail/{email}")]
        public async Task<PersonResponse> SelectPersonByEmail(String email)
        {
            PersonResponse response = new PersonResponse();
            Application app = new Application();
            response = await app.SelectPersonByEmail(email);
            return response;
        }

        [HttpGet]
        [Route("SelectPersonById/{id}")]
        public PersonResponse SelectPersonById(int id)
        {
            PersonResponse response = new PersonResponse();
            Application app = new Application();
            response =  app.SelectPersonById(id);
            return response;
        }

        [HttpPut]
        [Route("Validate")]
        public Task<ValidateResponse> Validate(Validate validate)
        {
            Application apl = new Application();
            Task<ValidateResponse> response = apl.Validate(validate);
            return response;

        }
       

    }
}

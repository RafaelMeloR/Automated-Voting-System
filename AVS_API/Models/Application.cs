using AVS_API.DataAccessLayer;
using AVS_API.Models.response;
using AVS_API.ViewModels;
using AVS_Desktop.ViewModels;
using System.Data;

namespace AVS_API.Models
{
    public class Application
    {
        public PersonResponse SelectPeople()
        {

            DataTable dt = dal.get.SelectPeople();
            PersonResponse response = new PersonResponse();
            List<PersonViewModel> listOfPeople = new List<PersonViewModel>();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PersonViewModel person = new PersonViewModel();
                    person.Id = (int)dt.Rows[i]["Id"];
                    person.Name = (string)dt.Rows[i]["Name"];
                    person.LastName = (string)dt.Rows[i]["LastName"];
                    person.Gender = (string)dt.Rows[i]["Gender"];
                    person.Email = (string)dt.Rows[i]["Email"];
                    person.Phone = dt.Rows[i]["Phone"].ToString();
                    person.Thoroughfare = (string)dt.Rows[i]["Thoroughfare"];
                    person.ApartmentNumber = (string)dt.Rows[i]["ApartmentNumber"];
                    person.PostalCode = (string)dt.Rows[i]["PostalCode"];
                    person.City = (string)dt.Rows[i]["City"];
                    person.UserId = (string)dt.Rows[i]["UserId"];
                    person.RoleId = (string)dt.Rows[i]["RoleId"];
                    person.RoleName = (string)dt.Rows[i]["Name"];

                    listOfPeople.Add(person);
                }

            }


            if (listOfPeople.Count > 0)
            {
                response.statusCode = 200;
                response.statusMessage = "Data retrievable is successful";
                response.people = listOfPeople;
            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "No data retrievable";
                response.people = null;
            }
            return response;
        }

        public PersonResponse SelectPeopleValidation()
        {

            DataTable dt = dal.get.SelectPeopleValidation();
            PersonResponse response = new PersonResponse();
            List<PersonViewModel> listOfPeople = new List<PersonViewModel>();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PersonViewModel person = new PersonViewModel();
                    person.Id = (int)dt.Rows[i]["Id"];
                    person.Name = (string)dt.Rows[i]["Name"];
                    person.LastName = (string)dt.Rows[i]["LastName"];
                    person.Gender = (string)dt.Rows[i]["Gender"];
                    person.Email = (string)dt.Rows[i]["Email"];
                    person.Phone = dt.Rows[i]["Phone"].ToString();
                    person.Thoroughfare = (string)dt.Rows[i]["Thoroughfare"];
                    person.ApartmentNumber = (string)dt.Rows[i]["ApartmentNumber"];
                    person.PostalCode = (string)dt.Rows[i]["PostalCode"];
                    person.City = (string)dt.Rows[i]["City"];
                    person.UserId = (string)dt.Rows[i]["UserId"];
                    person.RoleId = (string)dt.Rows[i]["RoleId"];
                    person.RoleName = (string)dt.Rows[i]["Name"];

                    listOfPeople.Add(person);
                }

            }


            if (listOfPeople.Count > 0)
            {
                response.statusCode = 200;
                response.statusMessage = "Data retrievable is successful";
                response.people = listOfPeople;
            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "No data retrievable";
                response.people = null;
            }
            return response;
        }
        public PersonResponse SelectPeopleByNameValidation(string name)
        {

            DataTable dt = dal.get.SelectPeopleByNameValidation(name);
            PersonResponse response = new PersonResponse();
            List<PersonViewModel> listOfPeople = new List<PersonViewModel>();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PersonViewModel person = new PersonViewModel();
                    person.Id = (int)dt.Rows[i]["Id"];
                    person.Name = (string)dt.Rows[i]["Name"];
                    person.LastName = (string)dt.Rows[i]["LastName"];
                    person.Gender = (string)dt.Rows[i]["Gender"];
                    person.Email = (string)dt.Rows[i]["Email"];
                    person.Phone = dt.Rows[i]["Phone"].ToString();
                    person.Thoroughfare = (string)dt.Rows[i]["Thoroughfare"];
                    person.ApartmentNumber = (string)dt.Rows[i]["ApartmentNumber"];
                    person.PostalCode = (string)dt.Rows[i]["PostalCode"];
                    person.City = (string)dt.Rows[i]["City"];
                    person.UserId = (string)dt.Rows[i]["UserId"];
                    person.RoleId = (string)dt.Rows[i]["RoleId"];
                    person.RoleName = (string)dt.Rows[i]["Name"];

                    listOfPeople.Add(person);
                }

            }


            if (listOfPeople.Count > 0)
            {
                response.statusCode = 200;
                response.statusMessage = "Data retrievable is successful";
                response.people = listOfPeople;
            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "No data retrievable";
                response.people = null;
            }
            return response;
        }
        public PersonResponse SelectPeopleByName(string name)
        {

            DataTable dt = dal.get.SelectPeopleByName(name);
            PersonResponse response = new PersonResponse();
            List<PersonViewModel> listOfPeople = new List<PersonViewModel>();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PersonViewModel person = new PersonViewModel();
                    person.Id = (int)dt.Rows[i]["Id"];
                    person.Name = (string)dt.Rows[i]["Name"];
                    person.LastName = (string)dt.Rows[i]["LastName"];
                    person.Gender = (string)dt.Rows[i]["Gender"];
                    person.Email = (string)dt.Rows[i]["Email"];
                    person.Phone = dt.Rows[i]["Phone"].ToString();
                    person.Thoroughfare = (string)dt.Rows[i]["Thoroughfare"];
                    person.ApartmentNumber = (string)dt.Rows[i]["ApartmentNumber"];
                    person.PostalCode = (string)dt.Rows[i]["PostalCode"];
                    person.City = (string)dt.Rows[i]["City"];
                    person.UserId = (string)dt.Rows[i]["UserId"];
                    person.RoleId = (string)dt.Rows[i]["RoleId"];
                    person.RoleName = (string)dt.Rows[i]["Name"];

                    listOfPeople.Add(person);
                }

            }


            if (listOfPeople.Count > 0)
            {
                response.statusCode = 200;
                response.statusMessage = "Data retrievable is successful";
                response.people = listOfPeople;
            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "No data retrievable";
                response.people = null;
            }
            return response;
        }
        public PersonResponse SelectIdPersonByUserId(string gui)
        {

            PersonResponse response = new PersonResponse();
            int id = dal.get.SelectIdPersonByUserId(gui);

            if (id != 0)
            {
                PersonViewModel person = new PersonViewModel();
                person.Id = id;
                person.UserId = gui;
                response.statusCode = 200;
                response.statusMessage = "Data retrievable is successful";
                response.person = person;
            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "No data retrievable";
            }
            return response;
        }

        public PersonResponse SelectNamePersonById(int id)
        {

            PersonResponse response = new PersonResponse();
            string name = dal.get.SelectNamePersonById(id);

            if (name != string.Empty)
            {
                PersonViewModel person = new PersonViewModel();
                person.Id = id;
                person.Name = name;

                response.statusCode = 200;
                response.statusMessage = "Data retrievable is successful";
                response.person = person;
            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "No data retrievable";
            }
            return response;
        }

        public async Task<PersonResponse> SelectPersonUserID(string email)
        {

            PersonResponse response = new PersonResponse();
            PersonViewModel person =await  dal.get.SelectPersonUserID(email);

            if (person.Id != 0)
            {
                response.statusCode = 200;
                response.statusMessage = "Data retrievable is successful";
                response.person = person;
            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "No data retrievable";
            }
            return response;
        }

        public PersonResponse SelectRoleIdFromUsers(string email)
        {

            PersonResponse response = new PersonResponse();
            PersonViewModel person = dal.get.SelectRoleIdFromUsers(email);

            if (person.RoleId !=null)
            {
                response.statusCode = 200;
                response.statusMessage = "Data retrievable is successful";
                response.person = person;
            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "No data retrievable";
            }
            return response;
        }
        public PersonResponse Login(string user)
        {

            PersonResponse response = new PersonResponse();
            PersonViewModel person = dal.get.Login(user);

            if (person.Pasword != null)
            {
                response.statusCode = 200;
                response.statusMessage = "Data retrievable is successful";
                response.person = person;
            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "No data retrievable";
            }
            return response;
        }

        public async Task<PersonResponse> getLastIdInserted()
        {

            PersonResponse response = new PersonResponse();
            PersonViewModel person = await dal.get.getLastIdInserted();

            if (person.Id != null)
            {
                response.statusCode = 200;
                response.statusMessage = "Data retrievable is successful";
                response.person = person;
            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "No data retrievable";
            }
            return response;
        }

        public RoleResponse SelectRoleName(string roleId)
        {

            RoleResponse response = new RoleResponse();
            Role role = dal.get.SelectRoleName(roleId);

            if (role.Name != null)
            {
                response.statusCode = 200;
                response.statusMessage = "Data retrievable is successful";
                response.role = role;
            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "No data retrievable";
            }
            return response;
        }

        public  async Task<RoleResponse> SelectRoleIdFromRole(string roleName)
        {

            RoleResponse response = new RoleResponse();
            Role role = await dal.get.SelectRoleIdFromRole(roleName);

            if (role.Id != null)
            {
                response.statusCode = 200;
                response.statusMessage = "Data retrievable is successful";
                response.role = role;
            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "No data retrievable";
            }
            return response;
        }

        public PoliticalPartyResponse selectIdPoliticalPartyByName(String name)
        {

            PoliticalPartyResponse response = new PoliticalPartyResponse();
            PoliticalParty RpoliticalParty = dal.get.selectIdPoliticalPartyByName(name);

            if (RpoliticalParty.Id != null)
            {
                response.statusCode = 200;
                response.statusMessage = "Data retrievable is successful";
                response.politicalParty = RpoliticalParty;
            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "No data retrievable";
            }
            return response;
        }

        public PoliticalPartyResponse selectPoliticalPartyByName(String name)
        {

            PoliticalPartyResponse response = new PoliticalPartyResponse();
            DataTable dt = dal.get.selectPoliticalPartyByName(name);
            PoliticalParty politicalParty = null; ;
            List<PoliticalParty> listOfPoliticalParties = new List<PoliticalParty>();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    politicalParty = new PoliticalParty();
                    politicalParty.Name = (string)row[1];
                    politicalParty.Id = (int)row[0];
                    listOfPoliticalParties.Add(politicalParty);
                }
            }
              

            if (listOfPoliticalParties.Count > 0)
            {
                response.statusCode = 200;
                response.statusMessage = "Data retrievable is successful";
                response.politicalParties = listOfPoliticalParties;
            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "No data retrievable";
                response.politicalParties = null;
            }
            return response;
 
        }

        public PoliticalPartyResponse selectLastIdInsertedPoliticalParty()
        {

            PoliticalPartyResponse response = new PoliticalPartyResponse();
            PoliticalParty politicalParty = dal.get.selectLastIdInsertedPoliticalParty();

            if (politicalParty.Id != null)
            {
                response.statusCode = 200;
                response.statusMessage = "Data retrievable is successful";
                response.politicalParty = politicalParty;
            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "No data retrievable";
            }
            return response;
        }

        public PoliticalPartyResponse selectPoliticalsParties()
        {

            PoliticalPartyResponse response = new PoliticalPartyResponse();
            DataTable dt = dal.get.selectPoliticalsParties();
            PoliticalParty politicalParty = null; ;
            List<PoliticalParty> listOfPoliticalParties = new List<PoliticalParty>();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    politicalParty = new PoliticalParty();
                    politicalParty.Name = (string)row[1];
                    politicalParty.Id = (int)row[0];
                    listOfPoliticalParties.Add(politicalParty);
                }
            }
             
            if (listOfPoliticalParties.Count > 0)
            {
                response.statusCode = 200;
                response.statusMessage = "Data retrievable is successful";
                response.politicalParties = listOfPoliticalParties;
            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "No data retrievable";
                response.politicalParties = null;
            }
            return response;

        }

        public CandidateResponse SelectCandidates()
        {

            DataTable dt = dal.get.SelectCandidates();
            CandidateResponse response = new CandidateResponse();
            List<CandidateViewModel> listofCandidates = new List<CandidateViewModel>();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CandidateViewModel candidate = new CandidateViewModel();
                    candidate.IdPerson = (int)dt.Rows[i]["Id"];
                    candidate.Name = (string)dt.Rows[i]["Name"];
                    candidate.LastName = (string)dt.Rows[i]["LastName"];
                    candidate.Gender = (string)dt.Rows[i]["Gender"];
                    candidate.Email = (string)dt.Rows[i]["Email"];
                    candidate.Phone = dt.Rows[i]["Phone"].ToString();
                    candidate.Thoroughfare = (string)dt.Rows[i]["Thoroughfare"];
                    candidate.ApartmentNumber = (string)dt.Rows[i]["ApartmentNumber"];
                    candidate.PostalCode = (string)dt.Rows[i]["PostalCode"];
                    candidate.City = (string)dt.Rows[i]["City"];
                    candidate.UserId = (string)dt.Rows[i]["UserId"];
                    candidate.ProfilePhoto = (string)dt.Rows[i]["ProfilePhoto"];
                    candidate.PostalCode = (string)dt.Rows[i]["PostalCode"];
                    candidate.Thoroughfare = (string)dt.Rows[i]["Thoroughfare"];
                    candidate.ApartmentNumber = (string)dt.Rows[i]["ApartmentNumber"];
                    candidate.City = (string)dt.Rows[i]["City"];
                    candidate.PoliticalPartyId = (int)dt.Rows[i]["PoliticalPartyId"];
                    candidate.ElectoralPosition = (string)dt.Rows[i]["ElectoralPosition"];
                    candidate.ElectoralMunicipality = (string)dt.Rows[i]["ElectoralMunicipality"];
                    candidate.ElectoralDistrict = (string)dt.Rows[i]["ElectoralDistrict"];
                    candidate.isActiveCandidate = (bool)dt.Rows[i]["isActive"];
                    candidate.NamePoliticalParty = (string)dt.Rows[i]["Name"];

                    listofCandidates.Add(candidate);
                }

            }


            if (listofCandidates.Count > 0)
            {
                response.statusCode = 200;
                response.statusMessage = "Data retrievable is successful";
                response.candidates = listofCandidates;
            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "No data retrievable";
                response.candidates = null;
            }
            return response;
        }

        public CandidateResponse SelectCandidateByName(string name)
        {
            DataTable dt = dal.get.SelectCandidateByName(name);
            CandidateResponse response = new CandidateResponse();
            List<CandidateViewModel> listofCandidates = new List<CandidateViewModel>();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CandidateViewModel candidate = new CandidateViewModel();
                    candidate.IdPerson = (int)dt.Rows[i]["Id"];
                    candidate.Name = (string)dt.Rows[i]["Name"];
                    candidate.LastName = (string)dt.Rows[i]["LastName"];
                    candidate.Gender = (string)dt.Rows[i]["Gender"];
                    candidate.Email = (string)dt.Rows[i]["Email"];
                    candidate.Phone = dt.Rows[i]["Phone"].ToString();
                    candidate.Thoroughfare = (string)dt.Rows[i]["Thoroughfare"];
                    candidate.ApartmentNumber = (string)dt.Rows[i]["ApartmentNumber"];
                    candidate.PostalCode = (string)dt.Rows[i]["PostalCode"];
                    candidate.City = (string)dt.Rows[i]["City"];
                    candidate.UserId = (string)dt.Rows[i]["UserId"];
                    candidate.ProfilePhoto = (string)dt.Rows[i]["ProfilePhoto"];
                    candidate.PostalCode = (string)dt.Rows[i]["PostalCode"];
                    candidate.Thoroughfare = (string)dt.Rows[i]["Thoroughfare"];
                    candidate.ApartmentNumber = (string)dt.Rows[i]["ApartmentNumber"];
                    candidate.City = (string)dt.Rows[i]["City"];
                    candidate.PoliticalPartyId = (int)dt.Rows[i]["PoliticalPartyId"];
                    candidate.ElectoralPosition = (string)dt.Rows[i]["ElectoralPosition"];
                    candidate.ElectoralMunicipality = (string)dt.Rows[i]["ElectoralMunicipality"];
                    candidate.ElectoralDistrict = (string)dt.Rows[i]["ElectoralDistrict"];
                    candidate.isActiveCandidate = (bool)dt.Rows[i]["isActive"];
                    candidate.NamePoliticalParty = (string)dt.Rows[i]["Name"];

                    listofCandidates.Add(candidate);
                }

            }


            if (listofCandidates.Count > 0)
            {
                response.statusCode = 200;
                response.statusMessage = "Data retrievable is successful";
                response.candidates = listofCandidates;
            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "No data retrievable";
                response.candidates = null;
            }
            return response;
        }

        public async Task<CandidateResponse> SelectCandidateformation(int PersonId)
        {

            Candidate candidate = await dal.get.SelectCandidateformation(PersonId);
            CandidateResponse response = new CandidateResponse();
            
            if (candidate.ElectoralPosition!=null)
            {
                    response.statusCode = 200;
                    response.statusMessage = "Data retrievable is successful";
                    response.candidateM = candidate;

            } 
            else
            {
                response.statusCode = 100;
                response.statusMessage = "No data retrievable";
                response.candidatesM = null;
            }
            return response;
        }

        public async Task<CandidateResponse> SelectAllCandidateformation()
        {

            List<Candidate> candidates = await dal.get.SelectAllCandidateformation();
            CandidateResponse response = new CandidateResponse();

            if (candidates != null)
            {
                response.statusCode = 200;
                response.statusMessage = "Data retrievable is successful";
                response.candidatesM = candidates;

            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "No data retrievable";
                response.candidatesM = null;
            }
            return response;
        }

        public ElectorResponse SelectElectors()
        {

            DataTable dt = dal.get.SelectElectors();
            ElectorResponse response = new ElectorResponse();
            List<ElectorViewModel> listofElectors = new List<ElectorViewModel>();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ElectorViewModel elector = new ElectorViewModel();
                    elector.IdPerson = (int)dt.Rows[i]["Id"];
                    elector.Name = (string)dt.Rows[i]["Name"];
                    elector.LastName = (string)dt.Rows[i]["LastName"];
                    elector.Gender = (string)dt.Rows[i]["Gender"];
                    elector.Email = (string)dt.Rows[i]["Email"];
                    elector.Phone = dt.Rows[i]["Phone"].ToString();
                    elector.Thoroughfare = (string)dt.Rows[i]["Thoroughfare"];
                    elector.ApartmentNumber = (string)dt.Rows[i]["ApartmentNumber"];
                    elector.PostalCode = (string)dt.Rows[i]["PostalCode"];
                    elector.City = (string)dt.Rows[i]["City"];
                    elector.UserId = (string)dt.Rows[i]["UserId"];
                    elector.ProfilePhoto = (string)dt.Rows[i]["ProfilePhoto"];
                    elector.PostalCode = (string)dt.Rows[i]["PostalCode"];
                    elector.Thoroughfare = (string)dt.Rows[i]["Thoroughfare"];
                    elector.ApartmentNumber = (string)dt.Rows[i]["ApartmentNumber"];
                    elector.City = (string)dt.Rows[i]["City"];  
                    elector.ElectoralMunicipality = (string)dt.Rows[i]["ElectoralMunicipality"];
                    elector.ElectoralDistrict = (string)dt.Rows[i]["ElectoralDistrict"];
                    elector.isActiveElector = (bool)dt.Rows[i]["isActive"]; 

                    listofElectors.Add(elector);
                }

            }


            if (listofElectors.Count > 0)
            {
                response.statusCode = 200;
                response.statusMessage = "Data retrievable is successful";
                response.electors = listofElectors;
            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "No data retrievable";
                response.electors = null;
            }
            return response;
        }

        public ElectorResponse SelectElectorsByName(string name)
        {
            DataTable dt = dal.get.SelectElectorsByName(name);
            ElectorResponse response = new ElectorResponse();
            List<ElectorViewModel> listofElectors = new List<ElectorViewModel>();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ElectorViewModel elector = new ElectorViewModel();
                    elector.IdPerson = (int)dt.Rows[i]["Id"];
                    elector.Name = (string)dt.Rows[i]["Name"];
                    elector.LastName = (string)dt.Rows[i]["LastName"];
                    elector.Gender = (string)dt.Rows[i]["Gender"];
                    elector.Email = (string)dt.Rows[i]["Email"];
                    elector.Phone = dt.Rows[i]["Phone"].ToString();
                    elector.Thoroughfare = (string)dt.Rows[i]["Thoroughfare"];
                    elector.ApartmentNumber = (string)dt.Rows[i]["ApartmentNumber"];
                    elector.PostalCode = (string)dt.Rows[i]["PostalCode"];
                    elector.City = (string)dt.Rows[i]["City"];
                    elector.UserId = (string)dt.Rows[i]["UserId"];
                    elector.ProfilePhoto = (string)dt.Rows[i]["ProfilePhoto"];
                    elector.PostalCode = (string)dt.Rows[i]["PostalCode"];
                    elector.Thoroughfare = (string)dt.Rows[i]["Thoroughfare"];
                    elector.ApartmentNumber = (string)dt.Rows[i]["ApartmentNumber"];
                    elector.City = (string)dt.Rows[i]["City"];
                    elector.ElectoralMunicipality = (string)dt.Rows[i]["ElectoralMunicipality"];
                    elector.ElectoralDistrict = (string)dt.Rows[i]["ElectoralDistrict"];
                    elector.isActiveElector = (bool)dt.Rows[i]["isActive"];

                    listofElectors.Add(elector);
                }

            }


            if (listofElectors.Count > 0)
            {
                response.statusCode = 200;
                response.statusMessage = "Data retrievable is successful";
                response.electors = listofElectors;
            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "No data retrievable";
                response.electors = null;
            }
            return response;
        }

        public ElectorResponse SelectElectorInformation(int PersonId)
        {
            Elector elector = dal.get.SelectElectorInformation(PersonId);
            ElectorResponse response = new ElectorResponse(); 

            if (elector.id!=null)
            {
                response.statusCode = 200;
                response.statusMessage = "Data retrievable is successful";
                response.electorModel = elector;
            } 
            else
            {
                response.statusCode = 100;
                response.statusMessage = "No data retrievable";
                response.electorModel = null;
            }
            return response;
        }

        public PoolElectorsResponse ValidateElector(string guid)
        {

            DataTable dt = dal.get.ValidateElector(guid);
            PoolElectorsResponse response = new PoolElectorsResponse();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PoolElectors pool = new PoolElectors();
                    pool.idElectors = dt.Rows[i]["idElectors"].ToString();
                    pool.isActive = (bool)dt.Rows[i]["isActive"]; 
                    pool.Hash = (string)dt.Rows[i]["Hash"]; 


                    response.statusCode = 200;
                    response.statusMessage = "Data retrievable is successful";
                    response.poolElector = pool;
                }

            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "No data retrievable";
                response.poolElector = null;
            }
            return response;
        }

        public PoolElectorsResponse SelectPoolElector(string hash)
        {

            DataTable dt = dal.get.SelectPoolElector(hash);
            PoolElectorsResponse response = new PoolElectorsResponse();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PoolElectors pool = new PoolElectors();
                    pool.idElectors = dt.Rows[i]["idElectors"].ToString();
                    pool.isActive = (bool)dt.Rows[i]["isActive"];
                    pool.Hash = (string)dt.Rows[i]["Hash"];


                    response.statusCode = 200;
                    response.statusMessage = "Data retrievable is successful";
                    response.poolElector = pool;
                }

            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "No data retrievable";
                response.poolElector = null;
            }
            return response;
        }

        public PoolElectorsResponse SelectAllHashPoolElector()
        {

            DataTable dt = dal.get.SelectAllHashPoolElector();
            PoolElectorsResponse response = new PoolElectorsResponse();
            List<PoolElectors> listPool = new List<PoolElectors>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PoolElectors pool = new PoolElectors(); 
                    pool.Hash = (string)dt.Rows[i]["Hash"];

                    listPool.Add(pool); 
                }

            }

            if (listPool.Count>0)
            {
                response.statusCode = 200;
                response.statusMessage = "Data retrievable is successful";
                response.poolElectors = listPool;
            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "No data retrievable";
                response.poolElectors = null;
            }
            return response;
        }

        public CountVotesResponse CountVotes(List<Candidate> candidates)
        {

            List<CountVotes> votes = dal.get.CountVotes(candidates);
            CountVotesResponse response = new CountVotesResponse(); 
            if (votes.Count > 0)
            {
                response.statusCode = 200;
                response.statusMessage = "Data retrievable is successful";
                response.votes = votes;
            } 
            else
            {
                response.statusCode = 100;
                response.statusMessage = "No data retrievable";
                response.votes = null;
            }
            return response;
        } 
         public async Task<PersonResponse> SelectPersonByEmail(String email)
        { 
            Person person = await dal.get.SelectPersonByEmail(email);
            PersonResponse response = new PersonResponse();
            if (person.Email != null)
            {
                response.statusCode = 200;
                response.statusMessage = "Data retrievable is successful";
                response.personM = person;
            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "No data retrievable";
                response.personM = null;
            }
            return response;
        }

    }
}
  
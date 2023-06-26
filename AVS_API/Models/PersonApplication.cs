using AVS_API.Data;
using AVS_API.DataAccessLayer;
using AVS_API.Models;
using AVS_API.ViewModels; 
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using System.Reflection;

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
    }
}
        //---------------

/*
        [HttpPost] 
        public async Task<PersonResponse> AddPersonAsync(personViewModel personViewModel)
        {
           
            string role = personViewModel.role;
          
            var user = new IdentityUser() { Email = personViewModel.Email, UserName = personViewModel.Email };

           // var result = await userManager.CreateAsync(user, password: personViewModel.Password); //CREATING USER 
            //ASSINIG ROLE
            if (user == null)
            {
                return null;
            }
            //await userManager.AddToRoleAsync(user, role);
            //ASSING ROLE END

            //SETTING UP THE OBJECTS TO INSERT INTO THE TABLES
            var person = new Person
            {
                Name = personViewModel.Name,
                LastName = personViewModel.LastName,
                Phone = personViewModel.Phone, //TO FIX THIS VALUE IS GETTING 0 IN THE DATABASE
                Gender = personViewModel.Gender,
                Email = personViewModel.Email,
                MarriedName = personViewModel.MarriedName,
                bornDate = personViewModel.bornDate,
                isActive = true,
                UserId = user.Id,
            };

            var address = new Address
            {
                City = personViewModel.City,
                ApartmentNumber = personViewModel.ApartmentNumber,
                Thoroughfare = personViewModel.Thoroughfare,
                PostalCode = personViewModel.PostalCode,
                PersonId = personViewModel.Id, //TO FIX THIS VALUE IS GETTING 0 IN THE DATABASE
            };

           // if (result.Succeeded)//IF USER WAS CREATED SUCCESFULLY THEN ADD INTO DATABASE PERSON AND ADDRESS THEN GO HOME
            {
                /*context.Person.Add(person);
                context.Address.Add(address);
                await context.SaveChangesAsync();*/
         //   }
         

           // PersonResponse response = new PersonResponse();
          /*  String query = "INSERT INTO [dbo].[AspNetUsers] VALUES('" + person.Email + "','" + person.Password + "')      INSERT INTO AspNetUserRoles VALUES('" + person.UserId + "','" + person.role + "') INSERT INTO Person VALUES('" + person.Name + "','" + person.LastName + "','" + person.Gender + "'," + person.bornDate + ",'" + person.Email + "','" + person.Phone + "','" + person.isActive + "','" + person.UserId + "') INSERT INTO Address  VALUES('" + person.PostalCode + "','" + person.Thoroughfare + "','" + person.ApartmentNumber + "','" + person.City + "','" + person.PersonId + "')";


          bool state = await utilities.sql.Set(query);
            if (state)
            {
                response.statusCode = 200;
              response.statusMessage = "Data entry Successfully";
              response.users = person;
          }
          else
          {
              response.statusCode = 100;
              response.statusMessage = "No data inserted";
              response.person = null;
          }*/

          //return response;
        
     // }
        /*
            public async Task<Response> UpdateStudentsAsync(Student student)
            {
                Response response = new Response();
                String query = "Update Students set firstName='" + student.FirstName + "',lastName= '" + student.LastName + "', email='" + student.Email + "' where id=" + (int)student.Id + "";
                await utilities.sql.Set(query);



                bool state = await utilities.sql.Set(query);

                if (state)
                {
                    response.statusCode = 200;
                    response.statusMessage = "Data updated Successfully";
                    response.student = student;
                }
                else
                {
                    response.statusCode = 100;
                    response.statusMessage = "No data updated";
                    response.student = null;
                }

                return response;

            }

            public async Task<Response> DeleteStudentsAsync(int id)
            {
                Response response = new Response();
                String query = "Delete from Students where id=" + id + "";
                bool state = await utilities.sql.Set(query);

                if (state)
                {
                    response.statusCode = 200;
                    response.statusMessage = "Data deleted Successfully";
                }
                else
                {
                    response.statusCode = 100;
                    response.statusMessage = "No data deleted";
                }


                return response;

            }*/
  //  }
//}

using AVS_API.Data;
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
    public class PersonApplication 
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<IdentityUser> userManager;
        public PersonResponse GetAllPeople()
        {
             
            DataTable dt = utilities.sql.Get("Select * from Person");
            PersonResponse response = new PersonResponse();
            List<Person> ListOfPeople = new List<Person>();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Person person = new Person();
                    person.Id = (int)dt.Rows[i]["id"];
                    person.Name = (string)dt.Rows[i]["name"];
                    person.LastName = (string)dt.Rows[i]["lastName"];
                    person.Gender = (string)dt.Rows[i]["gender"];
                    person.bornDate = (DateTime)dt.Rows[i]["bornDate"];
                    person.Phone = (int)dt.Rows[i]["phone"];
                    person.UserId = (string)dt.Rows[i]["userId"]; 
                    person.Email = (string)dt.Rows[i]["email"];
                    person.isActive = (bool)dt.Rows[i]["isActive"];

                    ListOfPeople.Add(person);
                }

            }

            if (ListOfPeople.Count > 0)
            {
                response.statusCode = 200;
                response.statusMessage = "Data retrievable is successful";
                response.people = ListOfPeople;
            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "No data retrievable";
                response.people = null;
            }
            return response;
        }

      public PersonResponse GetPersonById(int id)
        {

            PersonResponse response = new PersonResponse();
            DataTable dt = utilities.sql.Get("Select * from Person where id='" + id + "'");

            if (dt.Rows.Count > 0)
            {
                Person person = new Person();
                person.Id = (int)dt.Rows[0]["id"];
                person.Name = (string)dt.Rows[0]["name"];
                person.LastName = (string)dt.Rows[0]["lastName"];
                person.Gender = (string)dt.Rows[0]["gender"];
                person.bornDate = (DateTime)dt.Rows[0]["bornDate"];
                person.Phone = (int)dt.Rows[0]["phone"];
                person.UserId = (string)dt.Rows[0]["userId"];
                person.Email = (string)dt.Rows[0]["email"];
                person.isActive = (bool)dt.Rows[0]["isActive"];

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


        [HttpPost] 
        public async Task<PersonResponse> AddPersonAsync(personViewModel personViewModel)
        {
           
            string role = personViewModel.role;
          
            var user = new IdentityUser() { Email = personViewModel.Email, UserName = personViewModel.Email };

            var result = await userManager.CreateAsync(user, password: personViewModel.Password); //CREATING USER 
            //ASSINIG ROLE
            if (user == null)
            {
                return null;
            }
            await userManager.AddToRoleAsync(user, role);
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

            if (result.Succeeded)//IF USER WAS CREATED SUCCESFULLY THEN ADD INTO DATABASE PERSON AND ADDRESS THEN GO HOME
            {
                context.Person.Add(person);
                context.Address.Add(address);
                await context.SaveChangesAsync();
            }
         

            PersonResponse response = new PersonResponse();
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

          return response;

      }
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
    }
}

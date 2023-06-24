using Automated_Voting_System.Entities;
using AVS_Desktop.Models;
using AVS_Desktop.Views;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.DirectoryServices;
using System.Threading.Tasks;
using Candidate = AVS_Desktop.Models.Candidate;

namespace AVS_Desktop.DataAccessLayer
{
    public class dal
    {
        public class set
        {
            public static async Task DeletePoliticalParty(Models.PoliticalParty politicalParty)
            {
                await utilities.sql.Set("Delete from [dbo].[PoliticalParty] where Id=" + politicalParty.Id + " ");
            }
            public static async Task UpdatePoliticalParty(Models.PoliticalParty politicalParty)
            {
                await utilities.sql.Set("Update [dbo].[PoliticalParty] set Name = '" + politicalParty.Name + "' where Id = "+politicalParty.Id+"");
            }
            public static async Task InsertPoliticalParty(Models.PoliticalParty politicalParty)
            {
               await utilities.sql.Set("INSERT INTO [dbo].[PoliticalParty]   VALUES('" + politicalParty.Name + "')");
            }
            public static async Task InserIntoVoting(Guid idVote, String IdElector)
            {
                await utilities.sql.Set("INSERT INTO [dbo].[Voting] VALUES ('" + idVote + "','" + IdElector + "','" + DateTime.Now + "',1)");
            }
            public static async Task InserIntoVote(Guid idVote, String IdElector, String guidCandidate)
            {
                await utilities.sql.Set("INSERT INTO [dbo].[Vote] VALUES ('" + idVote + "','" + IdElector + "','" + guidCandidate + "','" + DateTime.Now + "','" + utilities.tools.GetMacAddress() + "','" + utilities.tools.GetIpAddress() + "')");
            }
            public static async Task UpdatePoolElectors(String IdElector)
            {
                await utilities.sql.Set("Update PoolElectors set isActive=0 where IdElectors='" + IdElector + "'");
            }

            public static async Task UpdatePerson(Person person)
            {
                await utilities.sql.Set("UPDATE [dbo].[Person] SET [Name] = '"+person.Name+"'\r\n      ,[LastName] = '"+person.LastName+"'\r\n      ,[Gender] = '"+person.Gender+"'\r\n      ,[bornDate] = '"+person.bornDate+"'\r\n      ,[Email] = '"+person.Email+"'\r\n      ,[Phone] = '"+person.Phone+"'\r\n WHERE id="+person.Id+"");
            }
            public static async Task UpdateAddress(Address address)
            {
                await utilities.sql.Set("UPDATE [dbo].[Address]\r\n   SET [PostalCode] = '"+address.PostalCode+"'\r\n      ,[Thoroughfare] = '"+address.Thoroughfare+"'\r\n      ,[ApartmentNumber] = '"+address.ApartmentNumber+"'\r\n      ,[City] = '"+address.City+"'\r\n WHERE personId="+address.PersonId+"");
            }

            public static async Task UpdateUser(User user)
            {
                await utilities.sql.Set("UPDATE [dbo].[AspNetUsers]\r\n   SET [UserName] = '"+user.Email+"'\r\n      ,[NormalizedUserName] = '"+user.Email+"'\r\n      ,[Email] = '"+user.Email+"'\r\n      ,[NormalizedEmail] = '"+user.Email+"'\r\n      ,[PasswordHash] = '"+user.PasswordHash+"'\r\n WHERE Id ='"+user.Id+"'");
            } 
            public static async Task UpdateUserNoPassword(User user)
            {
                await utilities.sql.Set("UPDATE [dbo].[AspNetUsers]\r\n   SET [UserName] = '" + user.Email + "'\r\n      ,[NormalizedUserName] = '" + user.Email + "'\r\n      ,[Email] = '" + user.Email + "'\r\n      ,[NormalizedEmail] = '" + user.Email + "'\r\n WHERE Id ='" + user.Id + "'");
            }
            public static async Task UpdateElector(Elector elector)
            {
                await utilities.sql.Set("UPDATE [dbo].[Elector]\r\n   SET  [ElectoralMunicipality] = '"+elector.ElectoralMunicipality+"'\r\n   ,[ElectoralDistrict] ='"+elector.ElectoralDistrict+"'\r\n WHERE personId="+elector.PersonId+"");
            }

            public static async Task UpdateCandidate(Candidate candidate)
            {
                await utilities.sql.Set("UPDATE [dbo].[Candidate]\r\n   [ElectoralPosition] = '"+candidate.ElectoralPosition+"'\r\n      ,[ElectoralMunicipality] = '"+candidate.ElectoralMunicipality+"'\r\n      ,[ElectoralDistrict] = '"+candidate.ElectoralDistrict+"' WHERE personId="+candidate.PersonId+"");
            }

            public static async Task CreatePerson(Person person,Address address,User user)
            { 
                await utilities.sql.Set("INSERT INTO [dbo].[AspNetUsers]([Id],[UserName],[NormalizedUserName],[Email],[NormalizedEmail],[EmailConfirmed],[PasswordHash],[PhoneNumberConfirmed],[TwoFactorEnabled],[LockoutEnabled],[AccessFailedCount])\r\n VALUES\r\n ('" + user.Id + "','" + user.UserName + "','" + user.NormalizedUserName + "' ,'" + user.Email + "','" + user.Email + "',0,'" + user.PasswordHash + "',0,0,0,0)");
                await utilities.sql.Set("Insert into AspNetUserRoles values('" + user.Id + "','" + user.RoleId + "')");
                await utilities.sql.Set("INSERT INTO Person  VALUES('" + person.Name + "','" + person.LastName + "','" + person.LastName + "','" + person.Gender + "','" + person.bornDate + "','" + person.Email + "','" + person.Phone + "',1,'" + person.UserId + "','https://xsgames.co/randomusers/avatar.php?g=male')");
                int max = await get.getLastIdInserted();
                await utilities.sql.Set("INSERT INTO[dbo].[Address]  VALUES('" + address.PostalCode + "', '" + address.Thoroughfare + "', '" + address.ApartmentNumber + "', '" + address.City + "'," + max + " )");
            }
            public static async Task CreateElector(Elector elector)
            {
                int max = await get.getLastIdInserted();
                await utilities.sql.Set("INSERT INTO [dbo].[Elector]\r\n VALUES\r\n ('"+elector.id+"'\r\n,"+elector.PersonId+"\r\n, '"+elector.ElectoralMunicipality+"'\r\n,  '"+elector.ElectoralDistrict+"'\r\n, 1)");
                await utilities.sql.Set("insert into PoolElectors values('" + Guid.NewGuid() + "',1,'" + utilities.tools.HashPassword(max.ToString()) + "')");
            }

            public static async Task createCandidate(Candidate candidate)
            {
                await utilities.sql.Set("INSERT INTO [dbo].[Candidate] \r\n VALUES\r\n ('"+candidate.Id+"'\r\n , '"+candidate.PoliticalPartyId+"'\r\n,'"+candidate.ElectoralPosition+"'\r\n,'"+candidate.ElectoralMunicipality+"'\r\n,'"+candidate.ElectoralDistrict+"'\r\n,1,"+candidate.PersonId+")");
            }

            public static async Task deleteCandidate(Person person)
            {
                int personId=0;
                DataTable dt= await dal.get.SelectPersonUserID(person.Email);
                foreach (DataRow row in dt.Rows)
                {
                    personId =(int) row[1];
                }
                await utilities.sql.Set("DELETE FROM [dbo].[Candidate] WHERE personId="+personId+"");
            }
            public static async Task deleteElector(Person person)
            {
                int personId = 0;
                DataTable dt = await dal.get.SelectPersonUserID(person.Email);
                foreach (DataRow row in dt.Rows)
                {
                    personId = (int)row[1];
                }
                await utilities.sql.Set("DELETE FROM [dbo].[Elector] WHERE personId="+personId+"");
            }
            public static async Task deletePerson(Person person)
            {
                int personId = 0;
                DataTable dt = await dal.get.SelectPersonUserID(person.Email);
                foreach (DataRow row in dt.Rows)
                {
                    personId = (int)row[1];
                }
                await utilities.sql.Set("DELETE FROM [dbo].[Person] WHERE Id=" + personId + "");
            }
            public static async Task deleteAddress(Person person)
            {
                int personId = 0;
                DataTable dt = await dal.get.SelectPersonUserID(person.Email);
                foreach (DataRow row in dt.Rows)
                {
                    personId = (int)row[1];
                }
                await utilities.sql.Set("DELETE FROM [dbo].[Address] WHERE personId=" + personId + "");
            }
            public static async Task deleteUser(Person person)
            {
                string userId = string.Empty;
                DataTable dt = await dal.get.SelectPersonUserID(person.Email);
                foreach (DataRow row in dt.Rows)
                {
                    userId = (string)row[0];
                }
                await utilities.sql.Set("DELETE FROM [dbo].[AspNetUsers] WHERE Id='" + userId + "'");
            }

            public static async Task deleteRolUser(Person person)
            {
                string userId = string.Empty;
                DataTable dt = await dal.get.SelectPersonUserID(person.Email);
                foreach (DataRow row in dt.Rows)
                {
                    userId = (string)row[0];
                }
                await utilities.sql.Set("DELETE FROM [dbo].[AspNetUserRoles] WHERE UserId='" + userId + "'");
            }
        }

        public static class get
        {

            public static int selectIdPoliticalPartyByName(PoliticalParty politicalParty)
            {
                int id = 0;
                DataTable dt = utilities.sql.Get("SELECT Id FROM PoliticalParty Where Id="+politicalParty.Name+"");
                foreach (DataRow row in dt.Rows)
                {
                    id = (int) row[0];
                }
                return id;
            }
            public static DataTable selectPoliticalPartyByName(PoliticalParty politicalParty)
            {
                return utilities.sql.Get("SELECT * FROM PoliticalParty Where Name like '%" + politicalParty.Name + "%';");  
            }
            public static int selectLastIdInsertedPoliticalParty()
            {
                int id = 0;
                DataTable dt = utilities.sql.Get("SELECT TOP 1 Id FROM PoliticalParty ORDER BY Id DESC");
                foreach (DataRow row in dt.Rows)
                {
                    id = (int)row[0];
                }
                return id;
            }
            public static DataTable selectPoliticalsParties()
            {
                return utilities.sql.Get("Select * from PoliticalParty");
            }
            public static Task<int> getLastIdInserted()
            {
                DataTable dt = utilities.sql.Get(" select max(id) from Person");
                int max = 0;
                foreach (DataRow row in dt.Rows)
                {
                    max = (int)row[0];
                }
                return Task.FromResult(max);
            }
            public static DataTable SelectPeople()
            {
                return utilities.sql.Get(" SELECT P.Name, P.LastName, P.Gender, P.Email,P.Phone,A.Thoroughfare, A.ApartmentNumber,A.PostalCode, A.City, p.UserId, UR.RoleId, R.Name FROM Person AS P\r\n JOIN Address AS A ON P.id = A.PersonId \r\n JOIN AspNetUserRoles AS UR on P.UserId =UR.UserId\r\n JOIN AspNetRoles  AS R on UR.RoleId=R.Id\r\n WHERE P.Id = A.PersonId;");

            }
            public static DataTable SelectPeopleByName(String name)
            {
                return utilities.sql.Get(" SELECT P.Name, P.LastName, P.Gender, P.Email,P.Phone,A.Thoroughfare, A.ApartmentNumber,A.PostalCode, A.City, p.UserId, UR.RoleId, R.Name FROM Person AS P\r\n JOIN Address AS A ON P.id = A.PersonId \r\n JOIN AspNetUserRoles AS UR on P.UserId =UR.UserId\r\n JOIN AspNetRoles  AS R on UR.RoleId=R.Id\r\n WHERE P.Name like '%" + name + "%';");

            }
            public static DataTable SelectCandidates()
            {   
                return utilities.sql.Get("SELECT *\r\nFROM Person AS P\r\nJOIN Address AS A ON P.id = A.PersonId\r\nJOIN AspNetUsers AS U ON P.UserId = U.id\r\nJOIN Candidate AS C ON P.id = C.PersonId\r\nJOIN [AutomatedVotingSystem].[dbo].[PoliticalParty] AS PP ON PP.id = c.PoliticalPartyId\r\nWHERE P.id = c.PersonId;");
            
            }
            public static DataTable SelectCandidateByName(String name)
            {
                return utilities.sql.Get("SELECT *\r\nFROM Person AS P\r\nJOIN Address AS A ON P.id = A.PersonId\r\nJOIN AspNetUsers AS U ON P.UserId = U.id\r\nJOIN Candidate AS C ON P.id = C.PersonId\r\nJOIN [AutomatedVotingSystem].[dbo].[PoliticalParty] AS PP ON PP.id = c.PoliticalPartyId\r\nWHERE P.Name like '%" + name+ "%' ;");

            }

            public static DataTable SelectElectors()
            {
                return utilities.sql.Get("SELECT *\r\nFROM Person AS P\r\nJOIN Address AS A ON P.id = A.PersonId\r\nJOIN AspNetUsers AS U ON P.UserId = U.id\r\nJOIN Elector AS C ON P.id = C.PersonId\r\nWHERE P.id = c.PersonId;");

            }
            public static DataTable SelectElectorsByName(String name)
            {
                return utilities.sql.Get("SELECT *\r\nFROM Person AS P\r\nJOIN Address AS A ON P.id = A.PersonId\r\nJOIN AspNetUsers AS U ON P.UserId = U.id\r\nJOIN Elector AS C ON P.id = C.PersonId\r\n WHERE P.Name like '%" + name + "%' ;");

            }

            public static DataTable ValidateElector(String guid) 
            {
               return utilities.sql.Get("SELECT * from PoolElectors where IdElectors ='" + guid + "' and isActive=1;");
            }
            public static DataTable SelectPoolElector(String hash)
            {
                return utilities.sql.Get("SELECT * from PoolElectors where Hash ='" + hash + "';");
            }
            public static DataTable SelectAllHashPoolElector()
            {
                return utilities.sql.Get("SELECT Hash from PoolElectors;");
            }

            public static String Login(String user) 
            {
                string hash=string.Empty;
                DataTable dt = utilities.sql.Get("SELECT  [PasswordHash] FROM[AutomatedVotingSystem].[dbo].[AspNetUsers] where Email = '"+ user + "'");
                foreach (DataRow row in dt.Rows) 
                {
                    hash =(string) row[0];
                }
                return hash;
            }

            public static String SelectRoleIdFromUsers(String user)
            {
                string role = string.Empty;
                string userId = string.Empty;
                DataTable dt = utilities.sql.Get("SELECT  id FROM[AutomatedVotingSystem].[dbo].[AspNetUsers] where Email = '" + user + "'");
                foreach (DataRow row in dt.Rows)
                {
                    userId = (string)row[0];
                }

                dt = utilities.sql.Get("select * from [AspNetUserRoles] where UserId= '" + userId + "'");
                foreach (DataRow row in dt.Rows)
                {
                    role = (string)row[1];
                }
                return role;
            }

            public static Task<string> SelectRoleIdFromRole(String roleName)
            {
                string roleId = string.Empty; 

                DataTable dt = utilities.sql.Get("select * from [AspNetRoles] where name = '" + roleName + "'");
                foreach (DataRow row in dt.Rows)
                {
                    roleId = (string)row[0];
                }
                return Task.FromResult(roleId);
            }

            public static String SelectRoleName(String role)
            { 
                string Name = string.Empty;
                DataTable dt = utilities.sql.Get("SELECT name FROM [AspNetRoles] where Id = '" + role + "'");
                foreach (DataRow row in dt.Rows)
                {
                    Name = (string)row[0];
                } 
                return Name;
            }

            public static int SelectIdPersonByUserId(string gui)
            {
                int id = 0;
                DataTable dt = utilities.sql.Get("SELECT id FROM Person where UserId = '" + gui + "'");
                foreach (DataRow row in dt.Rows)
                {
                    id = (int)row[0];
                }
                return id;
            }

            public static string SelectNamePersonById(int id)
            {
                string name = string.Empty;
                DataTable dt = utilities.sql.Get("SELECT Name, lastName FROM Person where Id = " + id + "");
                foreach (DataRow row in dt.Rows)
                {
                    name = row[0].ToString()+" "+row[1].ToString(); 
                }
                return name;
            }

            public static Elector SelectElectorInformation(int userId)
            {
                DataTable dt = utilities.sql.Get("SELECT * FROM Elector where PersonId=" + userId + "");
                Elector elector = new Elector();
                foreach (DataRow row in dt.Rows)
                {
                    elector.id = (Guid)row[0];
                    elector.PersonId = (int)row[1];
                    elector.ElectoralMunicipality = row[3].ToString();
                    elector.ElectoralDistrict = row[2].ToString();
                    elector.isActive = (bool)row[4];
                }
                return elector;
            }

            public static async Task<Candidate> SelectCandidateformation(int userId)
            {
                DataTable dt = utilities.sql.Get("SELECT * FROM Candidate where PersonId=" + userId + "");
                Candidate candidate = new Candidate();
                foreach (DataRow row in dt.Rows)
                {
                    candidate.ElectoralMunicipality = row[3].ToString();
                    candidate.ElectoralDistrict = row[4].ToString();
                    candidate.PoliticalPartyId = (int) row[1];
                    candidate.Id=(Guid) row[0];
                    candidate.ElectoralPosition = row[2].ToString();
                    candidate.isActive = (bool)row[5];
                    candidate.PersonId = (int)row[6];
                }
                return await Task.FromResult(candidate);
            }

            public static async Task<List<Candidate>> SelectAllCandidateformation()
            {
                DataTable dt = utilities.sql.Get("SELECT * FROM Candidate");
                List<Candidate> candidates = new List<Candidate>();               
                foreach (DataRow row in dt.Rows)
                {
                    Candidate candidate = new Candidate();
                    candidate.ElectoralMunicipality = row[3].ToString();
                    candidate.ElectoralDistrict = row[4].ToString();
                    candidate.PoliticalPartyId = (int)row[1];
                    candidate.Id = (Guid)row[0];
                    candidate.ElectoralPosition = row[2].ToString();
                    candidate.isActive = (bool)row[5];
                    candidate.PersonId = (int)row[6];
                    candidates.Add(candidate);
                }
                return await Task.FromResult(candidates);
            }

            public static List<CountVotes> CountVotes(List<Candidate> candidates)
            {
                List<CountVotes> list=new List<CountVotes>();
                foreach (var item in candidates)
                {
                    DataTable dt = utilities.sql.Get(" select Vote.CandidateId,COUNT(vote.CandidateId) as Votes from vote where CandidateId='" + item.Id + "' group by Vote.CandidateId");
                    foreach (DataRow row in dt.Rows)
                    {
                        CountVotes countVotes = new CountVotes();
                        countVotes.CandidateId= row[0].ToString();
                        countVotes.Count=(int) row[1];
                        list.Add(countVotes);
                    }
                }
                return list;
            }

            public static async Task<DataTable> SelectPersonUserID(string email)
            {
                return await Task.FromResult( utilities.sql.Get("SELECT u.Id, p.id  FROM [AutomatedVotingSystem].[dbo].[AspNetUsers] as u\r\nJoin Person as P on p.UserId = u.Id where u.Email='"+email+"'"));
            }

        }
    }
}

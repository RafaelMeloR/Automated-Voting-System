using System;
using System.Data;
using System.DirectoryServices;
using System.Threading.Tasks;

namespace AVS_Desktop.DataAccessLayer
{
    public class dal
    {
        public class set
        {
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
        }

        public static class get
        {
            public static DataTable SelectPeople()
            {
                return utilities.sql.Get(" SELECT P.Name, P.LastName, P.Gender, P.Email,P.Phone,A.Thoroughfare, A.ApartmentNumber,A.PostalCode, A.City, p.UserId, UR.RoleId, R.Name FROM Person AS P\r\n JOIN Address AS A ON P.id = A.PersonId \r\n JOIN AspNetUserRoles AS UR on P.UserId =UR.UserId\r\n JOIN AspNetRoles  AS R on UR.RoleId=R.Id\r\n WHERE P.Id = A.PersonId;");

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

            public static String SelectRoleId(String user)
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

        }
    }
}

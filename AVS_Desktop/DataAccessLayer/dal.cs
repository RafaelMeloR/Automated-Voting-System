using System;
using System.Data;
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
            public static DataTable SelectCandidates()
            {   
                return utilities.sql.Get("SELECT *\r\nFROM Person AS P\r\nJOIN Address AS A ON P.id = A.PersonId\r\nJOIN AspNetUsers AS U ON P.UserId = U.id\r\nJOIN Candidate AS C ON P.id = C.PersonId\r\nJOIN [AutomatedVotingSystem].[dbo].[PoliticalParty] AS PP ON PP.id = 1\r\nWHERE P.id = c.PersonId;");
            
            }
            public static DataTable SelectCandidateByName(String name)
            {
                return utilities.sql.Get("SELECT *\r\nFROM Person AS P\r\nJOIN Address AS A ON P.id = A.PersonId\r\nJOIN AspNetUsers AS U ON P.UserId = U.id\r\nJOIN Candidate AS C ON P.id = C.PersonId\r\nJOIN [AutomatedVotingSystem].[dbo].[PoliticalParty] AS PP ON PP.id = 1\r\nWHERE P.Name like '%" + name+ "%' ;");

            }

            public static DataTable ValidateElector(String guid) 
            {
               return utilities.sql.Get("SELECT * from PoolElectors where IdElectors ='" + guid + "' and isActive=1;");
            }
    }
    }
}

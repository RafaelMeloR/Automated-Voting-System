using AVS_Desktop.DataAccessLayer;
using AVS_Desktop.ViewModels;
using AVS_Desktop.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace AVS_Desktop.Controls
{
    internal class VoteControl
    {
     
        static List<CandidateViewModel> CandidatesList = new List<CandidateViewModel>();
        private static Guid voteSelection;
        public static string IdElector { get; set; }
        public void Open(string id)
        {
            IdElector = id;
            Vote vote = new Vote();
            vote.Show();
        }
        public void SetGuid(Guid guid)
        {
            voteSelection = guid;
        }

        public Guid GetGuid()
        {
            return voteSelection;
        }
         
        public static List<CandidateViewModel> GetCandidates()
        {
            DataTable dt = dal.get.SelectCandidates();
             if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    CandidateViewModel candidate = new CandidateViewModel();
                    candidate.IdPerson = (int)row[0];
                    candidate.Name =(string) row[1];
                    candidate.LastName = (string) row[2];
                    candidate.Gender = (string) row[4];
                    candidate.bornDate = (DateTime)row[5];
                    candidate.Email = (string) row[6];
                    candidate.Phone =(string) row[7];
                    candidate.isActive = (bool)row[8];
                    candidate.UserId = (string) row[9];
                    if (row[10] == null)
                    {
                        candidate.ProfilePhoto = null; 
                    }
                    else
                    {
                        candidate.ProfilePhoto = (string)row[10];
                    } 
                    candidate.IdCandidate=(Guid)row[32];
                    candidate.PoliticalPartyId = (int)row[33];
                    candidate.ElectoralPosition = (string) row[34];
                    candidate.ElectoralDistrict = (string) row[36];
                    candidate.ElectoralMunicipality = (string) row[35];
                    candidate.isActiveCandidate = (bool)row[37];
                    candidate.NamePoliticalParty = (string)row[40];
                    candidate.UserName = (string) row[18];
                    candidate.PostalCode = (string)row[12];
                    candidate.Thoroughfare = (string)row[13];
                    candidate.ApartmentNumber = (string)row[14];
                    candidate.City = (string)row[15];

                    CandidatesList.Add(candidate);

                }
            }
            return CandidatesList;

        }

        public async Task VoteAsync()
        {           
            Guid idVote = Guid.NewGuid();
            await dal.set.InserIntoVoting(Guid.NewGuid(), IdElector);
            await dal.set.InserIntoVote(Guid.NewGuid(), IdElector, GetGuid().ToString());
            await dal.set.UpdatePoolElectors(IdElector);
            
        }
    }
}

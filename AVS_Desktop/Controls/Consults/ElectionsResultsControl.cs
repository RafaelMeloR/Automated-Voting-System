using AVS_Desktop.DataAccessLayer;
using AVS_Desktop.Models;
using AVS_Desktop.Models.response;
using AVS_Desktop.ViewModels;
using AVS_Desktop.Views.Consults;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using static AVS_Desktop.utilities;
//API IMPLEMENTED
namespace AVS_Desktop.Controls.Consults
{
    internal class ElectionsResultsControl
    {
        public static async Task<List<CountVotes>> CountVotesAsync(ElectionsResults obj)
        {
            HttpClient httpClient = API.conn();
            var response = await httpClient.GetStringAsync("SelectAllCandidateformation");
            CandidateResponse response_Json = JsonConvert.DeserializeObject<CandidateResponse>(response);
            List<Candidate> candidates = response_Json.candidatesM;

            /* response = await httpClient.GetStringAsync("CountVotes/"+candidates);
             CountVotesResponse countVotesResponse = JsonConvert.DeserializeObject<CountVotesResponse>(response);
             List<CountVotes> votes = countVotesResponse.votes;*/ 

            List<CountVotes> votes = dal.get.CountVotes(candidates);
            var candidateIdColumn = new DataGridTextColumn()
            {
                Header = "Candidate ID",
                Binding = new Binding("CandidateId")
            };
            var candidateName = new DataGridTextColumn()
            {
                Header = "Candidate Name",
                Binding = new Binding("Name")
            };

            var countColumn = new DataGridTextColumn()
            {
                Header = "Count",
                Binding = new Binding("Count")
            };

            obj.resultDG.Columns.Add(candidateIdColumn);
            obj.resultDG.Columns.Add(candidateName);
            obj.resultDG.Columns.Add(countColumn);
            int counter = 0;
            foreach (CountVotes vote in votes)
            {
                response = await httpClient.GetStringAsync("SelectPersonById/" + candidates[counter].PersonId);
                PersonResponse personResponse = JsonConvert.DeserializeObject<PersonResponse>(response);
                PersonViewModel person = personResponse.person;

                 
                var dataItem = new 
                {
                    CandidateId = vote.CandidateId,
                    Name = person.Name,
                    Count = vote.Count
                }; 
                obj.resultDG.Items.Add(dataItem);
                counter++;
            }
            return votes;
        }

 
    }
}

using AVS_Desktop.DataAccessLayer;
using AVS_Desktop.Models;
using AVS_Desktop.Models.response;
using AVS_Desktop.Views.Consults;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using static AVS_Desktop.utilities;

//API IMPLEMENTED
namespace AVS_Desktop.Controls.Consults
{
    internal class CandidateInformationControl
    {
        static readonly string sesion = LoginControl.sesion;
        internal static async Task getCandidatesInformationAsync(CanadidateInformation obj)
        {
            HttpClient httpClient = API.conn();
            var response = await httpClient.GetStringAsync("SelectPersonByEmail/" + sesion);
            PersonResponse personResponse = JsonConvert.DeserializeObject<PersonResponse>(response);
            Person person = personResponse.personM;

            response = await httpClient.GetStringAsync("SelectCandidateformation/" + person.Id);
            CandidateResponse candidateResponse = JsonConvert.DeserializeObject<CandidateResponse>(response);
            Candidate candidate = candidateResponse.candidateM;

                obj.nameLabel.Content = person.Name; 
                obj.emLabel.Content = candidate.ElectoralMunicipality;
                obj.edLabel.Content = candidate.ElectoralDistrict;
                obj.epLabel.Content = candidate.ElectoralPosition;
                if (candidate.isActive)
                {
                    obj.statusLabel.Content = "Active";
                }
                else
                {
                    obj.statusLabel.Content = "Inactive";
                } 
        }
    }
}
using AVS_Desktop.DataAccessLayer;
using AVS_Desktop.Models.response;
using Azure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using static AVS_Desktop.utilities;

//API IMPLEMENTED
namespace AVS_Desktop.Controls.Consults
{
    public class ConsultCandidatesControl
    {
        public async Task<DataGrid> showAllCandidates(DataGrid dg)
        {
            HttpClient httpClient = API.conn();
            var response = await httpClient.GetStringAsync("SelectCandidates");
            CandidateResponse response_Json = JsonConvert.DeserializeObject<CandidateResponse>(response);
            dg.ItemsSource = response_Json.candidates;
             
            return dg;
        }
        public async Task<DataGrid> showCandidateByName(DataGrid dg, String name)
        {
            HttpClient httpClient = API.conn();
            var response = await httpClient.GetStringAsync("SelectCandidateByName/"+name);
            CandidateResponse response_Json = JsonConvert.DeserializeObject<CandidateResponse>(response);
            dg.ItemsSource = response_Json.candidates;

            return dg; 
        }

    }
}

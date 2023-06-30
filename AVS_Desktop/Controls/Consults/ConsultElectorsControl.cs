using AVS_Desktop.DataAccessLayer;
using AVS_Desktop.Models.response;
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
    internal class ConsultElectorsControl
    {
        public async Task<DataGrid> showAllElectors(DataGrid dg)
        {
            HttpClient httpClient = API.conn();
            var response = await httpClient.GetStringAsync("SelectElectors");
            ElectorResponse response_Json = JsonConvert.DeserializeObject<ElectorResponse>(response);
            dg.ItemsSource = response_Json.electors;

            return dg;
        } 
        public async Task<DataGrid> showElectorsByName(DataGrid dg, String name)
        {
            HttpClient httpClient = API.conn();
            var response = await httpClient.GetStringAsync("SelectElectorsByName/" + name);
            ElectorResponse response_Json = JsonConvert.DeserializeObject<ElectorResponse>(response);
            dg.ItemsSource = response_Json.electors;

            return dg;
        }
    }
}

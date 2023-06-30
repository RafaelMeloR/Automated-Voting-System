using AVS_Desktop.DataAccessLayer;
using AVS_Desktop.Models;
using AVS_Desktop.Models.response;
using AVS_Desktop.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static AVS_Desktop.utilities;
//API IMPLEMENTED
namespace AVS_Desktop.Controls
{
    internal class LoginVoteControl
    {
        public async static Task<bool> ValidateUID(String guid, VoteLogin obj)
        {
            HttpClient httpClient = API.conn();
            var response = await httpClient.GetStringAsync("ValidateElector/" + guid);
            PoolElectorsResponse response_Json = JsonConvert.DeserializeObject<PoolElectorsResponse>(response);
            PoolElectors pool = response_Json.poolElector; 

            bool result = true; 
            if (response_Json.statusCode != 200)
            { 
                result = false;
                MessageBox.Show("Unique User ID INVALID ");
                obj.Uid.Text= string.Empty;
            }
            else
            {
                
                VoteControl vc = new VoteControl();
                vc.Open(guid);
                obj.Close();

            }
            return result;

        }
    }
}

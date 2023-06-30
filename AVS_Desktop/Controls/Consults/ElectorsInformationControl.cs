using AVS_Desktop.DataAccessLayer;
using AVS_Desktop.Models;
using AVS_Desktop.Views.Consults;
using Azure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static AVS_Desktop.utilities;
using System.Windows.Controls;
using AVS_Desktop.ViewModels;
using AVS_Desktop.Models.response;
using System.Text.Encodings.Web;
using System.Web;

//API IMPLEMENTED
namespace AVS_Desktop.Controls.Consults
{
    public class ElectorsInformationControl
    {
        static readonly string sesion = LoginControl.sesion;
        public static async void getElectorsInformation(ElectorInformation obj)
        {
            HttpClient httpClient = API.conn();
            var response = await httpClient.GetStringAsync("SelectPersonByEmail/" + sesion);
            PersonResponse personResponse = JsonConvert.DeserializeObject<PersonResponse>(response);
            Person person = personResponse.personM;

            response = await httpClient.GetStringAsync("SelectAllHashPoolElector");
            PoolElectorsResponse HashPoolElectorsResponse = JsonConvert.DeserializeObject<PoolElectorsResponse>(response);
            List<PoolElectors> hash = HashPoolElectorsResponse.poolElectors;

            response = await httpClient.GetStringAsync("SelectElectorInformation/" + person.Id);
            ElectorResponse electorResponse = JsonConvert.DeserializeObject<ElectorResponse>(response);
            Elector elector = electorResponse.electorModel;

            foreach (PoolElectors HashPool in hash)
                { 
                    if (utilities.tools.VerifyHash(HashPool.Hash, person.Id.ToString()))
                    {
                        DataTable dtIn = dal.get.SelectPoolElector(HashPool.Hash);//Problem pasing a hash by url API
                        if (dtIn.Rows.Count == 0)
                        {
                            MessageBox.Show("Please contact the administration, Your Information it's not available");
                        }
                        else
                        {
                            foreach (DataRow rowIn in dtIn.Rows)
                            {
                                obj.ueanLabel.Content = rowIn[0].ToString();
                                if ((bool)rowIn[1])
                                    obj.statusLabel.Content = "Active";
                                else
                                    obj.statusLabel.Content = "Inactive";
                            }
                        } 

                
                obj.nameLabel.Content = person.Name;
                obj.emLabel.Content = elector.ElectoralMunicipality;
                obj.edLabel.Content = elector.ElectoralDistrict;
                }
            }
        }
    }
}

using AVS_Desktop.Views;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Windows;
using static AVS_Desktop.utilities;
using AVS_Desktop.ViewModels;
using AVS_Desktop.Models.response;
using AVS_Desktop.Models;
using Candidate = AVS_Desktop.Views.Candidate;
//API IMPLEMENTED
namespace AVS_Desktop.Controls
{
    internal class LoginControl
    {
        public  static string sesion;
        public async void Login(Login obj)
        {
            bool auth = utilities.tools.VerifyHashPassword(obj.user.Text, obj.password.Password);
            if (auth)
            {
                sesion = obj.user.Text;

                HttpClient httpClient = API.conn();
                var response = await httpClient.GetStringAsync("SelectRoleIdFromUsers/" + obj.user.Text);
                PersonResponse response_Json = JsonConvert.DeserializeObject<PersonResponse>(response);
                PersonViewModel person = response_Json.person;
                 
                response = await httpClient.GetStringAsync("SelectRoleName/" + person.RoleId);
                RoleResponse roleResponse = JsonConvert.DeserializeObject<RoleResponse>(response);
                Role role = roleResponse.role; 
                String roleName = role.Name;

                if (roleName == "admin")
                {
                    Admin admin = new Admin();
                    admin.Show();
                }
                else if (roleName == "candidates")
                {
                    Candidate candidates = new Candidate();
                    candidates.Show();
                }
                else if (roleName == "electors")
                {
                    Electors electors = new Electors();
                    electors.Show();
                }
                else if (roleName == "politicalParties")
                {
                    MessageBox.Show("Implementing");
                }
                
                obj.Close();
            }
            else
            {
                MessageBox.Show("User or Password incorrect"); 
                obj.user.Text=string.Empty;
                obj.password.Clear();
            }
        }
    }
}

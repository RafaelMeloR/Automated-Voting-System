using AVS_Desktop.DataAccessLayer;
using AVS_Desktop.Models;
using AVS_Desktop.Models.response;
using AVS_Desktop.ViewModels;
using AVS_Desktop.Views;
using Azure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using static AVS_Desktop.utilities;
using Candidate = AVS_Desktop.Models.Candidate;
//API IMPLEMENTED
namespace AVS_Desktop.Controls
{
    public class usersValidationControl
    {
        private static int PersonId;
        private static string role;
        private static string sesion = LoginControl.sesion;
        
        public static async Task<bool> fillGrid(usersValidation obj)
        {
            HttpClient httpClient = API.conn();
            var response = await httpClient.GetStringAsync("SelectPeopleValidation");
            PersonResponse response_Json = JsonConvert.DeserializeObject<PersonResponse>(response);
            obj.usersGrid.ItemsSource = response_Json.people;

            return true; 
        } 
        public static async Task CopyFromGridToTextbox(usersValidation obj)
        {

            PersonViewModel selected_row = obj.usersGrid.SelectedItem as PersonViewModel;
            if (selected_row != null)
            {
                HttpClient httpClient = API.conn();
                var response = await httpClient.GetStringAsync("SelectPersonByEmail/" + selected_row.Email);
                PersonResponse response_Json = JsonConvert.DeserializeObject<PersonResponse>(response);
                Person person = response_Json.personM;  
                PersonId= person.Id;
                if (selected_row != null)
                {
                    obj.name.Text = selected_row.Name;
                    obj.lastname.Text = selected_row.LastName;
                    obj.gender.Items.Add(selected_row.Gender);// TO CHECK
                    obj.email.Text = selected_row.Email;
                    obj.phone.Text = selected_row.Phone;
                    obj.street.Text = selected_row.Thoroughfare;
                    obj.apartment.Text = selected_row.ApartmentNumber;
                    obj.postalCode.Text = selected_row.PostalCode;
                    obj.city.Text = selected_row.City;
                    if (selected_row.RoleName == "electors")
                    {
                        response = await httpClient.GetStringAsync("SelectElectorInformation/" + person.Id);
                        ElectorResponse electorResponse = JsonConvert.DeserializeObject<ElectorResponse>(response);
                        Elector elector = electorResponse.electorModel;
                        role = "electors";
                        obj.electorsRB.IsChecked = true; 
                        obj.electoralditrict.Text = elector.ElectoralDistrict;
                        obj.electoralmunicipality.Text = elector.ElectoralMunicipality;

                    }
                    else if (selected_row.RoleName == "candidates")
                    {
                        response = await httpClient.GetStringAsync("SelectCandidateformation/" + person.Id);
                        CandidateResponse candidateResponse = JsonConvert.DeserializeObject<CandidateResponse>(response);
                        Candidate candidate = candidateResponse.candidateM;
                        role = "candidates";
                        obj.candidatesRB.IsChecked = true;
                        obj.electoralditrict.Text = candidate.ElectoralDistrict;
                        obj.electoralmunicipality.Text = candidate.ElectoralMunicipality;
                        obj.electoralPosition.Text = candidate.ElectoralPosition;
                    }
                }
            }
        }
        public static void isChecked(usersValidation obj)
        {
            if (obj.electorsRB.IsChecked == true)
            {
                role = "electors";
                obj.electors.Visibility = Visibility.Visible;
                obj.electors.Visibility = Visibility.Visible;
                obj.electoralPosition.Visibility = Visibility.Hidden;
                obj.epLabel.Visibility = Visibility.Hidden;
                obj.politicalParty.Visibility = Visibility.Hidden;
                obj.policalpartyLabel.Visibility = Visibility.Hidden;
            }
            else if (obj.candidatesRB.IsChecked == true)
            {
                role = "candidates";
                obj.electors.Visibility = Visibility.Visible;
                obj.electors.Visibility = Visibility.Visible;
                obj.electoralPosition.Visibility = Visibility.Visible;
                obj.epLabel.Visibility = Visibility.Visible;
                obj.politicalParty.Visibility = Visibility.Visible;
                obj.policalpartyLabel.Visibility = Visibility.Visible;
            } 
        } 
        public static void showPeopleByName(usersValidation obj)
        {
            utilities.AVS.DataTableToDataGrid(obj.usersGrid, dal.get.SelectPeopleByNameValidation(obj.search.Text));

        } 
        public static void clean(usersValidation obj)
        {
            obj.name.Text = string.Empty;
            obj.email.Text = string.Empty;
            obj.lastname.Text = string.Empty; 
            obj.phone.Text = string.Empty;
            obj.street.Text = string.Empty;
            obj.city.Text = string.Empty;
            obj.apartment.Text = string.Empty;
            obj.postalCode.Text = string.Empty;
            obj.search.Text = string.Empty;
            obj.electoralPosition.Text = string.Empty;
            obj.electoralditrict.Text = string.Empty;
            obj.electoralmunicipality.Text = string.Empty;
            MessageBox.Show("Operation completed");
            fillGrid(obj);
        }

        public static async void Validate(usersValidation obj)
        {
            HttpClient httpClient = utilities.API.conn();
            var response = await httpClient.GetStringAsync("SelectAllHashPoolElector");
            PoolElectorsResponse HashPoolElectorsResponse = JsonConvert.DeserializeObject<PoolElectorsResponse>(response);
            List<PoolElectors> hash = HashPoolElectorsResponse.poolElectors;

            string guid = ""; 
            foreach (PoolElectors HashPool in hash)
            {
                if (utilities.tools.VerifyHash(HashPool.Hash, Convert.ToString(PersonId)))  
                {
                    DataTable dtIn = dal.get.SelectPoolElector(HashPool.Hash);

                    foreach (DataRow rowIn in dtIn.Rows)
                    {
                        guid = rowIn[0].ToString();
                    }
                }
            }

            Validate validate = new Validate();
            validate.IdPerson=PersonId;
            validate.Role = role;
            validate.guid = guid; 
            var responseValidate = await httpClient.PutAsJsonAsync<Validate>("Validate/", validate);
            MessageBox.Show(response.ToString());
            clean(obj);
        }


    }
}

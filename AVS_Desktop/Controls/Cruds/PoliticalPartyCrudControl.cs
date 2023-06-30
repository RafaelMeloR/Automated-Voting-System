using AVS_Desktop.DataAccessLayer;
using AVS_Desktop.Models;
using AVS_Desktop.Models.response;
using AVS_Desktop.Views;
using AVS_Desktop.Views.CRUD;
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

namespace AVS_Desktop.Controls.Cruds
{
    public class PoliticalPartyCrudControl
    {
        static int id = 0;
        public static async Task Insert(PoliticalPartyCrud obj)
        {
            PoliticalParty politicalParty = new PoliticalParty();
            politicalParty.Name = obj.Name.Text; 
            await dal.set.InsertPoliticalParty(politicalParty); 
            clean(obj);
        } 
        public static async Task Update(PoliticalPartyCrud obj)
        {
            PoliticalParty politicalParty = new PoliticalParty();
            politicalParty.Name = obj.Name.Text;
            politicalParty.Id = id;
            await dal.set.UpdatePoliticalParty(politicalParty); 
            clean(obj);
        } 
        public static async Task Delete(PoliticalPartyCrud obj)
        {
            PoliticalParty politicalParty = new PoliticalParty();
            politicalParty.Name = obj.Name.Text;
            politicalParty.Id = id;
            await dal.set.DeletePoliticalParty(politicalParty); 
            clean(obj);
        } 
        public static async Task<bool> fillGrid(PoliticalPartyCrud obj)
        {
            HttpClient httpClient = API.conn();
            var response = await httpClient.GetStringAsync("selectPoliticalsParties");
            PoliticalPartyResponse response_Json = JsonConvert.DeserializeObject<PoliticalPartyResponse>(response);
            obj.PartiesGrid.ItemsSource = response_Json.politicalParties;

            return true; 
        } 
        public static void CopyFromGridToTextbox(PoliticalPartyCrud obj)
        {
            PoliticalParty selected_row = obj.PartiesGrid.SelectedItem as PoliticalParty;
            if (selected_row != null)
            {
                if (selected_row != null)
                {
                    obj.Name.Text = selected_row.Name;
                    id=(int) selected_row.Id;
                }
            }
        } 
        public static void showPeopleByName(PoliticalPartyCrud obj)
        {
            /*HttpClient httpClient = API.conn();
            var response = await httpClient.GetStringAsync("selectPoliticalPartyByName/" + obj.search.Text);
            PoliticalPartyResponse response_Json = JsonConvert.DeserializeObject<PoliticalPartyResponse>(response);
            obj.PartiesGrid.ItemsSource = response_Json.politicalParties;*/

            PoliticalParty politicalParty = new PoliticalParty();
            politicalParty.Name=obj.search.Text;
            utilities.AVS.DataTableToDataGrid(obj.PartiesGrid, dal.get.selectPoliticalPartyByName(politicalParty)); 
        } 
        public static void clean(PoliticalPartyCrud obj)
        {
            obj.Name.Text = string.Empty; 
            obj.search.Text = string.Empty;
            MessageBox.Show("Operation completed");
            fillGrid(obj);
        }
    }
}

using AVS_Desktop.DataAccessLayer;
using AVS_Desktop.Models;
using AVS_Desktop.Views;
using AVS_Desktop.Views.CRUD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
        public static bool fillGrid(PoliticalPartyCrud obj)
        {
            DataTable dt = dal.get.selectPoliticalsParties();
            utilities.AVS.DataTableToDataGrid(obj.PartiesGrid, dt);
            return true;
        } 
        public static void CopyFromGridToTextbox(PoliticalPartyCrud obj)
        {
            DataRowView selected_row = obj.PartiesGrid.SelectedItem as DataRowView;
            if (selected_row != null && selected_row.Row != null)
            {
                if (selected_row != null)
                {
                    obj.Name.Text = selected_row[1].ToString();
                    id=(int) selected_row[0];
                }
            }
        } 
        public static void showPeopleByName(PoliticalPartyCrud obj)
        {
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

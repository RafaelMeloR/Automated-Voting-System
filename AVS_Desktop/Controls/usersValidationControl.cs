using AVS_Desktop.DataAccessLayer;
using AVS_Desktop.Models;
using AVS_Desktop.Views;
using System.Data;
using System.Threading.Tasks;
using System.Windows;

namespace AVS_Desktop.Controls
{
    public class usersValidationControl
    {
        private static int PersonId;
        private static string role;
        private static string sesion = LoginControl.sesion;
        
        public static bool fillGrid(usersValidation obj)
        {
            DataTable dt = dal.get.SelectPeopleValidation();
            utilities.AVS.DataTableToDataGrid(obj.usersGrid, dt);
            return true;
        } 
        public static async Task CopyFromGridToTextbox(usersValidation obj)
        {

            DataRowView selected_row = obj.usersGrid.SelectedItem as DataRowView;
            if (selected_row != null && selected_row.Row != null)
            {
                DataTable dt = await dal.get.SelectPersonUserID(selected_row[3].ToString());
                foreach (DataRow row in dt.Rows)
                {
                    PersonId = (int)row[1];
                }

                if (selected_row != null)
                {
                    obj.name.Text = selected_row[0].ToString();
                    obj.lastname.Text = selected_row[1].ToString();
                    obj.gender.Items.Add(selected_row[2].ToString());// TO CHECK
                    obj.email.Text = selected_row[3].ToString();
                    obj.phone.Text = selected_row[4].ToString();
                    obj.street.Text = selected_row[5].ToString();
                    obj.apartment.Text = selected_row[6].ToString();
                    obj.postalCode.Text = selected_row[7].ToString();
                    obj.city.Text = selected_row[8].ToString();
                    if (selected_row[11].ToString() == "electors")
                    {
                        obj.electorsRB.IsChecked = true;
                        Elector elector = dal.get.SelectElectorInformation(PersonId);
                        obj.electoralditrict.Text = elector.ElectoralDistrict;
                        obj.electoralmunicipality.Text = elector.ElectoralMunicipality;

                    }
                    else if (selected_row[11].ToString() == "candidates")
                    {
                        obj.candidatesRB.IsChecked = true;
                        Models.Candidate candidate = await dal.get.SelectCandidateformation(PersonId);
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

        public static void Validate(usersValidation obj)
        {
            string guid = "";
            DataTable dt = dal.get.SelectAllHashPoolElector();
            foreach (DataRow row in dt.Rows)
            {
                if (utilities.tools.VerifyHash(row[0].ToString(), PersonId.ToString()))
                {
                    DataTable dtIn = dal.get.SelectPoolElector(row[0].ToString());

                    foreach (DataRow rowIn in dtIn.Rows)
                    {
                        guid = rowIn[0].ToString();
                    }
                }
            }
            _ = dal.set.Validate(PersonId, role, guid);
            clean(obj);
        }


    }
}

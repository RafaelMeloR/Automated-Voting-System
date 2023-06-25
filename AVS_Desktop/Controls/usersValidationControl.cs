using AVS_Desktop.DataAccessLayer;
using AVS_Desktop.Models;
using AVS_Desktop.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows; 

namespace AVS_Desktop.Controls
{
    public class usersValidationControl
    {
        private static int PersonId;

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
                obj.electors.Visibility = Visibility.Visible;
                obj.electors.Visibility = Visibility.Visible;
                obj.electoralPosition.Visibility = Visibility.Hidden;
                obj.epLabel.Visibility = Visibility.Hidden;
                obj.politicalParty.Visibility = Visibility.Hidden;
                obj.policalpartyLabel.Visibility = Visibility.Hidden;
            }
            else if (obj.candidatesRB.IsChecked == true)
            {
                obj.electors.Visibility = Visibility.Visible;
                obj.electors.Visibility = Visibility.Visible;
                obj.electoralPosition.Visibility = Visibility.Visible;
                obj.epLabel.Visibility = Visibility.Visible;
                obj.politicalParty.Visibility = Visibility.Visible;
                obj.policalpartyLabel.Visibility = Visibility.Visible;
            } 
        }
        public static async Task Insert(usersValidation obj)
        {
            Person person = new Person();  

            person.Name = obj.name.Text;
            person.LastName = obj.lastname.Text;
            person.Gender = obj.gender.Text;
            person.bornDate = (DateTime)obj.birthday.SelectedDate;
            person.Email = obj.email.Text;
            person.Phone = obj.phone.Text; 

            DataTable dt = await dal.get.SelectPersonUserID(obj.email.Text);
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    person.Id = (int)row[1]; 
                }
            }

            _ = dal.set.UpdatePerson(person);   
             
            if (obj.electorsRB.IsChecked == true)
            {
                Elector elector = new Elector();
                elector.ElectoralDistrict = obj.electoralditrict.Text;
                elector.ElectoralMunicipality = obj.electoralmunicipality.Text;
                elector.PersonId = person.Id; 

                _ = dal.set.UpdateElector(elector);
            }
            else if (obj.candidatesRB.IsChecked == true)
            { 
                Models.Candidate candidate = new Models.Candidate();
                candidate.ElectoralDistrict = obj.electoralditrict.Text;
                candidate.ElectoralMunicipality = obj.electoralmunicipality.Text;
                candidate.ElectoralPosition = obj.electoralPosition.Text;
                candidate.PersonId = person.Id;
                _ = dal.set.UpdateCandidate(candidate);
            }
           
            clean(obj);
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
    }
}

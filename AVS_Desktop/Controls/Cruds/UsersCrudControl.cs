using Automated_Voting_System.Entities;
using AVS_Desktop.DataAccessLayer;
using AVS_Desktop.Models;
using AVS_Desktop.Views.CRUD;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Candidate = AVS_Desktop.Models.Candidate;

namespace AVS_Desktop.Controls.Cruds
{
    public class UsersCrudControl
    {
        private static int PersonId;
        public static void isChecked(UsersCrud obj)
        {
            if (obj.electorsRB.IsChecked == true)
            {
                obj.electors.Visibility = Visibility.Visible;
                obj.electoralPosition.Visibility = Visibility.Hidden;
                obj.epLabel.Visibility = Visibility.Hidden;
                obj.politicalParty.Visibility = Visibility.Hidden;
                obj.policalpartyLabel.Visibility = Visibility.Hidden;
            }
            else if (obj.candidatesRB.IsChecked == true)
            {
                obj.electors.Visibility = Visibility.Visible;
                obj.electoralPosition.Visibility = Visibility.Visible;
                obj.epLabel.Visibility = Visibility.Visible;
                obj.politicalParty.Visibility = Visibility.Visible;
                obj.policalpartyLabel.Visibility = Visibility.Visible;
            }
            else if (obj.adminRB.IsChecked == true)
            {
                obj.electors.Visibility = Visibility.Hidden;
                obj.electoralPosition.Visibility = Visibility.Hidden;
                obj.politicalParty.Visibility = Visibility.Hidden;
                obj.policalpartyLabel.Visibility = Visibility.Hidden;
            }
        }
        public static bool fillGrid(UsersCrud obj)
        {
            DataTable dt = dal.get.SelectPeople();
            utilities.AVS.DataTableToDataGrid(obj.usersGrid, dt); 
            return true;
        }

        public static void fillComboPolitticalParty(UsersCrud obj)
        { 
            DataTable dt = dal.get.selectPoliticalsParties();
            foreach (DataRow row in dt.Rows)
            {
                ComboBoxItem comboBoxItem = new ComboBoxItem();
                comboBoxItem.Content = row[1];  
                obj.politicalParty.Items.Add(comboBoxItem);
            }
        }

        public static async Task CopyFromGridToTextbox(UsersCrud obj)
        {
           
            DataRowView selected_row = obj.usersGrid.SelectedItem as DataRowView;
            if (selected_row != null && selected_row.Row != null)
            {
                DataTable dt = await dal.get.SelectPersonUserID(selected_row[3].ToString());
                foreach (DataRow row in dt.Rows)
                {
                    PersonId =(int) row[1];
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
                        Candidate candidate =  await dal.get.SelectCandidateformation(PersonId);
                        obj.electoralditrict.Text = candidate.ElectoralDistrict;
                        obj.electoralmunicipality.Text = candidate.ElectoralMunicipality;
                        obj.electoralPosition.Text = candidate.ElectoralPosition;
                    }
                    else 
                    {
                        obj.adminRB.IsChecked = true;
                    }
                }
            }
        }

        public static async Task Insert(UsersCrud obj)
        {
            Person person = new Person();
            Address address = new Address();
            User user = new User();

            person.Name = obj.name.Text;
            person.LastName = obj.lastname.Text;
            person.Gender = obj.gender.Text;
            person.bornDate = (DateTime)obj.birthday.SelectedDate;
            person.Email = obj.email.Text;
            person.Phone = obj.phone.Text;

            address.Thoroughfare = obj.street.Text;
            address.City = obj.city.Text;
            address.ApartmentNumber = obj.apartment.Text;
            address.PostalCode = obj.postalCode.Text;

            user.Id= Guid.NewGuid().ToString();
            user.UserName= obj.email.Text;
            user.NormalizedUserName = obj.email.Text;
            user.Email = obj.email.Text;
            user.NormalizedEmail = obj.email.Text;
            user.EmailConfirmed = false;
            user.PasswordHash = utilities.tools.HashPassword(obj.password.Password);
            user.PhoneNumberConfirmed= false;
            user.TwoFactorEnabled = false;
            user.LockoutEnabled = false;
            user.AccessFailedCount = 0;
            person.UserId=user.Id;  
            
            if (obj.electorsRB.IsChecked == true)
            {
                Elector elector=new Elector();
                elector.id=Guid.NewGuid(); 
                elector.ElectoralMunicipality=obj.electoralmunicipality.Text;
                elector.ElectoralDistrict=obj.electoralditrict.Text;
                elector.isActive=true;
                user.Role = "electors";
                user.RoleId = await dal.get.SelectRoleIdFromRole(user.Role);
                await dal.set.CreatePerson(person, address, user);
                person.Id = await dal.get.getLastIdInserted();
                elector.PersonId = person.Id;
                await dal.set.CreateElector(elector);
            }
            else
             if (obj.candidatesRB.IsChecked == true)
            {
                user.Role = "candidates";
                user.RoleId = await dal.get.SelectRoleIdFromRole(user.Role);
                await dal.set.CreatePerson(person, address, user);
                Candidate candidate=new Candidate();
                candidate.Id = Guid.NewGuid(); 
                candidate.ElectoralMunicipality = obj.electoralmunicipality.Text;
                candidate.ElectoralDistrict = obj.electoralditrict.Text;
                candidate.ElectoralPosition=obj.electoralPosition.Text;
                candidate.isActive = true;
                candidate.PoliticalPartyId =1+((int) obj.politicalParty.SelectedIndex); 
                person.Id = await dal.get.getLastIdInserted();
                candidate.PersonId = person.Id;
                await dal.set.createCandidate(candidate);
            }
            else
                if (obj.adminRB.IsChecked==true)
            {
                user.Role = "admin";
                user.RoleId = await dal.get.SelectRoleIdFromRole(user.Role);
                await dal.set.CreatePerson(person, address, user);
            }
            clean(obj);
        }

        public static async Task Update(UsersCrud obj)
        {
            Person person = new Person();
            Address address = new Address();
            User user = new User();

            person.Name = obj.name.Text;
            person.LastName = obj.lastname.Text;
            person.Gender = obj.gender.Text;
            person.bornDate=(DateTime) obj.birthday.SelectedDate;
            person.Email = obj.email.Text;
            person.Phone=obj.phone.Text;

            address.Thoroughfare = obj.street.Text;
            address.City = obj.city.Text;
            address.ApartmentNumber=obj.apartment.Text;
            address.PostalCode = obj.postalCode.Text;
            
            user.Email = obj.email.Text;
            user.PasswordHash=utilities.tools.HashPassword( obj.password.Password); 

            DataTable dt = await dal.get.SelectPersonUserID(obj.email.Text);
            if (dt != null) 
            { 
                foreach(DataRow row in dt.Rows) 
                {
                    person.Id =(int) row[1];
                    user.Id=(string) row[0];
                    address.PersonId=(int) row[1];
                }
            }

            _ = dal.set.UpdatePerson(person);
            _ = dal.set.UpdateAddress(address);
            if (user.PasswordHash == "")
            {
                _ = dal.set.UpdateUserNoPassword(user);
            }
            else
            {
                _ = dal.set.UpdateUser(user);
            }

            if (obj.electorsRB.IsChecked == true)
            {
                Elector elector = new Elector();
                elector.ElectoralDistrict=obj.electoralditrict.Text;
                elector.ElectoralMunicipality=obj.electoralmunicipality.Text;
                elector.PersonId=person.Id;
                user.Role = "electors";

                _ = dal.set.UpdateElector(elector);
            }
            else if (obj.candidatesRB.IsChecked == true)
            {
                user.Role = "candidates";
                Candidate candidate = new Candidate();
                candidate.ElectoralDistrict = obj.electoralditrict.Text;
                candidate.ElectoralMunicipality = obj.electoralmunicipality.Text;
                candidate.ElectoralPosition=obj.electoralPosition.Text;
                candidate.PersonId= person.Id;
                _ = dal.set.UpdateCandidate(candidate);
            }
            else if (obj.adminRB.IsChecked == true)
            {
                user.Role = "admin";
            }
            clean(obj);
        }

        public static bool validateForm(UsersCrud obj) 
        {
            bool result=true;
            
            TextBox[] requiredInputs = new TextBox[]
           {
                obj.name,
                obj.lastname,  
                obj.email,
                obj.phone,
                obj.street,
                obj.apartment,
                obj.postalCode,
                obj.city
           };
            utilities.tools.ValidateInputs(requiredInputs);
            TextBox[] requiredInputsElectors = new TextBox[]
            {
                 obj.electoralmunicipality,
                 obj.electoralditrict
            };
            TextBox[] requiredInputsCandidates = new TextBox[]
           {
                 obj.electoralmunicipality,
                 obj.electoralditrict,
                 obj.electoralPosition
           };
            utilities.tools.ValidateInputs(requiredInputs);

            if (obj.electorsRB.IsChecked == true)
            {
                utilities.tools.ValidateInputs(requiredInputsElectors);
            }
            else
            if (obj.candidatesRB.IsChecked == true)
            {
                utilities.tools.ValidateInputs(requiredInputsCandidates);
            }

            if (obj.candidatesRB.IsChecked == false && obj.electorsRB.IsChecked == false && obj.adminRB.IsChecked == false)
            { 
                result=false;
                MessageBox.Show("Select a option from the radio buttoms");
            }

            return result;
        }

        public static void Delete(UsersCrud obj)
        {
            if (obj.email.Text == string.Empty || obj.email.Text == "")
            {
                MessageBox.Show("Please fill the email to proceed");
            }
            else
            {
                Person person = new Person();
                person.Email = obj.email.Text;
                _ = dal.set.deleteAddress(person);
                _ = dal.set.deletePerson(person);
                _ = dal.set.deleteRolUser(person);
                _ = dal.set.deleteUser(person);
                if (obj.electorsRB.IsChecked == true)
                {
                    _ = dal.set.deleteElector(person);
                }
                else if (obj.candidatesRB.IsChecked == true)
                {
                    _ = dal.set.deleteCandidate(person);
                }
            }
            clean(obj);
        }
        public static void showPeopleByName(UsersCrud obj)
        {
            utilities.AVS.DataTableToDataGrid(obj.usersGrid, dal.get.SelectPeopleByName(obj.search.Text));

        }

        public static void clean(UsersCrud obj)
        { 
             obj.name.Text=string.Empty;
            obj.email.Text=string.Empty;
            obj.lastname.Text=string.Empty;
            obj.password.Password=string.Empty;
            obj.phone.Text=string.Empty;
            obj.street.Text=string.Empty;
            obj.city.Text=string.Empty;
            obj.apartment.Text=string.Empty;
            obj.postalCode.Text=string.Empty;
            obj.search.Text=string.Empty;
            obj.electoralPosition.Text=string.Empty;
            obj.electoralditrict.Text=string.Empty;
            obj.electoralmunicipality.Text=string.Empty;
            MessageBox.Show("Operation completed");
            fillGrid(obj);
        }
    }
}

using AVS_Desktop.DataAccessLayer;
using AVS_Desktop.Views;
using AVS_Desktop.Views.Consults;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows;

namespace AVS_Desktop.Controls
{
    internal class LoginControl
    {
        public void Login(Login obj)
        {
            bool auth = utilities.tools.VerifyHashPassword(obj.user.Text, obj.password.Password);
            if (auth)
            {
                String role = dal.get.SelectRoleIdFromUsers(obj.user.Text);
                String roleName = dal.get.SelectRoleName(role);

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

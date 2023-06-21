using AVS_Desktop.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.AspNet.Identity;
using System.Data;

namespace AVS_Desktop.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent(); 
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            LoginControl loginControl = new LoginControl(); 
           loginControl.Login(this);
                 
        }

        private void Signup_Click(object sender, RoutedEventArgs e)
        {
            utilities.tools.OpenUrl("https://localhost:7053/SignUp/Signup?ReturnUrl=%2F");
        }
    }
}

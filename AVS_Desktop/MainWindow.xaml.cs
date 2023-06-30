using AVS_Desktop.Views;
using AVS_Desktop.Views.Consults;
using AVS_Desktop.Views.CRUD;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AVS_Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent(); 
        }
         
        private void close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void voteButton_Click(object sender, RoutedEventArgs e)
        {
            VoteLogin v = new VoteLogin();
            v.Show();
            Close();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
             Login login = new Login();
              login.Show(); 
              Close();
            


        }
    }
}

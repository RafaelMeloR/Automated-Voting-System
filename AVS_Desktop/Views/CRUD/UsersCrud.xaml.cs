using AVS_Desktop.Controls.Cruds;
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

namespace AVS_Desktop.Views.CRUD
{
    /// <summary>
    /// Interaction logic for UsersCrud.xaml
    /// </summary>
    public partial class UsersCrud : Window
    {
        public UsersCrud()
        {
            InitializeComponent();
            UsersCrudControl.fillGrid(this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (electorsRB.IsChecked==true)
            {
                electors.Visibility = Visibility.Visible;
                electoralPosition.Visibility = Visibility.Hidden;
                epLabel.Visibility = Visibility.Hidden;
            }
        }

        private void candidatesRB_Checked(object sender, RoutedEventArgs e)
        {
            if (candidatesRB.IsChecked == true)
            {
                electors.Visibility = Visibility.Visible;
                electoralPosition.Visibility = Visibility.Visible;
                epLabel.Visibility = Visibility.Visible;
            }
        }

        private void adminRB_Checked(object sender, RoutedEventArgs e)
        {
            if (adminRB.IsChecked == true)
            {
                electors.Visibility = Visibility.Hidden;
                electoralPosition.Visibility = Visibility.Hidden;
            }
        }
    }
}

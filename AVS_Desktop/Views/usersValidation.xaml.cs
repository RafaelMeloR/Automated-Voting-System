using AVS_Desktop.Controls;
using AVS_Desktop.Controls.Cruds;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AVS_Desktop.Views
{
     
    public partial class usersValidation : Window
    {
        public usersValidation()
        {
            InitializeComponent();
           _ = usersValidationControl.fillGrid(this); 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
 
        private void usersGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _ = usersValidationControl.CopyFromGridToTextbox(this);
        }   
        private void search_KeyUp(object sender, KeyEventArgs e)
        {
            usersValidationControl.showPeopleByName(this);
        }


        private void refresh_Click(object sender, RoutedEventArgs e)
        {
            usersValidationControl.fillGrid(this);
        }

        private void ValidateBT_Click(object sender, RoutedEventArgs e)
        {
            usersValidationControl.Validate(this);
        }

        private void usersGrid_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            _ = usersValidationControl.CopyFromGridToTextbox(this);
        }

        private void electorsRB_Checked(object sender, RoutedEventArgs e)
        {
            usersValidationControl.isChecked(this);
        }
    }
}

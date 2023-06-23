using AVS_Desktop.Controls.Cruds;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

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
            _ = UsersCrudControl.fillGrid(this);
            UsersCrudControl.fillComboPolitticalParty(this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            UsersCrudControl.isChecked(this);
        } 
        private void usersGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            UsersCrudControl.CopyFromGridToTextbox(this);
        }
        private void updateBT_Click(object sender, RoutedEventArgs e)
        {
            if(UsersCrudControl.validateForm(this))
                _ = UsersCrudControl.Update(this); 

        } 
        private void createBT_Click(object sender, RoutedEventArgs e)
        {
            if (UsersCrudControl.validateForm(this))
                _ = UsersCrudControl.Insert(this); 
        }

        private void deleteBT_Click(object sender, RoutedEventArgs e)
        {
            UsersCrudControl.Delete(this); 
        }

        private void search_KeyUp(object sender, KeyEventArgs e)
        {
            UsersCrudControl.showPeopleByName(this);
        }

        private void phone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            utilities.tools.numberValidation(e);
        }

        private async void refresh_Click(object sender, RoutedEventArgs e)
        {
            UsersCrudControl.fillGrid(this);
        }
    }
}

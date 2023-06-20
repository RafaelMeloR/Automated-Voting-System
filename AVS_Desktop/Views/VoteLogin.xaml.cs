using AVS_Desktop.Controls;
using System.Windows;

namespace AVS_Desktop.Views
{
    /// <summary>
    /// Interaction logic for VoteLogin.xaml
    /// </summary>
    public partial class VoteLogin : Window
    {
        public VoteLogin()
        {
            InitializeComponent();
        }

        private void validate_Click(object sender, RoutedEventArgs e)
        {
            if (Uid.Text == string.Empty)
            {
                MessageBox.Show("Please Introduce the Unique User ID");
            }
            else
            {
                LoginVoteControl.ValidateUID(Uid.Text, this);
            }
        }
    }
}

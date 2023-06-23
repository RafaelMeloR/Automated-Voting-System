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

namespace AVS_Desktop.Views
{
    /// <summary>
    /// Interaction logic for PoliticalPartyCrud.xaml
    /// </summary>
    public partial class PoliticalPartyCrud : Window
    {
        public PoliticalPartyCrud()
        {
            InitializeComponent();
            PoliticalPartyCrudControl.fillGrid(this);
        }
        private void createBT_Click(object sender, RoutedEventArgs e)
        {
            if (utilities.tools.ValidateInputs(Name))
            {
                _ = PoliticalPartyCrudControl.Insert(this);
            }
        } 
        private void updateBT_Click(object sender, RoutedEventArgs e)
        {
            if (utilities.tools.ValidateInputs(Name))
            {
                _ = PoliticalPartyCrudControl.Update(this);
            }
        } 
        private void deleteBT_Click(object sender, RoutedEventArgs e)
        {
            if (utilities.tools.ValidateInputs(Name))
            {
                _ = PoliticalPartyCrudControl.Delete(this);
            }
        }
        private void PartiesGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            PoliticalPartyCrudControl.CopyFromGridToTextbox(this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void refresh_Click(object sender, RoutedEventArgs e)
        {
            PoliticalPartyCrudControl.fillGrid(this);
        }

        private void search_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            PoliticalPartyCrudControl.showPeopleByName(this);
        }
    }
}

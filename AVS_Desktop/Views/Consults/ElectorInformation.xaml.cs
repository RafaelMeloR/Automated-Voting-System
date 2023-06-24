using AVS_Desktop.Controls.Consults;
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

namespace AVS_Desktop.Views.Consults
{
    /// <summary>
    /// Interaction logic for ElectorInformation.xaml
    /// </summary>
    public partial class ElectorInformation : Window
    {
        public ElectorInformation()
        {
            InitializeComponent();
            ElectorsInformationControl.getElectorsInformation(this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

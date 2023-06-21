using AVS_Desktop.Views.Consults;
using AVS_Desktop.Views.CRUD;
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
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void RibbonSplitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void RibbonSplitMenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            ConsultsElectors consultsElectors = new ConsultsElectors();
            consultsElectors.Show();
        }

        private void RibbonSplitMenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            ConsultsCandidates consultCandidates = new ConsultsCandidates();
            consultCandidates.Show();
        }

        private void RibbonSplitMenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            UsersCrud usersCrud = new UsersCrud();
            usersCrud.Show();
        }
    }
}

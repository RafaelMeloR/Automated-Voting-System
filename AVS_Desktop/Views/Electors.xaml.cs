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

namespace AVS_Desktop.Views
{
    /// <summary>
    /// Interaction logic for Electors.xaml
    /// </summary>
    public partial class Electors : Window
    {
        public Electors()
        {
            InitializeComponent();
        }

        private void RibbonSplitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void RibbonSplitMenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            ElectorControl.getInformation();
        }
    }
}

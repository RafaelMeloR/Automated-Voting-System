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
    /// Interaction logic for Candidates.xaml
    /// </summary>
    public partial class Candidates : Window
    {
        public Candidates()
        {
            InitializeComponent();
        }

        private void RibbonSplitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

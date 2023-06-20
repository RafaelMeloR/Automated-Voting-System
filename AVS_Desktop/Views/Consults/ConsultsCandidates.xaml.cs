using AVS_Desktop.Controls.Consults;
using AVS_Desktop.DataAccessLayer;
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
    /// Interaction logic for ConsultsCandidates.xaml
    /// </summary>
    public partial class ConsultsCandidates : Window
    {
        public ConsultsCandidates()
        {
            InitializeComponent();
           ConsultCandidatesControl ccc= new ConsultCandidatesControl();
            ccc.showAllCandidates(dgCandidates);
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void search_KeyUp(object sender, KeyEventArgs e)
        {
            ConsultCandidatesControl ccc= new ConsultCandidatesControl();
            ccc.showCandidateByName(dgCandidates,search.Text);
        }
    }
}

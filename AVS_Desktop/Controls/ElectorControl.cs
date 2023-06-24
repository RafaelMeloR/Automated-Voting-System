using AVS_Desktop.Views.Consults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AVS_Desktop.Controls
{
    internal class ElectorControl
    {
        public static void getInformation()
        {
            MessageBoxResult result = MessageBox.Show("Please Don't Share This Information with anybody\nDo you want to proceed?", "Confirmation", MessageBoxButton.OKCancel);

            if (result == MessageBoxResult.OK)
            {
                ElectorInformation electorInformation = new ElectorInformation();
                electorInformation.Show();
            }
            
        }
    }
}

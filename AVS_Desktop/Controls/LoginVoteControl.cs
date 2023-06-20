using AVS_Desktop.DataAccessLayer;
using AVS_Desktop.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AVS_Desktop.Controls
{
    internal class LoginVoteControl
    {
        public static bool ValidateUID(String guid, VoteLogin obj)
        {
            bool result = true;
            DataTable dt = dal.get.ValidateElector(guid);
            if (dt.Rows.Count==0)
            { 
                result = false;
                MessageBox.Show("Unique User ID INVALID ");
                obj.Uid.Text= string.Empty;
            }
            else
            {
                obj.Close();
                VoteControl vc = new VoteControl();
                vc.Open(guid);
                
            }
            return result;

        }
    }
}

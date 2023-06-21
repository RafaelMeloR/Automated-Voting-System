using AVS_Desktop.DataAccessLayer;
using AVS_Desktop.Views.CRUD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVS_Desktop.Controls.Cruds
{
    internal class UsersCrudControl
    {
        public static void fillGrid(UsersCrud obj)
        {
            DataTable dt = dal.get.SelectPeople();
            utilities.AVS.DataTableToDataGrid(obj.usersGrid, dt);
        }


    }
}

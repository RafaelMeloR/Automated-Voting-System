using AVS_Desktop.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AVS_Desktop.Controls.Consults
{
    internal class ConsultElectorsControl
    {
        public DataGrid showAllElectors(DataGrid dg)
        {
            utilities.AVS.DataTableToDataGrid(dg, dal.get.SelectElectors());
            return dg;
        }
        public DataGrid showElectorsByName(DataGrid dg, String name)
        {
            utilities.AVS.DataTableToDataGrid(dg, dal.get.SelectElectorsByName(name));
            return dg;
        }
    }
}

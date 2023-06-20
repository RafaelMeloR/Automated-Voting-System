using AVS_Desktop.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AVS_Desktop.Controls.Consults
{
    public class ConsultCandidatesControl
    {
        public DataGrid showAllCandidates(DataGrid dg)
        {
            utilities.AVS.DataTableToDataGrid(dg, dal.get.SelectCandidates());
            return dg;
        }
        public DataGrid showCandidateByName(DataGrid dg, String name)
        {
            utilities.AVS.DataTableToDataGrid(dg, dal.get.SelectCandidateByName(name));
            return dg;
        }

    }
}

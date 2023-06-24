using AVS_Desktop.DataAccessLayer;
using AVS_Desktop.Models;
using AVS_Desktop.Views.Consults;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AVS_Desktop.Controls.Consults
{
    public class ElectorsInformationControl
    {
        static readonly string sesion = LoginControl.sesion;
        public static async void getElectorsInformation(ElectorInformation obj)
        {
            string id=string.Empty;
            DataTable dt = await dal.get.SelectPersonUserID(sesion);
            foreach (DataRow row in dt.Rows)
            {
                id = row[1].ToString();
            }
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Please contact the administration, Your Information it's not available");
            }
            else
            {
                dt= dal.get.SelectAllHashPoolElector();
                foreach (DataRow row in dt.Rows)
                {
                    if (utilities.tools.VerifyHash(row[0].ToString(),id))
                    {
                        DataTable dtIn = dal.get.SelectPoolElector(row[0].ToString());
                        if (dtIn.Rows.Count == 0)
                        {
                            MessageBox.Show("Please contact the administration, Your Information it's not available");
                        }
                        else
                        {
                            foreach (DataRow rowIn in dtIn.Rows)
                            {
                                obj.ueanLabel.Content = rowIn[0].ToString();
                                if((bool)rowIn[1])
                                    obj.statusLabel.Content = "Active";
                                else
                                    obj.statusLabel.Content = "Inactive";
                            }
                        }
                    

                    }
                }
                obj.nameLabel.Content = dal.get.SelectNamePersonById(int.Parse(id));
                Elector elector = dal.get.SelectElectorInformation(int.Parse(id));
                obj.emLabel.Content = elector.ElectoralMunicipality;
                obj.edLabel.Content = elector.ElectoralDistrict;
            }
        }
    }
}

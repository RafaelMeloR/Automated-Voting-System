using AVS_Desktop.DataAccessLayer;
using AVS_Desktop.Models;
using AVS_Desktop.Views.Consults;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows;

namespace AVS_Desktop.Controls.Consults
{
    internal class CandidateInformationControl
    {
        static readonly string sesion = LoginControl.sesion;
        internal static async Task getCandidatesInformationAsync(CanadidateInformation obj)
        {
            string id = string.Empty;
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
                
                obj.nameLabel.Content = dal.get.SelectNamePersonById(int.Parse(id));
                Candidate candidate = await dal.get.SelectCandidateformation(int.Parse(id));
                obj.emLabel.Content = candidate.ElectoralMunicipality;
                obj.edLabel.Content = candidate.ElectoralDistrict;
                obj.epLabel.Content = candidate.ElectoralPosition;
                if (candidate.isActive)
                {
                    obj.statusLabel.Content = "Active";
                }
                else
                {
                    obj.statusLabel.Content = "Inactive";
                } 
            }
        }
    }
}
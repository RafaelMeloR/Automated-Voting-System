using AVS_Desktop.DataAccessLayer;
using AVS_Desktop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AVS_Desktop.Controls.Consults
{
    internal class ElectionsResultsControl
    {
        public static async Task<List<CountVotes>> CountVotesAsync(/*ElectionResults obj*/)
        {
            List <Candidate> candidates = await dal.get.SelectAllCandidateformation();
            List<CountVotes> votes = dal.get.CountVotes(candidates);
             
            foreach (CountVotes vote in votes)
            {
                if (vote.CandidateId != null)
                {
                    MessageBox.Show(vote.CandidateId + ": " + vote.Count);
                } 
            }
            return votes;
        }

        public static void generateChart()
        {

        }
    }
}

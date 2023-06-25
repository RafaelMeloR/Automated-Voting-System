using AVS_Desktop.DataAccessLayer;
using AVS_Desktop.Models;
using AVS_Desktop.Views.Consults;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace AVS_Desktop.Controls.Consults
{
    internal class ElectionsResultsControl
    {
        public static async Task<List<CountVotes>> CountVotesAsync(ElectionsResults obj)
        {
            List <Candidate> candidates = await dal.get.SelectAllCandidateformation();
            List<CountVotes> votes = dal.get.CountVotes(candidates);

            var candidateIdColumn = new DataGridTextColumn()
            {
                Header = "Candidate ID",
                Binding = new Binding("CandidateId")
            };

            var countColumn = new DataGridTextColumn()
            {
                Header = "Count",
                Binding = new Binding("Count")
            };

            obj.resultDG.Columns.Add(candidateIdColumn);
            obj.resultDG.Columns.Add(countColumn); 

            foreach (CountVotes vote in votes)
            {
                var dataItem = new CountVotes()
                {
                    CandidateId = vote.CandidateId,
                    Count = vote.Count
                };

                obj.resultDG.Items.Add(dataItem);
            }
            return votes;
        }

 
    }
}

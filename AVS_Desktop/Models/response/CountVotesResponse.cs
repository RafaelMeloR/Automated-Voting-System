using AVS_Desktop.ViewModels;
using System.Collections.Generic;

namespace AVS_Desktop.Models.response
{
    public class CountVotesResponse
    {
        public int statusCode { get; set; }
        public string statusMessage { get; set; }

        public CountVotes vote { get; set; }
        public List<CountVotes> votes { get; set; }

    }
}

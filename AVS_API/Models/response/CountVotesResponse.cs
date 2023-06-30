using AVS_API.ViewModels;

namespace AVS_API.Models.response
{
    public class CountVotesResponse
    {
        public int statusCode { get; set; }
        public string statusMessage { get; set; }

        public CountVotes vote { get; set; }
        public List<CountVotes> votes { get; set; }

    }
}

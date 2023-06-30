using AVS_API.ViewModels;
using AVS_Desktop.ViewModels;

namespace AVS_API.Models.response
{
    public class CandidateResponse
    {
        public int statusCode { get; set; }
        public string statusMessage { get; set; }

        public CandidateViewModel candidate { get; set; }
        public List<CandidateViewModel> candidates { get; set; }

        public Candidate candidateM { get; set; } //M from the MODEL CANDIDATE
        public List<Candidate> candidatesM { get; set; } //M from the MODEL CANDIDATE

    }
}

using AVS_API.ViewModels;

namespace AVS_API.Models.response
{
    public class PoliticalPartyResponse
    {
        public int statusCode { get; set; }
        public string statusMessage { get; set; }

        public PoliticalParty politicalParty { get; set; }
        public List<PoliticalParty> politicalParties { get; set; }

    }
}

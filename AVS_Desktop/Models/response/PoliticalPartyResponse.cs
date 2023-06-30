using AVS_Desktop.ViewModels;
using System.Collections.Generic;

namespace AVS_Desktop.Models.response
{
    public class PoliticalPartyResponse
    {
        public int statusCode { get; set; }
        public string statusMessage { get; set; }

        public PoliticalParty politicalParty { get; set; }
        public List<PoliticalParty> politicalParties { get; set; }

    }
}

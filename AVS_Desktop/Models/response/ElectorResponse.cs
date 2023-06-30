using AVS_Desktop.ViewModels;
using System.Collections.Generic;

namespace AVS_Desktop.Models.response
{
    public class ElectorResponse
    {
        public int statusCode { get; set; }
        public string statusMessage { get; set; }

        public ElectorViewModel elector { get; set; }
        public List<ElectorViewModel> electors { get; set; }

        public Elector electorModel { get; set; }
        public List<Elector> electorsModel { get; set; }

    }
}

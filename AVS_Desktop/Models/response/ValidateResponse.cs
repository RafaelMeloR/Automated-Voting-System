using AVS_Desktop.ViewModels;
using System.Collections.Generic;

namespace AVS_Desktop.Models.response
{
    public class ValidateResponse
    {
        public int statusCode { get; set; }
        public string statusMessage { get; set; }

        public Validate validate { get; set; }
        public List<Validate> validates { get; set; }

    }
}

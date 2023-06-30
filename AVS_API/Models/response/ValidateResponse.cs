using AVS_API.ViewModels;
using AVS_Desktop.ViewModels;

namespace AVS_API.Models.response
{
    public class ValidateResponse
    {
        public int statusCode { get; set; }
        public string statusMessage { get; set; }

        public Validate validate { get; set; }
        public List<Validate> validates { get; set; }

    }
}

using AVS_API.ViewModels;

namespace AVS_API.Models.response
{
    public class PoolElectorsResponse
    {
        public int statusCode { get; set; }
        public string statusMessage { get; set; }

        public PoolElectors poolElector { get; set; }
        public List<PoolElectors> poolElectors { get; set; }

    }
}

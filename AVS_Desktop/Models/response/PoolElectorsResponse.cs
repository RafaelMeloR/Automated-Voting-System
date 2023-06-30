using AVS_Desktop.ViewModels;
using System.Collections.Generic;

namespace AVS_Desktop.Models.response
{
    public class PoolElectorsResponse
    {
        public int statusCode { get; set; }
        public string statusMessage { get; set; }

        public PoolElectors poolElector { get; set; }
        public List<PoolElectors> poolElectors { get; set; }

    }
}

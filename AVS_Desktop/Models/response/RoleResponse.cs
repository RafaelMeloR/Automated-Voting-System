using AVS_Desktop.ViewModels;
using System.Collections.Generic;

namespace AVS_Desktop.Models.response
{
    public class RoleResponse
    {
        public int statusCode { get; set; }
        public string statusMessage { get; set; }

        public Role role { get; set; }
        public List<Role> roles { get; set; }

    }
}

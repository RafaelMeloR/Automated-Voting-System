using AVS_API.ViewModels;

namespace AVS_API.Models.response
{
    public class RoleResponse
    {
        public int statusCode { get; set; }
        public string statusMessage { get; set; }

        public Role role { get; set; }
        public List<Role> roles { get; set; }

    }
}

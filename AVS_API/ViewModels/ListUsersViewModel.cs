using AVS_API.Models.response;

namespace AVS_API.ViewModels
{
    public class ListUsersViewModel
    {
        public List<PersonResponse> Users { get; set; }
        public string Message { get; set; }

    }
}

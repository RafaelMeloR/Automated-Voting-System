using AVS_Desktop.Models.response;
using System.Collections.Generic;

namespace AVS_Desktop.ViewModels
{
    public class ListUsersViewModel
    {
        public List<PersonResponse> Users { get; set; }
        public string Message { get; set; }

    }
}

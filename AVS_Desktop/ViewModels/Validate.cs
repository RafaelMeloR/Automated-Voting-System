using AVS_Desktop.Models;
using System.Diagnostics.CodeAnalysis;

namespace AVS_Desktop.ViewModels
{
    public class Validate
    {
        public int IdPerson { get; set; } 
        public string Role { get; set; }
        public string guid { get; set; }
        public bool isActivePerson { get; set; }
        public bool isActiveElector { get; set; } 
        public bool isActiveCandidate { get; set; }  
        public bool isActivePool { get; set; } 

    }
}

using Microsoft.AspNetCore.Mvc;

namespace Automated_Voting_System.Controllers
{
    public class SignUpController : Controller
    {
        public IActionResult Signup()
        {
            return View();
        }

        public IActionResult SignupElectors()
        {
            return View();
        }

        public IActionResult SignupCandidate()
        {
            return View();
        }

        public IActionResult SignupPoliticalParty()
        {
            return View();
        }
    }
}

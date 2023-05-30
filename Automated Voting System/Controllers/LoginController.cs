using Automated_Voting_System.Data;
using Automated_Voting_System.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace Automated_Voting_System.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        public LoginController(ApplicationDbContext context, IConfiguration configuration)
        {
            this._context = context;
            this._configuration = configuration;

        }
        //[HttpPost]
        public ActionResult login()
        {

            return View();
        }

    }
}

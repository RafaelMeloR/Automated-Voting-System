using Automated_Voting_System.Data;
using Automated_Voting_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Automated_Voting_System.Controllers
{
    public class AdminController : Controller
    {

        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly ApplicationDbContext context;
        public AdminController(UserManager<IdentityUser> userManager,
                SignInManager<IdentityUser> signInManager, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.context = context;
        }

        public async Task<IActionResult>deteleUser(string email)
        {
            var user = await context.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
            if (user == null)
            {
                return NotFound();
            }
            context.Remove(user);
            //await userManager.DeleteAsync(user);

            return RedirectToAction("ListUsersCrud", routeValues:
                new { message = "Removed succesfully:" + email });
        }
        //--------------------------
        [HttpGet]
        [Authorize(Roles = Constants.Constants.AdminRole)]
        public async Task<IActionResult> ListUsersCrud(string message = null)
        {
            var users = await context.Users.Select(u => new usersViewModel
            {
                Email = u.Email,
            }).ToListAsync();

            var model = new ListUsersViewModel();
            model.Users = users;
            model.Message = message;
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles =Constants.Constants.AdminRole)]
        public async Task<IActionResult> ListUsers(string message = null)
        {
            var users= await context.Users.Select(u=> new usersViewModel
            { 
                Email= u.Email,
            }).ToListAsync();

            var model = new ListUsersViewModel();
            model.Users = users;
            model.Message = message;
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = Constants.Constants.AdminRole)]
        public async Task<IActionResult> makeAdmin(string email)
        {
            var user = await context.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
            if (user == null) 
            {
                return NotFound();
            }

            await userManager.AddToRoleAsync(user, Constants.Constants.AdminRole);

            return RedirectToAction("ListUsers", routeValues:
                new { message = "Role Assigned succesfully to" + email });
        }
        [HttpPost]
        [Authorize(Roles = Constants.Constants.AdminRole)]
        public async Task<IActionResult> makeElector(string email)
        {
            var user = await context.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
            if (user == null)
            {
                return NotFound();
            }

            await userManager.AddToRoleAsync(user, Constants.Constants.ElectorsRole);

            return RedirectToAction("ListUsers", routeValues:
                new { message = "Role Assigned succesfully to" + email });
        }
        [HttpPost]
        [Authorize(Roles = Constants.Constants.AdminRole)]
        public async Task<IActionResult> makeCandidate(string email)
        {
            var user = await context.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
            if (user == null)
            {
                return NotFound();
            }

            await userManager.AddToRoleAsync(user, Constants.Constants.CandidatesRole);

            return RedirectToAction("ListUsers", routeValues:
                new { message = "Role Assigned succesfully to" + email });
        }
        [HttpPost]
        [Authorize(Roles = Constants.Constants.AdminRole)]
        public async Task<IActionResult> makePoliticalParty(string email)
        {
            var user = await context.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
            if (user == null)
            {
                return NotFound();
            }

            await userManager.AddToRoleAsync(user, Constants.Constants.PolitcalPartiesRole);

            return RedirectToAction("ListUsers", routeValues:
                new { message = "Role Assigned succesfully to" + email });
        }

        [HttpPost]
        [Authorize(Roles = Constants.Constants.AdminRole)]
        public async Task<IActionResult> removeAdmin(string email)
        {
            var user = await context.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
            if (user == null)
            {
                return NotFound();
            }

            await userManager.RemoveFromRoleAsync(user, Constants.Constants.AdminRole);

            return RedirectToAction("ListUsers", routeValues:
                new { message = "Role removed succesfully to" + email });
        }
        [HttpPost]
        [Authorize(Roles = Constants.Constants.AdminRole)]
        public async Task<IActionResult> removeElectors(string email)
        {
            var user = await context.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
            if (user == null)
            {
                return NotFound();
            }

            await userManager.RemoveFromRoleAsync(user, Constants.Constants.ElectorsRole);

            return RedirectToAction("ListUsers", routeValues:
                new { message = "Role removed succesfully to" + email });
        }
        [HttpPost]
        [Authorize(Roles = Constants.Constants.AdminRole)]
        public async Task<IActionResult> removeCandidate(string email)
        {
            var user = await context.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
            if (user == null)
            {
                return NotFound();
            }

            await userManager.RemoveFromRoleAsync(user, Constants.Constants.CandidatesRole);

            return RedirectToAction("ListUsers", routeValues:
                new { message = "Role removed succesfully to" + email });
        }
        [HttpPost]
        [Authorize(Roles = Constants.Constants.AdminRole)]
        public async Task<IActionResult> removePoliticalParty(string email)
        {
            var user = await context.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
            if (user == null)
            {
                return NotFound();
            }

            await userManager.RemoveFromRoleAsync(user, Constants.Constants.PolitcalPartiesRole);

            return RedirectToAction("ListUsers", routeValues:
                new { message = "Role removed succesfully to" + email });
        }
    }
}

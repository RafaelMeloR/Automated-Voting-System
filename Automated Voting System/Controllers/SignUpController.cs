using Automated_Voting_System.Data;
using Automated_Voting_System.Entities;
using Automated_Voting_System.Models;
using AVS_API;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Automated_Voting_System.Controllers
{
    public class SignUpController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        public SignUpController(UserManager<IdentityUser> userManager,
                SignInManager<IdentityUser> signInManager, ApplicationDbContext context) 
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.context = context;
        }

        [AllowAnonymous]
        public IActionResult Signup()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult SignupForm()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignupForm(SignUpViewModel model)
        {
            string role = model.role;
             
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = new IdentityUser() { Email = model.Email, UserName = model.Email };
            var gui=Guid.NewGuid().ToString();
            var results = await utilities.sql.Set("INSERT INTO [dbo].[AspNetUsers]([Id],[UserName],[NormalizedUserName],[Email],[NormalizedEmail],[EmailConfirmed],[PasswordHash],[PhoneNumberConfirmed],[TwoFactorEnabled],[LockoutEnabled],[AccessFailedCount])\r\n VALUES\r\n ('" + gui + "','" + user + "','" + user + "' ,'" + user + "','" + user + "',0,'" + utilities.HashPassword(model.Password) + "',0,0,0,0)");
            await utilities.sql.Set("Insert into AspNetUserRoles values('"+gui+"','"+role+"')");
            await utilities.sql.Set("INSERT INTO Person  VALUES('" + model.Name + "','" + model.LastName + "','" + model.LastName + "','" + model.Gender + "','" + model.bornDate + "','" + model.Email + "','" + model.Phone + "',1,'" + gui + "','https://xsgames.co/randomusers/avatar.php?g=male')");
            DataTable dt = utilities.sql.Get(" select max(id) from Person");
            int max=0;
            foreach (DataRow row in dt.Rows) 
            {
                max = (int )row[0];
            }
            await utilities.sql.Set("INSERT INTO[dbo].[Address]  VALUES('"+model.City+"', '"+ model.Thoroughfare + "', '"+ model.ApartmentNumber + "', '"+ model.City + "',"+max+" )");
            await utilities.sql.Set("insert into PoolElectors values('" + Guid.NewGuid() + "',1)");
                await context.SaveChangesAsync();
                await signInManager.SignInAsync(user, isPersistent: true);
                return RedirectToAction("Index", "Home");
           
           
            
        } 
   
    }
}

using Automated_Voting_System.Data;
using Automated_Voting_System.Entities;
using Automated_Voting_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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

            var result = await userManager.CreateAsync(user, password: model.Password); //CREATING USER 
            //ASSINIG ROLE
            if (user == null)
            {
                return NotFound();
            }
            await userManager.AddToRoleAsync(user, role);
            //ASSING ROLE END

            //SETTING UP THE OBJECTS TO INSERT INTO THE TABLES
            var person = new Person
            {
                Name = model.Name,
                LastName = model.LastName,
                Phone = model.Phone, //TO FIX THIS VALUE IS GETTING 0 IN THE DATABASE
                Gender = model.Gender,
                Email = model.Email,
                MarriedName = model.MarriedName,
                bornDate = model.bornDate,
                isActive = true,
                UserId=user.Id,
            };

            var address = new Address
            {
                City = model.City,
                ApartmentNumber=model.ApartmentNumber,
                Thoroughfare = model.Thoroughfare,
                PostalCode = model.PostalCode,
                PersonId = person.Id, //TO FIX THIS VALUE IS GETTING 0 IN THE DATABASE
            };

            if (result.Succeeded)//IF USER WAS CREATED SUCCESFULLY THEN ADD INTO DATABASE PERSON AND ADDRESS THEN GO HOME
            {
                context.Add(person);
                context.Add(address);
                await context.SaveChangesAsync();
                await signInManager.SignInAsync(user, isPersistent: true);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(String.Empty, error.Description);
                }
            } 
            
            return View(model);
        } 
   
    }
}

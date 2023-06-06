using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Automated_Voting_System.Entities
{
    public class SignupMoreController : Controller
    {
        // GET: SignupMoreController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SignupMoreController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SignupMoreController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SignupMoreController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SignupMoreController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SignupMoreController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SignupMoreController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SignupMoreController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

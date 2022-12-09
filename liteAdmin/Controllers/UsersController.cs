using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using repository;
using System.Data;

namespace MAK_Lte_Mw.Controllers
{
    public class UsersController : Controller
    {

        private readonly Iusers _users;


        public UsersController(Iusers _users)
        {
            this._users = _users;
        }




        [HttpGet]
        public async Task<IActionResult> usersList()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");
            }

            var list = await _users.ListUsers();

            return View(list);
        }



        [HttpGet]
        public async Task<IActionResult> users()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");
            }


            return View();
        }


        [HttpPost]
        public async Task<IActionResult> users(Users a)
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");

            }

            if (ModelState.IsValid)
            {
                var add = await _users.AddUsers(a);
                return RedirectToAction("usersList");

            }

            return View(a);


        }

        [HttpPost]
        public async Task<IActionResult> Edit(Users a)
        {

            try
            {
                if (ModelState.IsValid)
                {
                     _users.Edit(a);


                    return RedirectToAction("usersList");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(a);


        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            Users Fetch = await _users.GetUsersByID(id);
            return View(Fetch);

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id, bool? saveChangesError)
        {

            Users asso = await _users.GetUsersByID(id);
            return View(asso);

        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> Delete(int id)
        {

            if (ModelState.IsValid)
            {
                Users asso = await _users.GetUsersByID(id);
                _users.DeleteUsers(id);
                return RedirectToAction("usersList");
            }
            else
            {
                return RedirectToAction("Delete");
            }

            return null;




        }


    }
}

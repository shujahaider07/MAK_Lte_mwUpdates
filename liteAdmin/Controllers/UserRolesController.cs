using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using repository;
using System.Data;

namespace MAK_Lte_Mw.Controllers
{


    public class UserRolesController : Controller
    {

        private readonly IUserRoles _userroles;
        private readonly ApplicationDbContext db;
        public UserRolesController(ApplicationDbContext db, IUserRoles _userroles)
        {
            this._userroles = _userroles;
            this.db = db;


        }


        [HttpGet]
        public async Task<IActionResult> AddUserRolesList()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");
            }

            var list = await _userroles.ListUserRoles();

            return View(list);
        }







        [HttpGet]
        public async Task<IActionResult> AddUserRoles()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");
            }



            return View("AddUserRoles");


        }




        [HttpPost]
        public async Task<IActionResult> AddUserRoles(UserRoles a)
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");

            }

            if (ModelState.IsValid)
            {
                var add = await _userroles.AddUSerRoles(a);
                return RedirectToAction("AddUserRolesList");

            }

            return View(a);


        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserRoles a)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _userroles.Edit(a);


                    return RedirectToAction("AddUserRolesList");
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

            UserRoles Fetch = await _userroles.GetUserRolesByID(id);
            return View(Fetch);

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id, bool? saveChangesError)
        {

            UserRoles asso = await _userroles.GetUserRolesByID(id);
            return View(asso);

        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> Delete(int id)
        {

            if (ModelState.IsValid)
            {
                UserRoles asso = await _userroles.GetUserRolesByID(id);
                _userroles.DeletUserRoles(id);
                return RedirectToAction("AddUserRolesList");
            }
            else
            {
                return RedirectToAction("Delete");
            }

            return null;




        }



    }
}

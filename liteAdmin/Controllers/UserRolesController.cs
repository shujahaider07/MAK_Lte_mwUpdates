using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using repository;

namespace MAK_Lte_Mw.Controllers
{
  

    public class UserRolesController : Controller
    {

        private readonly IUserRoles _userroles;
        private readonly ApplicationDbContext db;
        public UserRolesController(ApplicationDbContext db, IAdaptor _adaptor)
        {
            this._userroles = _userroles;
            this.db = db;


        }


        [HttpGet]
        public async Task<IActionResult> AddUserRoles()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");
            }

            try
            {


            }
            catch (Exception)
            {

            }

            return View("AddUserRoles");



        }


    }
}

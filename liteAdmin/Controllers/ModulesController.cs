using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using repository;
using System.Data;

namespace MAK_Lte_Mw.Controllers
{
    public class ModulesController : Controller
    {
        private readonly IModules _module;
        private readonly ApplicationDbContext db;

        public ModulesController(IModules _module, ApplicationDbContext db)
        {
            this._module = _module;
            this.db = db;


        }


        [HttpGet]
        public async Task<IActionResult> AddModulesType()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");
            }

            return View("AddModulesType");



        }



        [HttpPost]
        public async Task<IActionResult> AddModulesType(Modules a)
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");

            }

            if (ModelState.IsValid)
            {
                var add = await _module.AddModules(a);
                db.SaveChanges();
                return RedirectToAction("AddModulesList");

            }

            return View(a);


        }


         
        [HttpGet]
        public async Task <IActionResult> AddModulesList()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");
            }

            var list = await _module.ListModules();
            return View(list);
        }

        


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            Modules Fetch = await _module.GetModulesByID(id);
            return View(Fetch);


        }



        [HttpPost]
        public async Task<IActionResult> Edit(Modules a)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _module.Edit(a);


                    return RedirectToAction("AddModulesList");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(a);


        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id, bool? saveChangesError)
        {

            Modules ada = await _module.GetModulesByID(id);
            return View(ada);

        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> Delete(int id)
        {

            if (ModelState.IsValid)
            {
                Modules ada = await _module.GetModulesByID(id);
                _module.DeleteModules(id);
                return RedirectToAction("ModulesType");
            }
            else
            {
                return RedirectToAction("Delete");
            }

            return null;



        }




    }
}

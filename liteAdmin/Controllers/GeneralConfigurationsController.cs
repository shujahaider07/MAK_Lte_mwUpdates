using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using repository;
using System.Data;

namespace MAK_Lte_Mw.Controllers
{
    public class GeneralConfigurationsController : Controller
    {
        private readonly IGeneralConfigurations _general;
        private readonly ApplicationDbContext db;
        public GeneralConfigurationsController(ApplicationDbContext db, IGeneralConfigurations _general)
        {
            this._general = _general;
            this.db = db;


        }

        [HttpGet]
        public async Task<IActionResult> AddGeneralConfigurations()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");
            }



            return View("AddGeneralConfigurations");



        }



        [HttpPost]
        public async Task<IActionResult> AddGeneralConfigurations(GeneralConfigurations a)
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");

            }

            if (ModelState.IsValid)
            {

                var add = await _general.AddGeneralConfigurations(a);
                return RedirectToAction("GeneralConfigurationsList");

            }

            return View(a);


        }



        [HttpGet]
        public async Task<IActionResult> GeneralConfigurationsList()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");
            }

            var list = await _general.ListGeneralConfigurations();
            return View(list);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {


            GeneralConfigurations Fetch = await _general.GetGeneralConfigurationsByID(id);
            return View(Fetch);



        }



        [HttpPost]
        public async Task<IActionResult> Edit(GeneralConfigurations a)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _general.Edit(a);


                    return RedirectToAction("GeneralConfigurationsList");
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

            GeneralConfigurations ada = await _general.GetGeneralConfigurationsByID(id);
            return View(ada);

        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> Delete(int id)
        {

            if (ModelState.IsValid)
            {
                GeneralConfigurations ada = await _general.GetGeneralConfigurationsByID(id);
                _general.DeleteGeneralConfigurations(id);
                return RedirectToAction("GeneralConfigurationsList");
            }
            else
            {
                return RedirectToAction("Delete");
            }

            return null;




        }






    }
}

using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using repository;
using System.Data;

namespace MAK_Lte_Mw.Controllers
{
    public class ApplicationPagesController : Controller
    {

        private readonly IApplicationPages _ApplicationPages;
        private readonly ApplicationDbContext db;
        public ApplicationPagesController(ApplicationDbContext db, IApplicationPages _ApplicationPages)
        {
            this._ApplicationPages = _ApplicationPages;
            this.db = db;


        }




        [HttpGet]
        public async Task<IActionResult> AddApplicationPages()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");
            }

           

            return View("AddApplicationPages");



        }



        [HttpPost]
        public async Task<IActionResult> AddApplicationPages(ApplicationPages a)
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");

            }

            if (ModelState.IsValid)
            {

                var add = await _ApplicationPages.AddApplicationPages(a);
                return RedirectToAction("AddApplicationPagesList");

            }

            return View(a);


        }



        [HttpGet]
        public async Task<IActionResult> AddApplicationPagesList()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");
            }

            var list = await _ApplicationPages.ListApplicationPages();
            return View(list);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            

            ApplicationPages Fetch = await _ApplicationPages.GetApplicationPagesByID(id);
            return View(Fetch);



        }



        [HttpPost]
        public async Task<IActionResult> Edit(ApplicationPages a)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _ApplicationPages.Edit(a);


                    return RedirectToAction("AddApplicationPagesList");
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

            ApplicationPages ada = await _ApplicationPages.GetApplicationPagesByID(id);
            return View(ada);

        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> Delete(int id)
        {

            if (ModelState.IsValid)
            {
                ApplicationPages ada = await _ApplicationPages.GetApplicationPagesByID(id);
                _ApplicationPages.DeleteApplicationPages(id);
                return RedirectToAction("AddApplicationPagesList");
            }
            else
            {
                return RedirectToAction("Delete");
            }

            return null;




        }





    }
}

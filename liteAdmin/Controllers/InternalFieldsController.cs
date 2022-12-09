using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using repository;
using System.Data;

namespace MAK_Lte_Mw.Controllers
{
    public class InternalFieldsController : Controller
    {

        private readonly IInternalFields _internal;
        private readonly ApplicationDbContext db;
        public InternalFieldsController(ApplicationDbContext db, IInternalFields _internal)
        {
            this._internal = _internal;
            this.db = db;


        }

        [HttpGet]
        public async Task<IActionResult> AddInternalFields()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");
            }

            

            return View("AddInternalFields");



        }



        [HttpPost]
        public async Task<IActionResult> AddInternalFields(InternalFields a)
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");

            }

            if (ModelState.IsValid)
            {

                var add = await _internal.AddInternalFields(a);
                return RedirectToAction("InternalFieldsList");

            }

            return View(a);


        }



        [HttpGet]
        public async Task <IActionResult> InternalFieldsList()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");
            }

            var list = await _internal.ListInternalFields();
            return View(list);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
           

            InternalFields Fetch = await _internal.GetInternalFieldsByID(id);
            return View(Fetch);



        }



        [HttpPost]
        public async Task<IActionResult> Edit(InternalFields a)
        {

            try
            {
                if (ModelState.IsValid)
                {
                     _internal.Edit(a);


                    return RedirectToAction("InternalFieldsList");
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

            InternalFields ada = await _internal.GetInternalFieldsByID(id);
            return View(ada);

        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> Delete(int id)
        {

            if (ModelState.IsValid)
            {
                InternalFields ada = await _internal.GetInternalFieldsByID(id);
                _internal.DeleteInternalFields(id);
                return RedirectToAction("InternalFieldsList");
            }
            else
            {
                return RedirectToAction("Delete");
            }

            return null;




        }




    }
}

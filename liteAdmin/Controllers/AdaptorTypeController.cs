using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using repository;
using System.Data;

namespace MAK_Lte_Mw.Controllers
{
    public class AdaptorTypeController : Controller
    {
        private readonly IAdaptorType _adaptorType;
        private readonly ApplicationDbContext db;
        public AdaptorTypeController(IAdaptorType _adaptorType,ApplicationDbContext db)
        {
            this._adaptorType = _adaptorType;
            this.db = db;

        }

        [HttpGet]
        public async Task <IActionResult> AddAdaptorType()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");
            }
            try
            {

                if (ModelState.IsValid)
                {
                    List<Adaptor> adaptors = db.adaptor.Select(x => new Adaptor { Id = x.Id, AdaptorTypeId = x.AdaptorTypeId }).ToList();
                    ViewBag.adaptorData = new SelectList(adaptors, "Id", "AdaptorTypeId");

                }



            }
            catch (Exception)
            {

            }

            return View("AddAdaptorType");


           
        }



        [HttpPost]
        public async Task<IActionResult> AddAdaptorType(AdaptorType a)
        {
            

            var add = await _adaptorType.AddadaptorType(a);

            if (add != null)
            {
                if (HttpContext.Session.GetString("username") == null)
                {
                    return RedirectToAction("LoginView", "Login");
                }

                return RedirectToAction("AddAdaptorTypeList");

            }

            return View(a);


        }



        [HttpGet]
        public async Task<IActionResult> AddAdaptorTypeList()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");
            }

            var list = await _adaptorType.ListAdaptorType();
            return View(list);
        }






        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            if (ModelState.IsValid)
            {
                List<Adaptor> adaptors = db.adaptor.Select(x => new Adaptor { Id = x.Id, AdaptorTypeId = x.AdaptorTypeId }).ToList();
                ViewBag.adaptorData = new SelectList(adaptors, "Id", "AdaptorTypeId");

            }

         


            AdaptorType Fetch = await _adaptorType.GetAdaptorTypeByID(id);
            return View(Fetch);



        }



        [HttpPost]
        public async Task<IActionResult> Edit(AdaptorType a)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _adaptorType.Edit(a);


                    return RedirectToAction("AddAdaptorTypeList");
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

            AdaptorType ada = await _adaptorType.GetAdaptorTypeByID(id);
            return View(ada);

        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> Delete(int id)
        {

            if (ModelState.IsValid)
            {
                AdaptorType ada = await _adaptorType.GetAdaptorTypeByID(id);
                _adaptorType.DeleteAdaptorType(id);
                return RedirectToAction("AddAdaptorTypeList");
            }
            else
            {
                return RedirectToAction("Delete");
            }

            return null;



        }



        public IActionResult Index()
        {
            return View();
        }
    }
}

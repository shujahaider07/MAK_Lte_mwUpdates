using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using repository;
using System.Data;

namespace MAK_Lte_Mw.Controllers
{
    public class AdaptorController : Controller
    {


        private readonly IAdaptor _adaptor;
        private readonly ApplicationDbContext db;
        public AdaptorController(ApplicationDbContext db, IAdaptor _adaptor)
        {
            this._adaptor = _adaptor;
            this.db = db;


        }
        [HttpGet]
        public async Task<IActionResult> AddAdaptor()
        {
            Adaptor a = new Adaptor();
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");
            }

            try
            {

             
                a.IsActiveNew = a.IsActive.ToString() == "1" ? true : false; 


                List<Association> associations = db.association.Select(x => new Association { Id = x.Id, Name = x.Name }).ToList();
                ViewBag.associationData = new SelectList(associations, "Id", "Name");


                List<Participants> participants = db.participants.Select(x => new Participants { Id = x.Id, Name = x.Name }).ToList();
                ViewBag.ParticipantData = new SelectList(participants, "Id", "Name");

            }
            catch (Exception)
            {

            }

            return View("AddAdaptor",a);



        }



        [HttpPost]
        public async Task<IActionResult> AddAdaptor(Adaptor a)
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");

            }

            if (a.IsActiveNew != false)
            {
                a.IsActive = '1';
            }
            else
            {
                a.IsActive = '0';
            }

            if (ModelState.IsValid)
            {

                var add = await _adaptor.Addadaptor(a);
                return RedirectToAction("adaptorList");

            }

            return View(a);


        }



        [HttpGet]
        public async Task<IActionResult> adaptorList()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");
            }

            var list = await _adaptor.ListAdaptor();
            return View(list);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Adaptor a = new Adaptor();
            a.IsActiveNew = a.IsActive.ToString() == "1" ? true : false;


            List<Association> associations = db.association.Select(x => new Association { Id = x.Id, Name = x.Name }).ToList();
            ViewBag.associationData = new SelectList(associations, "Id", "Name");


            List<Participants> participants = db.participants.Select(x => new Participants { Id = x.Id, Name = x.Name }).ToList();
            ViewBag.ParticipantData = new SelectList(participants, "Id", "Name");

            Adaptor Fetch = await _adaptor.GetAdaptorByID(id);
            return View(Fetch);



        }



        [HttpPost]
        public async Task<IActionResult> Edit(Adaptor a)
        {
            if (a.IsActiveNew != false)
            {
                a.IsActive = '1';
            }
            else
            {
                a.IsActive = '0';
            }


           


            try
            {
                if (ModelState.IsValid)
                {
                     _adaptor.Edit(a);


                    return RedirectToAction("AdaptorList");
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

            Adaptor ada = await _adaptor.GetAdaptorByID(id);
            return View(ada);

        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> Delete(int id)
        {

            if (ModelState.IsValid)
            {
                Adaptor ada = await _adaptor.GetAdaptorByID(id);
                _adaptor.DeleteAdaptor(id);
                return RedirectToAction("AdaptorList");
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

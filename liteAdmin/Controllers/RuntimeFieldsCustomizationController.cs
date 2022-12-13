using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using repository;
using System.Data;

namespace MAK_Lte_Mw.Controllers
{
    public class RuntimeFieldsCustomizationController : Controller
    {

        private readonly IRuntimeFieldsCustomization _Runtime;
        private readonly ApplicationDbContext db;
        public RuntimeFieldsCustomizationController(ApplicationDbContext db, IRuntimeFieldsCustomization _Runtime)
        {
            this.db = db;
            this._Runtime = _Runtime;
        }



        [HttpGet]
        public async Task<IActionResult> AddRuntimeFieldsCustomization()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");
            }
            try
            {
                if (ModelState.IsValid)
                {
                    List<Participants> participants = db.participants.Select(x => new Participants { Id = x.Id, Name = x.Name }).ToList();
                    ViewBag.ParticipantData = new SelectList(participants, "Id", "Name");

                    List<TransactionIdentifier> identifiers = db.TransactionIdentifier.Select(x => new TransactionIdentifier { Id = x.Id, ParticipantId = x.ParticipantId }).ToList();
                    ViewBag.IdentifierData = new SelectList(identifiers, "Id", "ParticipantId");
                }


                

            }
            catch (Exception)
            {

            }

            return View("AddRuntimeFieldsCustomization");



        }



        [HttpPost]
        public async Task<IActionResult> AddRuntimeFieldsCustomization(RuntimeFieldsCustomization s)
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");

            }
          
            
            var add = await _Runtime.AddRuntimeFieldsCustomization(s);

            if (add == null)
            {
                if (HttpContext.Session.GetString("username") == null)
                {
                    return RedirectToAction("LoginView", "Login");
                }

                return RedirectToAction("AddRuntimeFieldsCustomizationList");

            }
            


            //var add = await _Runtime.AddRuntimeFieldsCustomization(s);
            //    db.SaveChanges();
            //    return RedirectToAction("AddRuntimeFieldsCustomizationList");



            return View(s);


        }



        [HttpGet]
        public async Task<IActionResult> AddRuntimeFieldsCustomizationList()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");
            }

            var list = _Runtime.ListRuntimeFieldsCustomization();
            return View(list);
        }

        


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            List<Participants> participants = db.participants.Select(x => new Participants { Id = x.Id, Name = x.Name }).ToList();
            ViewBag.ParticipantData = new SelectList(participants, "Id", "Name");
            List<TransactionIdentifier> identifiers = db.TransactionIdentifier.Select(x => new TransactionIdentifier { Id = x.Id, ParticipantId = x.ParticipantId }).ToList();
            ViewBag.IdentifierData = new SelectList(identifiers, "Id", "ParticipantId");


            RuntimeFieldsCustomization Fetch = await _Runtime.GetRuntimeFieldsCustomizationByID(id);
            return View(Fetch);



        }



        [HttpPost]
        public async Task<IActionResult> Edit(RuntimeFieldsCustomization s)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _Runtime.Edit(s);


                    return RedirectToAction("AddRuntimeFieldsCustomizationList");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
          
            return View(s);


        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id, bool? saveChangesError)
        {

            RuntimeFieldsCustomization ada = await _Runtime.GetRuntimeFieldsCustomizationByID(id);
            return View(ada);

        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> Delete(int id)
        {

            if (ModelState.IsValid)
            {
                RuntimeFieldsCustomization ada = await _Runtime.GetRuntimeFieldsCustomizationByID(id);
                _Runtime.DeleteRuntimeFieldsCustomization(id);
                return RedirectToAction("AddRuntimeFieldsCustomizationList");
            }
            else
            {
                return RedirectToAction("Delete");
            }

            return null;



        }



    }
}

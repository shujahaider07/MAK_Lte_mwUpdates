using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using repository;
using System.Data;

namespace MAK_Lte_Mw.Controllers
{
    public class TransactionCodeMappingController : Controller
    {

        private readonly ITransactionCodeMapping _TransactionCodeMapping;
        private readonly ApplicationDbContext db;

        public TransactionCodeMappingController(ITransactionCodeMapping _TransactionCodeMapping, ApplicationDbContext db)
        {
            this._TransactionCodeMapping = _TransactionCodeMapping;
            this.db = db;
        }
        [HttpGet]
        public IActionResult AddTransactionCodeMapping()
        {

            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");
            }

            try
            {


                List<Participants> participants = db.participants.Select(x => new Participants { Id = x.Id, Name = x.Name }).ToList();
                ViewBag.ParticipantData = new SelectList(participants, "Id", "Name");

            }
            catch (Exception)
            {

            }

            return View("AddTransactionCodeMapping");



        }

        [HttpPost]
        public async Task<IActionResult> AddTransactionCodeMapping(TransactionCodeMapping tcm)
        {


            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");

            }

            if (ModelState.IsValid)
            {
                var add = await _TransactionCodeMapping.AddransactionCodeMapping(tcm);
                return RedirectToAction("TransactionCodeMappingList");

            }

            return View(tcm);


        }




        [HttpPost]
        public async Task<IActionResult> Edit(TransactionCodeMapping tcm)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _TransactionCodeMapping.Edit(tcm);
                    return RedirectToAction("TransactionCodeMappingList");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(tcm);


        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            List<Participants> participants = db.participants.Select(x => new Participants { Id = x.Id, Name = x.Name }).ToList();
            ViewBag.ParticipantData = new SelectList(participants, "Id", "Name");
           
            TransactionCodeMapping Fetch = await _TransactionCodeMapping.GetTransactionCodeMappingID(id);
            return View(Fetch);

        }



        [HttpGet]
        public async Task<IActionResult> Delete(int id, bool? saveChangesError)
        {

            TransactionCodeMapping transac = await _TransactionCodeMapping.GetTransactionCodeMappingID(id);
            return View(transac);

        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> Delete(int id)
        {

            if (ModelState.IsValid)
            {
                TransactionCodeMapping transac = await _TransactionCodeMapping.GetTransactionCodeMappingID(id);
                _TransactionCodeMapping.DeleteTransactionCodes(id);
                return RedirectToAction("TransactionCodeMappingList");
            }
            else
            {
                return RedirectToAction("Delete");
            }

            return null;




        }



        [HttpGet]
        public async Task<IActionResult> TransactionCodeMappingList()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");
            }

            var list = _TransactionCodeMapping.ListTransactionCodeMapping();

            return View(list);
        }




    }
}

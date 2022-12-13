using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using repository;
using System.Data;

namespace MAK_Lte_Mw.Controllers
{
    public class TransactionFieldsController : Controller
    {

        private readonly ITransactionFields _tranFields;
        private readonly ApplicationDbContext db;


        public TransactionFieldsController(ITransactionFields _tranFields, ApplicationDbContext db)
        {
            this._tranFields = _tranFields;
            this.db = db;
        }


        [HttpGet]
        public async Task<IActionResult> transactionField()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");
            }
            if (ModelState.IsValid)
            {

                List<TransactionIdentifier> identifiers = db.TransactionIdentifier.Select(x => new TransactionIdentifier { Id = x.Id, ParticipantId = x.ParticipantId }).ToList();
                ViewBag.IdentifierData = new SelectList(identifiers, "Id", "ParticipantId");
            }



            return View("transactionField");
        }




        [HttpPost]
        public async Task<IActionResult> transactionField(TransactionFields t)
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");

            }

                var add = await _tranFields.AddTransactionFields(t);
                
            

                return RedirectToAction("transactionFieldList");

            

                return View(t);


        }



        [HttpGet]
        public async Task<IActionResult> transactionFieldList()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");
            }

            var list = _tranFields.ListTransactionFields();

            return View(list);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(TransactionFields t)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _tranFields.Edit(t);
                    return RedirectToAction("transactionFieldList");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(t);


        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            List<TransactionIdentifier> identifiers = db.TransactionIdentifier.Select(x => new TransactionIdentifier { Id = x.Id, ParticipantId = x.ParticipantId }).ToList();
            ViewBag.IdentifierData = new SelectList(identifiers, "Id", "ParticipantId");

            TransactionFields Fetch = await _tranFields.GetTransactionFieldsByID(id);
            return View(Fetch);

        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id, bool? saveChangesError)
        {

            TransactionFields transac = await _tranFields.GetTransactionFieldsByID(id);
            return View(transac);

        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> Delete(int id)
        {

            if (ModelState.IsValid)
            {
                TransactionFields transac = await _tranFields.GetTransactionFieldsByID(id);
                _tranFields.DeleteTransactionFields(id);
                return RedirectToAction("transactionFieldList");
            }
            else
            {
                return RedirectToAction("Delete");
            }

            return null;




        }




    }
}

using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using repository;
using System.Data;

namespace MAK_Lte_Mw.Controllers
{
    public class TransactionIdentifierController : Controller
    {

        private readonly ITransactionIdentifier _tran;
        private readonly ApplicationDbContext db;



        public TransactionIdentifierController(ITransactionIdentifier _tran, ApplicationDbContext db)
        {
            this._tran = _tran;
            this.db = db;
        }



        [HttpPost]
        public async Task<IActionResult> TransactionIdentifier(TransactionIdentifier t)
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");

            }

                var add = await _tran.AddransactionIdentifier(t);
                return RedirectToAction("TransactionIdentifierList");

            

            return View(t);


        }


        [HttpGet]
        public async Task<IActionResult> TransactionIdentifier()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");
            }


            if (ModelState.IsValid)
            {
                List<Participants> participants = db.participants.Select(x => new Participants { Id = x.Id, Name = x.Name }).ToList();
                ViewBag.ParticipantData = new SelectList(participants, "Id", "Name");

            }
           

            return View();
        }



        [HttpGet]
        public async Task<IActionResult> TransactionIdentifierList()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");
            }

            var list = _tran.ListTransactionIdentifier();

            return View(list);
        }



        [HttpPost]
        public async Task<IActionResult> Edit(TransactionIdentifier t)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _tran.Edit(t);
                    return RedirectToAction("TransactionIdentifierList");
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
            List<Participants> participants = db.participants.Select(x => new Participants { Id = x.Id, Name = x.Name }).ToList();
            ViewBag.ParticipantData = new SelectList(participants, "Id", "Name");

            TransactionIdentifier Fetch = await _tran.GetTransactionIdentifierID(id);
            return View(Fetch);

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id, bool? saveChangesError)
        {

            TransactionIdentifier transac = await _tran.GetTransactionIdentifierID(id);
            return View(transac);

        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> Delete(int id)
        {

            if (ModelState.IsValid)
            {
                TransactionIdentifier transac = await _tran.GetTransactionIdentifierID(id);
                _tran.DeleteTransactionIdentifier(id);
                return RedirectToAction("TransactionIdentifierList");
            }
            else
            {
                return RedirectToAction("Delete");
            }

            return null;




        }



    }
}

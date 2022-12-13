using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using repository;
using System.Data;

namespace MAK_Lte_Mw.Controllers
{
    public class TransactionRoutingController : Controller
    {

        private readonly ITransactionRoutings _transactionRoutings;
        private readonly ApplicationDbContext db;

        public TransactionRoutingController(ITransactionRoutings _transactionRoutings, ApplicationDbContext db)
        {
            this._transactionRoutings = _transactionRoutings;
            this.db = db;
        }

        [HttpGet]
        public IActionResult AddTransactionRouting()
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


        [HttpPost]
        public async Task<IActionResult> AddTransactionRouting(TransactionRoutings t)
        {


            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");

            }

            
                var add = await _transactionRoutings.AddTransactionRoutings(t);
                return RedirectToAction("TransactionRoutingsList");

            

            return View(t);
        }




        [HttpPost]
        public async Task<IActionResult> Edit(TransactionRoutings t)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _transactionRoutings.Edit(t);
                    return RedirectToAction("TransactionRoutingsList");
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


            TransactionRoutings Fetch = await _transactionRoutings.GetTransactionRoutingsID(id);
            return View(Fetch);

        }



        [HttpGet]
        public async Task<IActionResult> Delete(int id, bool? saveChangesError)
        {

            TransactionRoutings transac = await _transactionRoutings.GetTransactionRoutingsID(id);
            return View(transac);

        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> Delete(int id)
        {

            if (ModelState.IsValid)
            {
                TransactionRoutings transac = await _transactionRoutings.GetTransactionRoutingsID(id);
                _transactionRoutings.DeleteTransactionRoutings(id);
                return RedirectToAction("TransactionRoutingsList");
            }
            else
            {
                return RedirectToAction("Delete");
            }

            return null;




        }



        [HttpGet]
        public async Task<IActionResult> TransactionRoutingsList()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");
            }

            var list = _transactionRoutings.ListTransactionRoutings();

            return View(list);
        }






    }
}

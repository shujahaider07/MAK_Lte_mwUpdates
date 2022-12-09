using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using repository;
using System.Data;

namespace MAK_Lte_Mw.Controllers
{
    public class TransactionRouterController : Controller
    {


        private readonly ITransactionRouter _transactionRouter;
        private readonly ApplicationDbContext db;

        public TransactionRouterController(ITransactionRouter _transactionRouter, ApplicationDbContext db)
        {
          
            this._transactionRouter = _transactionRouter;
            this.db = db;
        }


        [HttpGet]
        public IActionResult AddTransactionRouter()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");
            }

            List<TransactionRoutings> TransactionRoutingss = db.TransactionRoutings.Select(x => new TransactionRoutings { Id = x.Id, ParticipantId = x.ParticipantId }).ToList();
            ViewBag.Routings = new SelectList(TransactionRoutingss, "Id", "ParticipantId");

            return View();
        }

 
        [HttpPost]
        public async Task<IActionResult> AddTransactionRouter(TransactionRouter t)
        {


            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");

            }

            if (ModelState.IsValid)
            {
                var add = await _transactionRouter.AddTransactionRouter(t);
                return RedirectToAction("TransactionRouterList");

            }

            return View(t);
        }




        [HttpPost]
        public async Task<IActionResult> Edit(TransactionRouter t)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _transactionRouter.Edit(t);
                    return RedirectToAction("TransactionRouterList");
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
            List<TransactionRoutings> TransactionRoutingss = db.TransactionRoutings.Select(x => new TransactionRoutings { Id = x.Id, ParticipantId = x.ParticipantId }).ToList();
            ViewBag.Routings = new SelectList(TransactionRoutingss, "Id", "ParticipantId");


            TransactionRouter Fetch = await _transactionRouter.GetTransactionRouterID(id);
            return View(Fetch);

        }



        [HttpGet]
        public async Task<IActionResult> Delete(int id, bool? saveChangesError)
        {

            TransactionRouter transac = await _transactionRouter.GetTransactionRouterID(id);
            return View(transac);

        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> Delete(int id)
        {

            if (ModelState.IsValid)
            {
                TransactionRouter transac = await _transactionRouter.GetTransactionRouterID(id);
                _transactionRouter.DeleteTransactionRouter(id);
                return RedirectToAction("TransactionRouterList");
            }
            else
            {
                return RedirectToAction("Delete");
            }

            return null;




        }



        [HttpGet]
        public async Task<IActionResult> TransactionRouterList()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");
            }

            var list = _transactionRouter.ListTransactionRouter();

            return View(list);
        }







    }
}

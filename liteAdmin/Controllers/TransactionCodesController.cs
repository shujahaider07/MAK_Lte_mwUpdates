using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using repository;
using System.Data;

namespace MAK_Lte_Mw.Controllers
{
    public class TransactionCodesController : Controller
    {


        private readonly ITransactionCodes _TransactionCode;

        public TransactionCodesController(ITransactionCodes _TransactionCode)
        {
            this._TransactionCode = _TransactionCode;
        }

        [HttpGet]
        public IActionResult AddTransactionCode()
        {

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddTransactionCode(TransactionCodes c) 
        {

            
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");

            }

            if (ModelState.IsValid)
            {
                var add = await _TransactionCode.AddtransactionCodes(c);
                return RedirectToAction("TransactionList");

            }

            return View(c);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(TransactionCodes c)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _TransactionCode.Edit(c);
                    return RedirectToAction("TransactionList");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            
            return View(c);


        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            TransactionCodes Fetch = await _TransactionCode.GetTransactionCodesByID(id);
            return View(Fetch);

        }



        [HttpGet]
        public async Task<IActionResult> Delete(int id, bool? saveChangesError)
        {

            TransactionCodes transac = await _TransactionCode.GetTransactionCodesByID(id);
            return View(transac);

        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> Delete(int id)
        {

            if (ModelState.IsValid)
            {
                TransactionCodes transac = await _TransactionCode.GetTransactionCodesByID(id);
                _TransactionCode.DeleteTransactionCodes(id);
                return RedirectToAction("TransactionList");
            }
            else
            {
                return RedirectToAction("Delete");
            }

            return null;




        }



        [HttpGet]
        public async Task<IActionResult> TransactionList()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");
            }

            var list = _TransactionCode.ListTransactionCodes();

            return View(list);
        }


    }
}

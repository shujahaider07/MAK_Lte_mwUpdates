using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using repository;
using System.Data;

namespace MAK_Lte_Mw.Controllers
{
    public class ResponseCodeMappingController : Controller
    {

        private readonly IResponeCodes _Respone;


        public ResponseCodeMappingController(IResponeCodes _Respone)
        {
            this._Respone = _Respone;
        }




        [HttpGet]
        public async Task<IActionResult> ResponeCodesList()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");
            }

            var list = await _Respone.ListResponeCodes();

            return View(list);
        }



        [HttpGet]
        public async Task<IActionResult> ResponeCodes()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");
            }


            return View();
        }


        [HttpPost]
        public async Task<IActionResult> ResponeCodes(ResponeCodes a)
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");

            }

            if (ModelState.IsValid)
            {
                var add = await _Respone.AddResponeCodes(a);
                return RedirectToAction("ResponeCodesList");

            }

            return View(a);


        }

        [HttpPost]
        public async Task<IActionResult> Edit(ResponeCodes a)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _Respone.Edit(a);


                    return RedirectToAction("ResponeCodesList");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(a);


        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            ResponeCodes Fetch = await _Respone.GetResponeCodesByID(id);
            return View(Fetch);

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id, bool? saveChangesError)
        {

            ResponeCodes asso = await _Respone.GetResponeCodesByID(id);
            return View(asso);

        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> Delete(int id)
        {

            if (ModelState.IsValid)
            {
                ResponeCodes asso = await _Respone.GetResponeCodesByID(id);
                _Respone.DeleteResponeCodes(id);
                return RedirectToAction("ResponeCodesList");
            }
            else
            {
                return RedirectToAction("Delete");
            }

            return null;




        }






    }
}

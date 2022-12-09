using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using repository;
using System.Data;
using System.Text;

namespace MAK_Lte_Mw.Controllers
{
    public class ResponseCodesController : Controller
    {

        private readonly IResponseCodes _Response;

        public ResponseCodesController(IResponseCodes response)
        {
            _Response = response;
        }






        [HttpGet]
        public async Task<IActionResult> AddResponeCodes()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");
            }



            return View("AddResponeCodes");
        }


        [HttpPost]
        public async Task<IActionResult> AddResponeCodes(ResponseCodes e)
        {

            var add = await _Response.AddResponseCodes(e);

            if (add != null)
            {
                if (HttpContext.Session.GetString("username") == null)
                {
                    return RedirectToAction("LoginView", "Login");
                }

                return RedirectToAction("ResponseList");
                            
            }

            return View(e);
        }



        [HttpGet]
        public async Task<IActionResult> ResponseList()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");
            }

            var list = await _Response.ListResponseCodes();
            return View(list);
        }



        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            ResponseCodes Fetch = await _Response.GetAddResponseCodesByID(id);
            return View(Fetch);


        }


        [HttpPost]
        public async Task<IActionResult> Edit(ResponseCodes a)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _Response.Edit(a);


                    return RedirectToAction("ResponseList");
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

            ResponseCodes parti = await _Response.GetAddResponseCodesByID(id);
            return View(parti);

        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> Delete(int id)
        {

            if (ModelState.IsValid)
            {
                ResponseCodes parti = await _Response.GetAddResponseCodesByID(id);
                _Response.DeleteResponseCodes(id);
                return RedirectToAction("ResponseList");
            }
            else
            {
                return RedirectToAction("Delete");
            }

            return null;




        }


    }
}

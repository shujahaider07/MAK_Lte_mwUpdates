using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using repository;
using System.Data;

namespace MAK_Lte_Mw.Controllers
{
    public class ResponseCodeMappingController : Controller
    {

        private readonly IResponseCodeMapping _ResponseCodeMapping;


        public ResponseCodeMappingController(IResponseCodeMapping _ResponseCodeMapping)
        {
            this._ResponseCodeMapping = _ResponseCodeMapping;
        }




        [HttpGet]
        public async Task<IActionResult> ResponeCodesList()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");
            }

            var list = await _ResponseCodeMapping.ListResponseCodeMapping();

            return View(list);
        }



        [HttpGet]
        public async Task<IActionResult> ResponeCodesMapping()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");
            }


            return View();
        }


        [HttpPost]
        public async Task<IActionResult> ResponeCodesMapping(ResponseCodeMapping a)
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");

            }

            if (ModelState.IsValid)
            {
                var add = await _ResponseCodeMapping.AddResponseCodeMapping(a);
                return RedirectToAction("ResponeCodesList");

            }

            return View(a);


        }

        [HttpPost]
        public async Task<IActionResult> Edit(ResponseCodeMapping a)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _ResponseCodeMapping.Edit(a);


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

            ResponseCodeMapping Fetch = await _ResponseCodeMapping.GetResponseCodeMappingByID(id);
            return View(Fetch);

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id, bool? saveChangesError)
        {

            ResponseCodeMapping asso = await _ResponseCodeMapping.GetResponseCodeMappingByID(id);
            return View(asso);

        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> Delete(int id)
        {

            if (ModelState.IsValid)
            {
                ResponseCodeMapping asso = await _ResponseCodeMapping.GetResponseCodeMappingByID(id);
                _ResponseCodeMapping.DeleteResponseCodeMapping(id);
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

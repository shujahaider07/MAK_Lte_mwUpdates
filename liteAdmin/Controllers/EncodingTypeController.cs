using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using repository;
using System.Data;

namespace MAK_Lte_Mw.Controllers
{
    public class EncodingTypeController : Controller
    {
        private readonly IEncodingType _encoding;


        public EncodingTypeController(IEncodingType encodingType)
        {
            this._encoding = encodingType;
        }




        [HttpGet]
        public async Task<IActionResult> Encoding()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");
            }

           

            return View("Encoding");
        }


        [HttpPost]
        public async Task<IActionResult> Encoding(EncodingType e)
        {

            var add = await _encoding.AddEncodingType(e);

            if (add != null)
            {
                if (HttpContext.Session.GetString("username") == null)
                {
                    return RedirectToAction("LoginView", "Login");
                }

                return RedirectToAction("EncodingList");

            }

            return View(e);
        }



        [HttpGet]
        public async Task<IActionResult> EncodingList()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");
            }

            var list = await _encoding.ListEncodingType();
            return View(list);
        }



        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            EncodingType Fetch = await _encoding.GetEncodingTypeByID(id);
            return View(Fetch);


        }


        [HttpPost]
        public async Task<IActionResult> Edit(EncodingType a)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _encoding.Edit(a);


                    return RedirectToAction("EncodingList");
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

            EncodingType parti = await _encoding.GetEncodingTypeByID(id);
            return View(parti);

        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> Delete(int id)
        {

            if (ModelState.IsValid)
            {
                EncodingType parti = await _encoding.GetEncodingTypeByID(id);
                _encoding.DeleteEncodingType(id);
                return RedirectToAction("EncodingList");
            }
            else
            {
                return RedirectToAction("Delete");
            }

            return null;




        }



    }
}

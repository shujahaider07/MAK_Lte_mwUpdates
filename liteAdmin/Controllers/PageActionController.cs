using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using repository;
using System.Data;

namespace MAK_Lte_Mw.Controllers
{
    public class PageActionController : Controller
    {

        private readonly IPageAction _page;


        public PageActionController(IPageAction _page)
        {
            this._page = _page;
        }




        [HttpGet]
        public async Task<IActionResult> PageActionList()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");
            }

            var list = await _page.ListPageAction();

            return View(list);
        }



        [HttpGet]
        public async Task<IActionResult> PageAction()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");
            }


            return View();
        }


        [HttpPost]
        public async Task<IActionResult> PageAction(PageAction a)
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");

            }

            if (ModelState.IsValid)
            {
                var add = await _page.AddPageAction(a);
                return RedirectToAction("PageActionList");

            }

            return View(a);


        }

        [HttpPost]
        public async Task<IActionResult> Edit(PageAction a)
        {

            try
            {
                if (ModelState.IsValid)
                {
                     _page.Edit(a);


                    return RedirectToAction("PageActionList");
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

            PageAction Fetch = await _page.GetPageActionByID(id);
            return View(Fetch);

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id, bool? saveChangesError)
        {

            PageAction asso = await _page.GetPageActionByID(id);
            return View(asso);

        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> Delete(int id)
        {

            if (ModelState.IsValid)
            {
                PageAction asso = await _page.GetPageActionByID(id);
                _page.DeletePageAction(id);
                return RedirectToAction("PageActionList");
            }
            else
            {
                return RedirectToAction("Delete");
            }

            return null;




        }




    }
}

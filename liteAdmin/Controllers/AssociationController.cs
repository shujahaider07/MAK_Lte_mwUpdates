using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using repository;
using System.Data;

namespace MAK_Lte_Mw.Controllers
{
    public class AssociationController : Controller
    {
        private readonly IAssociation _asso;


        public AssociationController(IAssociation _asso)
        {
            this._asso = _asso;
        }




        [HttpGet]
        public async Task<IActionResult> AssociationList()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");
            }

            var list = await _asso.Listassociation();

            return View(list);
        }   



        [HttpGet]
        public async Task<IActionResult> Association()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");
            }


            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Association(Association a)
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");

            }

            if (ModelState.IsValid)
            {
                var add = await _asso.Addassociation(a);
                return RedirectToAction("AssociationList");
               
            }

            return View(a);


        }

        [HttpPost]
        public async Task<IActionResult> Edit(Association a)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    await _asso.Edit(a);


                    return RedirectToAction("AssociationList");
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

            Association Fetch = await _asso.GetAssociationByID(id);
            return View(Fetch);

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id, bool? saveChangesError)
        {

            Association asso = await _asso.GetAssociationByID(id);
            return View(asso);

        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> Delete(int id)
        {

            if (ModelState.IsValid)
            {
                Association asso = await _asso.GetAssociationByID(id);
                _asso.DeleteAssociation(id);
                return RedirectToAction("AssociationList");
            }
            else
            {
                return RedirectToAction("Delete");
            }

            return null;

           
              

        }
    
    }

}
using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using repository;
using System.Data;

namespace MAK_Lte_Mw.Controllers
{
    public class SafConfigurationController : Controller
    {
        private readonly ISafConfiguration _safe;
        private readonly ApplicationDbContext db;
        public SafConfigurationController(ApplicationDbContext db, ISafConfiguration _safe)
        {
            this._safe = _safe;
            this.db = db;

        }



        [HttpGet]
        public async Task<IActionResult> SafConfiguration()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");
            }

            try
            {

                List<Participants> participants = db.participants.Select(x => new Participants { Id = x.Id, Name = x.Name }).ToList();
                ViewBag.ParticipantData = new SelectList(participants, "Id", "Name");


            }
            catch (Exception)
            {

            }

            return View("SafConfiguration");
        }




        [HttpPost]
        public async Task<IActionResult> SafConfiguration(SafConfiguration s)
        {

            var add = await _safe.AddSafConfiguration(s);

            if (add != null)
            {
                if (HttpContext.Session.GetString("username") == null)
                {
                    return RedirectToAction("LoginView", "Login");
                }

                return RedirectToAction("SafConfigurationList");

            }

            return View(s);
        }



        [HttpGet]
        public async Task<IActionResult> SafConfigurationList()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");
            }

            var list = _safe.ListSafConfiguration();
            return View(list);
        }



        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            List<Participants> participants = db.participants.Select(x => new Participants { Id = x.Id, Name = x.Name }).ToList();
            ViewBag.ParticipantData = new SelectList(participants, "Id", "Name");

            SafConfiguration Fetch = await _safe.GetSafConfigurationsByID(id);
            return View(Fetch);



        }


        [HttpPost]
        public async Task<IActionResult> Edit(SafConfiguration s)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _safe.Edit(s);


                    return RedirectToAction("SafConfigurationList");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(s);


        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id, bool? saveChangesError)
        {

            SafConfiguration parti = await _safe.GetSafConfigurationsByID(id);
            return View(parti);

        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> Delete(int id)
        {

            if (ModelState.IsValid)
            {
                SafConfiguration parti = await _safe.GetSafConfigurationsByID(id);
                _safe.DeleteSafConfiguration(id);
                return RedirectToAction("SafConfigurationList");
            }
            else
            {
                return RedirectToAction("Delete");
            }

            return null;




        }







    }
}

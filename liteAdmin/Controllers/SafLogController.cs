using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using repository;
using System.Data;

namespace MAK_Lte_Mw.Controllers
{
    public class SafLogController : Controller
    {

        private readonly ISafLog _safelOg;
        private readonly ApplicationDbContext db;
        public SafLogController(ApplicationDbContext db, ISafLog _safelOg)
        {
            this.db = db;
            this._safelOg = _safelOg;
        }





        [HttpGet]
        public async Task<IActionResult> AddSafLog()
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

            return View("AddSafLog");



        }



        [HttpPost]
        public async Task<IActionResult> AddSafLog(SafLog s)
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");

            }

            if (ModelState.IsValid)
            {
                var add = await _safelOg.AddSafLog(s);
                db.SaveChanges();
                return RedirectToAction("AddSafLogList");

            }

            return View(s);


        }



        [HttpGet]
        public async Task<IActionResult> AddSafLogList()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");
            }

            var list = _safelOg.ListSafLog();
            return View(list);
        }






        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            List<Participants> participants = db.participants.Select(x => new Participants { Id = x.Id, Name = x.Name }).ToList();
            ViewBag.ParticipantData = new SelectList(participants, "Id", "Name");


            SafLog Fetch = await _safelOg.GetSafLogByID(id);
            return View(Fetch);



        }



        [HttpPost]
        public async Task<IActionResult> Edit(SafLog s)
        {

            try
            {
                if (ModelState.IsValid)
                {
                     _safelOg.Edit(s);
                    db.SaveChanges();


                    return RedirectToAction("AddSafLogList");
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

            SafLog ada = await _safelOg.GetSafLogByID(id);
            return View(ada);

        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> Delete(int id)
        {

            if (ModelState.IsValid)
            {
                SafLog ada = await _safelOg.GetSafLogByID(id);
                _safelOg.DeleteSafLog(id);
                return RedirectToAction("AddSafLogList");
            }
            else
            {
                return RedirectToAction("Delete");
            }

            return null;



        }


    }
}

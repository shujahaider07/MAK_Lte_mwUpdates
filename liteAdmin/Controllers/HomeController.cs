using BusinessLogic;
using liteAdmin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using repository;
using System.Data;
using System.Diagnostics;

namespace liteAdmin.Controllers
{
    //  [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IParticipantType _partiType;

        public HomeController(ApplicationDbContext db, IParticipantType type)
        {
            this.db = db;

            this._partiType = type;

        }


        public IActionResult index()
        {
            //if session null then redirect to login
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");
            }

            var count = db.users.Count();

            ViewBag.countusers = count;

            return View();
        }




        [HttpGet]
        public IActionResult Users()
        {

            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");
            }

            return View();
        }




        [HttpGet]
        public async Task<IActionResult> ParticipantsType()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");
            }

            //ParticipantType types = new ParticipantType();
            //types.participantList = db.participantType.Select(x => new ParticipantTypeRepo { Id = x.Id, participantList = x.Nmae }).ToList();

            //return View(types);


            //List<Participants> participants = db.participants.Select(x => new Participants { ParticipantTypeId = x.ParticipantTypeId, Name = x.Name }).ToList();

            //ViewBag.ParticipantData = new SelectList(participants, "ParticipantTypeId", "Name");

            return View();
        }




        [HttpPost]
        public async Task<IActionResult> ParticipantsType(ParticipantType pt)
        {



            var add = await _partiType.AddparticipantType(pt);

            if (add != null)
            {
                if (HttpContext.Session.GetString("username") == null)
                {
                    return RedirectToAction("LoginView", "Login");
                }

                return RedirectToAction("ParticipantTypeList");

            }

            return View(pt);
        }




        [HttpGet]
        public IActionResult ParticipantTypeList()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");
            }

            var list = _partiType.ListParticipantType();
            return View(list);
        }




        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            //List<Participants> participants = db.participants.Select(x => new Participants { ParticipantTypeId = x.ParticipantTypeId, Name = x.Name }).ToList();

            //ViewBag.ParticipantData = new SelectList(participants, "ParticipantTypeId", "Name");

            ParticipantType Fetch = await _partiType.GetParticipantTypeByID(id);
            return View(Fetch);



        }



        [HttpPost]
        public  IActionResult Edit(ParticipantType a)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _partiType.Edit(a);


                    return RedirectToAction("ParticipantTypeList");
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

            ParticipantType parti = await _partiType.GetParticipantTypeByID(id);
            return View(parti);

        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> Delete(int id)
        {

            if (ModelState.IsValid)
            {
                ParticipantType parti = await _partiType.GetParticipantTypeByID(id);
                _partiType.DeleteParticipantType(id);
                return RedirectToAction("ParticipantTypeList");
            }
            else
            {
                return RedirectToAction("Delete");
            }

            return null;




        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
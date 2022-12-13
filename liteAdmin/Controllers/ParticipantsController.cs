using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using repository;
using System.Data;

namespace MAK_Lte_Mw.Controllers
{
    public class ParticipantsController : Controller
    {
        private readonly IParticipants _parti;
        private readonly ApplicationDbContext db;
        public ParticipantsController(ApplicationDbContext db, IParticipants _parti)
        {
            this._parti = _parti;
            this.db = db;

        }



        [HttpGet]
        public async Task<IActionResult> Participants()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");
            }

            Participants p = new Participants();

            try
            {
                if (ModelState.IsValid)
                {
                    List<Association> associations = db.association.Select(x => new Association { Id = x.Id, Name = x.Name }).ToList();
                    ViewBag.associationData = new SelectList(associations, "Id", "Name");

                    List<ParticipantType> participantType = db.participantType.Select(x => new ParticipantType { Id = x.Id }).ToList();
                    ViewBag.participantType = new SelectList(participantType, "Id", "Id");

                    p.IsActiveNew = p.IsActive.ToString() == "1" ? true : false;
                }





                //Participants types = new Participants();
                //types.AssociationList = db.association.Select(x => new Association { Id = x.Id, Name = x.Name }).ToList();

                //return View(types);


                //List<Association> associations1 = new List<Association>();
                //associations1 = (from Association in db.association select Association).ToList();

                //List<Association> associations = db.association.ToList();
                //associations.Insert(0, new Association { Id = 0, Name = "select" });
                //ViewBag.associationData = associations;



                //ViewBag.association = new SelectList(db.association,"Id","Name");


            }
            catch (Exception)
            {

            }

            return View("Participants", p);
        }


        [HttpPost]
        public async Task<IActionResult> Participants(Participants p)
        {

            //if (IsActive == "true")
            //{
            //    p.IsActive = false;

            //}

            if (p.IsActiveNew != false)
            {
                p.IsActive = '1';
            }
            else
            {
                p.IsActive = '0';
            }

            var add = await _parti.Addparticipant(p);

            if (add != null)
            {
                if (HttpContext.Session.GetString("username") == null)
                {
                    return RedirectToAction("LoginView", "Login");
                }

                return RedirectToAction("ParticipantsList");

            }

            return View(p);
        }



        [HttpGet]
        public async Task<IActionResult> ParticipantsList()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");
            }

            var list = await _parti.ListParticipants();
            return View(list);
        }



        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            Participants p = new Participants();
            
            p.IsActiveNew = p.IsActive.ToString() == "1" ? true : false; 


            List<Association> associations = db.association.Select(x => new Association { Id = x.Id, Name = x.Name }).ToList();
            ViewBag.associationData = new SelectList(associations, "Id", "Name");

            List<ParticipantType> participantType = db.participantType.Select(x => new ParticipantType { Id = x.Id }).ToList();
            ViewBag.participantType = new SelectList(participantType, "Id", "Id");

            Participants Fetch = await _parti.GetParticipantsByID(id);
            return View(Fetch);



        }


        [HttpPost]
        public async Task<IActionResult> Edit(Participants a)
        {
            if (a.IsActiveNew != false)
            {
                a.IsActive = '1';
            }
            else
            {
                a.IsActive = '0';
            }
            try
            {
                if (ModelState.IsValid)
                {
                    await _parti.Edit(a);


                    return RedirectToAction("ParticipantsList");
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

            Participants parti = await _parti.GetParticipantsByID(id);
            return View(parti);

        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> Delete(int id)
        {

            if (ModelState.IsValid)
            {
                Participants parti = await _parti.GetParticipantsByID(id);
                _parti.DeleteParticipants(id);
                return RedirectToAction("ParticipantsList");
            }
            else
            {
                return RedirectToAction("Delete");
            }

            return null;




        }



        public IActionResult Index()
        {
            return View();
        }
    }
}

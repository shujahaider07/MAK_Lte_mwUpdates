using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using repository;
using System.Data;
using System.Text;

namespace MAK_Lte_Mw.Controllers
{
    public class MessageFormatconfigurationController : Controller
    {

        private readonly IMessageFormatconfiguration _messsage;
        private readonly ApplicationDbContext db;


        public MessageFormatconfigurationController(IMessageFormatconfiguration _messsage, ApplicationDbContext db)
        {
            this._messsage = _messsage;
            this.db = db;
        }




        [HttpGet]
        public async Task<IActionResult> AddMessageFormatconfiguration()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");
            }


            List<Association> associations = db.association.Select(x => new Association { Id = x.Id, Name = x.Name }).ToList();
            ViewBag.associationData = new SelectList(associations, "Id", "Name");

            List<ParticipantType> participantType = db.participantType.Select(x => new ParticipantType { Id = x.Id }).ToList();
            ViewBag.participantType = new SelectList(participantType, "Id", "Id");


            List<Participants> participants = db.participants.Select(x => new Participants { Id = x.Id, Name = x.Name }).ToList();
            ViewBag.ParticipantData = new SelectList(participants, "Id", "Name");


            List<InternalFields> internalFields= db.InternalFields.Select(x => new InternalFields { Id = x.Id, Name = x.Name }).ToList();
            ViewBag.internalFields = new SelectList(internalFields, "Id", "Name");


            List<EncodingType> encodingtype = db.EncodingType.Select(x => new EncodingType { Id = x.Id}).ToList();
            ViewBag.encodingtype = new SelectList(encodingtype, "Id", "Id");


            return View("AddMessageFormatconfiguration");
        }


        [HttpPost]
        public async Task<IActionResult> AddMessageFormatconfiguration(MessageFormatconfiguration e)
        {

            var add = await _messsage.AddMessageFormatconfiguration(e);

            if (add != null)
            {
                if (HttpContext.Session.GetString("username") == null)
                {
                    return RedirectToAction("LoginView", "Login");
                }

                return RedirectToAction("MessageFormatconfigurationList");

            }

            return View(e);
        }



        [HttpGet]
        public async Task<IActionResult> MessageFormatconfigurationList()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("LoginView", "Login");
            }

            var list = await _messsage.ListMessageFormatconfiguration();
            return View(list);
        }



        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            List<Association> associations = db.association.Select(x => new Association { Id = x.Id, Name = x.Name }).ToList();
            ViewBag.associationData = new SelectList(associations, "Id", "Name");

            List<ParticipantType> participantType = db.participantType.Select(x => new ParticipantType { Id = x.Id }).ToList();
            ViewBag.participantType = new SelectList(participantType, "Id", "Id");


            List<Participants> participants = db.participants.Select(x => new Participants { Id = x.Id, Name = x.Name }).ToList();
            ViewBag.ParticipantData = new SelectList(participants, "Id", "Name");


            List<InternalFields> internalFields = db.InternalFields.Select(x => new InternalFields { Id = x.Id, Name = x.Name }).ToList();
            ViewBag.internalFields = new SelectList(internalFields, "Id", "Name");


            List<EncodingType> encodingtype = db.EncodingType.Select(x => new EncodingType { Id = x.Id }).ToList();
            ViewBag.encodingtype = new SelectList(encodingtype, "Id", "Id");

            MessageFormatconfiguration Fetch = await _messsage.GetMessageFormatconfigurationByID(id);
            return View(Fetch);


        }


        [HttpPost]
        public async Task<IActionResult> Edit(MessageFormatconfiguration a)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _messsage.Edit(a);


                    return RedirectToAction("MessageFormatconfigurationList");
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

            MessageFormatconfiguration parti = await _messsage.GetMessageFormatconfigurationByID(id);
            return View(parti);

        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> Delete(int id)
        {

            if (ModelState.IsValid)
            {
                MessageFormatconfiguration parti = await _messsage.GetMessageFormatconfigurationByID(id);
                _messsage.DeleteMessageFormatconfiguration(id);
                return RedirectToAction("MessageFormatconfigurationList");
            }
            else
            {
                return RedirectToAction("Delete");
            }

            return null;




        }








    }
}

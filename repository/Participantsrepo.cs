using BusinessLogic;
using Microsoft.EntityFrameworkCore;

namespace repository
{
    public class Participantsrepo : IParticipants
    {
        private readonly ApplicationDbContext db;

        public Participantsrepo(ApplicationDbContext db)
        {

            this.db = db;
        }
        public async Task<Participants> Addparticipant(Participants p)
        {

            try
            {

                Participants participants = new Participants();

                participants.ParticipantTypeId = p.ParticipantTypeId;
                participants.Name = p.Name;
                participants.Code = p.Code;
                participants.Bins = p.Bins;
                participants.IsEchoEnable = p.IsEchoEnable;
                participants.MsgEchoTimer = p.MsgEchoTimer;
                participants.IsActive = p.IsActive;
                participants.AssociationId = p.AssociationId;
                participants.CreatedOn = DateTime.Now;
                participants.CreatedBy = p.CreatedBy;
                participants.UpdateOn = DateTime.Now;
                participants.UpdatedBy = p.UpdatedBy;


                var add = db.participants.AddAsync(participants);
                await db.SaveChangesAsync();


            }


            catch (Exception)
            {

            }

            return p;



        }

        public void DeleteParticipants(int Id)
        {
            Participants parti = db.participants.Find(Id);
            db.participants.Remove(parti);
            db.SaveChanges();
        }

        public async Task<IEnumerable<Participants>> Edit(Participants p)
        {
            var Data = db.participants.Where(x => x.Id == p.Id).FirstOrDefault();
            if (Data != null)
            {
                Data.Name = p.Name;
                Data.ParticipantTypeId = p.ParticipantTypeId;
                Data.Code = p.Code;
                Data.Bins = p.Bins;
                Data.IsEchoEnable = p.IsEchoEnable;
                Data.MsgEchoTimer = p.MsgEchoTimer;
                Data.IsActive = p.IsActive;
                Data.AssociationId = p.AssociationId;
                Data.CreatedOn = p.CreatedOn;
                Data.CreatedBy = p.CreatedBy;
                Data.UpdatedBy = p.UpdatedBy;
                Data.UpdateOn = p.UpdateOn;

                db.Entry(Data).State = EntityState.Modified;
                db.SaveChanges();
            }

             return null;
        }

        public async Task<Participants> GetParticipantsByID(int Id)
        {
            return await db.participants.FindAsync(Id);
        }

        public async Task<IEnumerable<Participants>> ListParticipants()
        {
            return await db.participants.ToListAsync();
         
        }
    }
}

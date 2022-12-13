using BusinessLogic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.IO;

namespace repository
{
    public class ParticipantTypeRepo : IParticipantType
    {

        private readonly ApplicationDbContext db;
        public ParticipantTypeRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<ParticipantType> AddparticipantType(ParticipantType p)
        {
            try
            {

                ParticipantType participanttype = new ParticipantType();

                participanttype.Type = p.Type;
                participanttype.Descryption = p.Descryption;
              

                var add = db.participantType.AddAsync(participanttype);
                await db.SaveChangesAsync();


            }


            catch (Exception)
            {

            }

            return p;
        }

        public void DeleteParticipantType(int Id)
        {
            ParticipantType parti = db.participantType.Find(Id);
            db.participantType.Remove(parti);
            db.SaveChanges();
        }

        public Task<IEnumerable<ParticipantType>> Edit(ParticipantType p)
        {

            var Data = db.participantType.Where(x => x.Id == p.Id).FirstOrDefault();
            if (Data != null)
            {
                Data.Type = p.Type;
                Data.Descryption = p.Descryption;
                //Data.ParticipantTypeId = p.ParticipantTypeId;

                db.Entry(Data).State = EntityState.Modified;
             
            }
            
            db.SaveChanges();
            //{ return null; }
            return null;

        }

        public async Task<ParticipantType> GetParticipantTypeByID(int Id)
        {
            return await db.participantType.FindAsync(Id);
        }

        public IEnumerable<ParticipantType> ListParticipantType()
        {

            //List<ParticipantType> parti = db.participantType.Select(x => new ParticipantType { Id = x.Id, Type = x.Type, ParticipantTypeId = x.ParticipantTypeId, Descryption = x.Descryption }).ToList();

            //return parti; 
            return db.participantType.ToList();

        }
    }
}

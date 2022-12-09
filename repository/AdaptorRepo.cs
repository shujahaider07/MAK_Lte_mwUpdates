using BusinessLogic;
using Microsoft.EntityFrameworkCore;

namespace repository
{
    public class AdaptorRepo : IAdaptor
    {

        private readonly ApplicationDbContext db;

        public AdaptorRepo(ApplicationDbContext db)
        {

            this.db = db;
        }

        public async Task<Adaptor> Addadaptor(Adaptor a)
        {

            try
            {

                Adaptor adaptor = new Adaptor();

                adaptor.ParticipantId = a.ParticipantId;
                adaptor.AdaptorTypeId = a.AdaptorTypeId;
                adaptor.Address = a.Address;
                adaptor.IsServer = a.IsServer;
                adaptor.AllowedIp = a.AllowedIp;
                adaptor.TimeoutInSec = a.TimeoutInSec;
                adaptor.CreatedOn = DateTime.Now;
                adaptor.CreatedBy = a.CreatedBy;
                adaptor.UpdateOn = DateTime.Now;
                adaptor.UpdatedBy = a.UpdatedBy;
                adaptor.IsActive = a.IsActive;
                adaptor.AssociationId = a.AssociationId;


                var add = db.adaptor.AddAsync(adaptor);
                await db.SaveChangesAsync();


            }


            catch (Exception)
            {

            }

            return a;

        }

        public void DeleteAdaptor(int Id)
        {
            Adaptor ada = db.adaptor.Find(Id);
            db.adaptor.Remove(ada);
            db.SaveChanges();
        }

        public Task<IEnumerable<Adaptor>> Edit(Adaptor a)
        {
            var Data = db.adaptor.Where(x => x.Id == a.Id).FirstOrDefault();
            if (Data != null)
            {
                Data.ParticipantId = a.ParticipantId;
                Data.AdaptorTypeId = a.AdaptorTypeId;
                Data.Address = a.Address;
                Data.IsServer = a.IsServer;
                Data.AllowedIp = a.AllowedIp;
                Data.TimeoutInSec = a.TimeoutInSec;
                Data.CreatedBy = a.CreatedBy;
                Data.CreatedOn = a.CreatedOn;
                Data.UpdatedBy = a.UpdatedBy;
                Data.UpdateOn = a.UpdateOn;
                Data.IsActive = a.IsActive;
                Data.AssociationId = a.AssociationId;
              
               
                db.Entry(Data).State = EntityState.Modified;
                db.SaveChanges();
            }

            return null;
        }

        public async Task<Adaptor> GetAdaptorByID(int Id)
        {
            return await db.adaptor.FindAsync(Id);
        }

        public async Task<IEnumerable<Adaptor>> ListAdaptor()
        {
            return await db.adaptor.ToListAsync();
        }
    }
}

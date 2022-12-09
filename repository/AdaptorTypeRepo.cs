using BusinessLogic;
using Microsoft.EntityFrameworkCore;

namespace repository
{
    public class AdaptorTypeRepo : IAdaptorType
    {
        private readonly ApplicationDbContext db;

        public AdaptorTypeRepo(ApplicationDbContext db)
        {

            this.db = db;

        }
        

        public async Task<AdaptorType> AddadaptorType(AdaptorType a)
        {

            try
            {

                AdaptorType adaptortype = new AdaptorType();

                adaptortype.Type = a.Type;
                adaptortype.Description = a.Description;
                adaptortype.CreatedBy = a.CreatedBy;
                adaptortype.CreatedOn = DateTime.Now;
                adaptortype.AdaptorTypeId = a.AdaptorTypeId;



                var add = db.adaptorType.AddAsync(adaptortype);
                await db.SaveChangesAsync();


            }


            catch (Exception)
            {

            }

            return a;
        }

        public void DeleteAdaptorType(int Id)
        {

           AdaptorType adatype = db.adaptorType.Find(Id);
            if (adatype != null)
            {
                db.adaptorType.Remove(adatype);
                db.SaveChanges();

            }

        }

        public Task<IEnumerable<AdaptorType>> Edit(AdaptorType a)
        {
            var Data = db.adaptorType.Where(x => x.Id == a.Id).FirstOrDefault();
            if (Data != null)
            {
                Data.Type = a.Type;
                Data.Description = a.Description;
                Data.CreatedBy = a.CreatedBy;
                Data.CreatedOn = a.CreatedOn;
                Data.CreatedOn = a.CreatedOn;
                Data.AdaptorTypeId = a.AdaptorTypeId;
              

                db.Entry(Data).State = EntityState.Modified;
                db.SaveChanges();
            }

            return null;
        }

        public async Task<AdaptorType> GetAdaptorTypeByID(int Id)
        {
            return await db.adaptorType.FindAsync(Id);
        }

        public async Task<IEnumerable<AdaptorType>> ListAdaptorType()
        {
            return await db.adaptorType.ToListAsync();
        }
    }
}

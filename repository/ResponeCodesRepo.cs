using BusinessLogic;
using Microsoft.EntityFrameworkCore;

namespace repository
{
    public class ResponeCodesRepo : IResponeCodes
    {
        private readonly ApplicationDbContext db;

        public ResponeCodesRepo(ApplicationDbContext db)
        {

            this.db = db;
        }


        public async Task<ResponeCodes> AddResponeCodes(ResponeCodes r)
        {

            try
            {

                ResponeCodes respone = new ResponeCodes();

                respone.Description = r.Description;
                respone.CreatedOn = DateTime.Now;
                respone.CreatedBy = r.CreatedBy;
                respone.UpdatedBy = r.UpdatedBy;
                respone.UpdateOn = DateTime.Now;


                var add = db.ResponeCodes.AddAsync(respone);
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {

            }

            return r;

        }

        public void DeleteResponeCodes(int Id)
        {
            ResponeCodes users = db.ResponeCodes.Find(Id);
            db.ResponeCodes.Remove(users);
            db.SaveChanges();
        }

        public Task<IEnumerable<ResponeCodes>> Edit(ResponeCodes r)
        {
            var Data = db.ResponeCodes.Where(x => x.Id == r.Id).FirstOrDefault();
            if (Data != null)
            {
                Data.Description = r.Description;
                Data.CreatedOn = DateTime.Now;
                Data.CreatedBy = r.CreatedBy;
                Data.UpdatedBy = r.UpdatedBy;
                Data.UpdateOn = DateTime.Now;


                db.Entry(Data).State = EntityState.Modified;
                db.SaveChanges();
            }

            return null;
        }

        public async Task<ResponeCodes> GetResponeCodesByID(int Id)
        {
            return await db.ResponeCodes.FindAsync(Id);
        }

        public async Task<IEnumerable<ResponeCodes>> ListResponeCodes()
        {
            return await db.ResponeCodes.ToListAsync();
        }
    }
}

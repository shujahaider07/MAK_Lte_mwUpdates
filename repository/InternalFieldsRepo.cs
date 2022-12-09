using BusinessLogic;
using Microsoft.EntityFrameworkCore;

namespace repository
{
    public class InternalFieldsRepo : IInternalFields
    {
        private readonly ApplicationDbContext db;
        public InternalFieldsRepo(ApplicationDbContext db)
        {
            this.db = db;
        }




        public async Task<InternalFields> AddInternalFields(InternalFields i)
        {
            try
            {

                InternalFields internalFields = new InternalFields();


                internalFields.Name = i.Name;
                internalFields.CreatedOn = DateTime.Now;
                internalFields.CreatedBy = i.CreatedBy;
                internalFields.UpdatedBy = i.UpdatedBy;
                internalFields.UpdatedOn = DateTime.Now;

                var add = db.InternalFields.AddAsync(internalFields);
                await db.SaveChangesAsync();


            }

            catch (Exception)
            {

            }

            return i;
        }

        public void DeleteInternalFields(int Id)
        {
            InternalFields aso = db.InternalFields.Find(Id);
            db.InternalFields.Remove(aso);
            db.SaveChanges();
        }

        public Task<IEnumerable<InternalFields>> Edit(InternalFields i)
        {
            var internalFields = db.InternalFields.Where(x => x.Id == i.Id).FirstOrDefault();
            if (internalFields != null)
            {
                internalFields.Name = i.Name;
                internalFields.CreatedOn = DateTime.Now;
                internalFields.CreatedBy = i.CreatedBy;
                internalFields.UpdatedBy = i.UpdatedBy;
                internalFields.UpdatedOn = DateTime.Now;



                db.Entry(internalFields).State = EntityState.Modified;
                db.SaveChanges();
            }

            { return null; }
        }

        public async Task<InternalFields> GetInternalFieldsByID(int Id)
        {
            return await db.InternalFields.FindAsync(Id);
        }

        public async Task<IEnumerable<InternalFields>> ListInternalFields()
        {
            return await db.InternalFields.ToListAsync();
        }
    }
}

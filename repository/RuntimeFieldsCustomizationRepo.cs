using BusinessLogic;
using Microsoft.EntityFrameworkCore;

namespace repository
{
    public class RuntimeFieldsCustomizationRepo : IRuntimeFieldsCustomization
    {

        
        private readonly ApplicationDbContext db;


        public RuntimeFieldsCustomizationRepo(ApplicationDbContext db)
        {
            this.db = db;
            
        }



        public async Task<RuntimeFieldsCustomization> AddRuntimeFieldsCustomization(RuntimeFieldsCustomization r)
        {
            try
            {

                RuntimeFieldsCustomization runtime = new RuntimeFieldsCustomization();

                runtime.ParticipantId = r.ParticipantId;
                runtime.TransactionIdentifierId = r.TransactionIdentifierId;
                runtime.Condition = r.Condition;
                runtime.Value = r.Value;
                runtime.Sequence = r.Sequence;
                runtime.InternalFieldId = r.InternalFieldId;
                runtime.CreatedBy = r.CreatedBy;
                runtime.CreatedOn = DateTime.Now;
                runtime.UpdatedOn = DateTime.Now;
                runtime.UpdatedBy = r.UpdatedBy;

                var add = db.RuntimeFieldsCustomization.AddAsync(runtime);
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {

            }

            return r;
        }

        public void DeleteRuntimeFieldsCustomization(int Id)
        {
            RuntimeFieldsCustomization runtime = db.RuntimeFieldsCustomization.Find(Id);
            db.Remove(runtime);
            db.SaveChanges();
        }

        public Task<IEnumerable<RuntimeFieldsCustomization>> Edit(RuntimeFieldsCustomization r)
        {

            var runtime = db.RuntimeFieldsCustomization.Where(x => x.Id == r.Id).FirstOrDefault();
            if (runtime != null)
            {
                runtime.ParticipantId = r.ParticipantId;
                runtime.TransactionIdentifierId = r.TransactionIdentifierId;
                runtime.Condition = r.Condition;
                runtime.Value = r.Value;
                runtime.Sequence = r.Sequence;
                runtime.InternalFieldId = r.InternalFieldId;
                runtime.CreatedBy = r.CreatedBy;
                runtime.CreatedOn = DateTime.Now;
                runtime.UpdatedOn = DateTime.Now;
                runtime.UpdatedBy = r.UpdatedBy;


                db.Entry(runtime).State = EntityState.Modified;
                db.SaveChanges();

            }

            return null;
        }

        public async Task<RuntimeFieldsCustomization> GetRuntimeFieldsCustomizationByID(int Id)
        {
            return await db.RuntimeFieldsCustomization.FindAsync(Id);
        }

        public IEnumerable<RuntimeFieldsCustomization> ListRuntimeFieldsCustomization()
        {
            return db.RuntimeFieldsCustomization.ToList();
        }
    }
}

using BusinessLogic;
using Microsoft.EntityFrameworkCore;

namespace repository
{
    public class TransactionCodeMappingRepo : ITransactionCodeMapping
    {
        private readonly ApplicationDbContext db;
        public TransactionCodeMappingRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<TransactionCodeMapping> AddransactionCodeMapping(TransactionCodeMapping tcm)
        {
            try
            {

                TransactionCodeMapping transactionCodeMapping = new TransactionCodeMapping();

                transactionCodeMapping.InternalCode = tcm.InternalCode;
                transactionCodeMapping.ExternalCode = tcm.ExternalCode;
                transactionCodeMapping.ParticipantId = tcm.ParticipantId;
                transactionCodeMapping.CreatedOn = DateTime.Now;
                transactionCodeMapping.CreatedBy = tcm.CreatedBy;
                transactionCodeMapping.UpdateOn = DateTime.Now;
                transactionCodeMapping.UpdatedBy = tcm.UpdatedBy;


                var add = db.TransactionCodeMapping.AddAsync(transactionCodeMapping);
                await db.SaveChangesAsync();


            }


            catch (Exception)
            {

            }

            return tcm;
        }

        public void DeleteTransactionCodes(int Id)
        {
            TransactionCodeMapping tran = db.TransactionCodeMapping.Find(Id);
            db.TransactionCodeMapping.Remove(tran);
            db.SaveChanges();
        }

        public Task<IEnumerable<TransactionCodeMapping>> Edit(TransactionCodeMapping tcm)
        {
            var Data = db.TransactionCodeMapping.Where(x => x.Id == tcm.Id).FirstOrDefault();
            if (Data != null)
            {
                Data.InternalCode = tcm.InternalCode;
                Data.ExternalCode = tcm.ExternalCode;
                Data.ParticipantId = tcm.ParticipantId;
                Data.CreatedOn = tcm.CreatedOn;
                Data.CreatedBy = tcm.CreatedBy;
                Data.UpdatedBy = tcm.UpdatedBy;
                Data.UpdateOn = tcm.UpdateOn;

                db.Entry(Data).State = EntityState.Modified;
                db.SaveChanges();
            }

            return null;
        }

        public async Task<TransactionCodeMapping> GetTransactionCodeMappingID(int Id)
        {
            
                return await db.TransactionCodeMapping.FindAsync(Id);
            
           
        }

        public IEnumerable<TransactionCodeMapping> ListTransactionCodeMapping()
        {

            return db.TransactionCodeMapping.ToList();


        }
    }
}

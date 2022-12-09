using BusinessLogic;
using Microsoft.EntityFrameworkCore;

namespace repository
{
    public class TransactionCodesRepo : ITransactionCodes
    {
        private readonly ApplicationDbContext db;

        public TransactionCodesRepo(ApplicationDbContext db)
        {

            this.db = db;

        }

        public async Task<TransactionCodes> AddtransactionCodes(TransactionCodes tc)
        {

            try
            {

                TransactionCodes transactionCodes = new TransactionCodes();

                transactionCodes.InternalCode = tc.InternalCode;
                transactionCodes.Description = tc.Description;
                transactionCodes.CreatedOn = DateTime.Now;
                transactionCodes.CreatedBy = tc.CreatedBy;
                transactionCodes.UpdateOn = DateTime.Now;
                transactionCodes.UpdatedBy = tc.UpdatedBy;



                var add = db.TransactionCodes.AddAsync(transactionCodes);
                await db.SaveChangesAsync();


            }


            catch (Exception)
            {

            }

            return tc;
        }

        public async void DeleteTransactionCodes(int Id)
        {
            TransactionCodes tran = db.TransactionCodes.Find(Id);
            db.TransactionCodes.Remove(tran);
            db.SaveChanges();
        }

        public Task<IEnumerable<TransactionCodes>> Edit(TransactionCodes p)
        {
            var Data = db.TransactionCodes.Where(x => x.Id == p.Id).FirstOrDefault();
            if (Data != null)
            {
                Data.InternalCode = p.InternalCode;
                Data.Description = p.Description;
                Data.CreatedBy = p.CreatedBy;
                Data.CreatedOn = p.CreatedOn;
                Data.UpdatedBy = p.UpdatedBy;
                Data.UpdateOn = p.UpdateOn;

                db.Entry(Data).State = EntityState.Modified;
                db.SaveChanges();
            }

            return null;
        }

        public async Task<TransactionCodes> GetTransactionCodesByID(int Id)
        {
            return await db.TransactionCodes.FindAsync(Id);
        }

        public IEnumerable<TransactionCodes> ListTransactionCodes()
        {
            return db.TransactionCodes.ToList();
        }
    }
}

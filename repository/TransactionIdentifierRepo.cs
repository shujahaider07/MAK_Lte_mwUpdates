using BusinessLogic;
using Microsoft.EntityFrameworkCore;

namespace repository
{



    public class TransactionIdentifierRepo : ITransactionIdentifier
    {
        private readonly ApplicationDbContext db;

        public TransactionIdentifierRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<TransactionIdentifier> AddransactionIdentifier(TransactionIdentifier t)
        {
            try
            {

                TransactionIdentifier transactionIdentifier = new TransactionIdentifier();

                transactionIdentifier.ParticipantId = t.ParticipantId;
                transactionIdentifier.KeyField1 = t.KeyField1;
                transactionIdentifier.KeyField2 = t.KeyField2;
                transactionIdentifier.KeyField3 = t.KeyField3;
                transactionIdentifier.KeyField4 = t.KeyField4;
                transactionIdentifier.CreatedOn = DateTime.Now;
                transactionIdentifier.CreatedBy = t.CreatedBy;
                transactionIdentifier.UpdatedOn = DateTime.Now;
                transactionIdentifier.UpdatedBy = t.UpdatedBy;



                var add = db.TransactionIdentifier.AddAsync(transactionIdentifier);
                await db.SaveChangesAsync();


            }


            catch (Exception)
            {

            }

            return t;

        }

        public void DeleteTransactionIdentifier(int Id)
        {
            TransactionIdentifier parti = db.TransactionIdentifier.Find(Id);
            db.TransactionIdentifier.Remove(parti);
            db.SaveChanges();
        }

        public Task<IEnumerable<TransactionIdentifier>> Edit(TransactionIdentifier t)
        {
            var Data = db.TransactionIdentifier.Where(x => x.Id == t.Id).FirstOrDefault();
            if (Data != null)
            {
                Data.ParticipantId = t.ParticipantId;
                Data.KeyField1 = t.KeyField1;
                Data.KeyField2 = t.KeyField2;
                Data.KeyField3 = t.KeyField3;
                Data.KeyField4 = t.KeyField4;
                Data.CreatedOn = DateTime.Now;
                Data.CreatedBy = t.CreatedBy;
                Data.UpdatedOn = DateTime.Now;
                Data.UpdatedBy = t.UpdatedBy;


                db.Entry(Data).State = EntityState.Modified;
                db.SaveChanges();
            }

            return null;
        }

        public async Task<TransactionIdentifier> GetTransactionIdentifierID(int Id)
        {
            return await db.TransactionIdentifier.FindAsync(Id);
        }

        public IEnumerable<TransactionIdentifier> ListTransactionIdentifier()
        {
            return db.TransactionIdentifier.ToList();
        }
    }
}


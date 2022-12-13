using BusinessLogic;
using Microsoft.EntityFrameworkCore;

namespace repository
{
    public class TransactionRoutingsRepo : ITransactionRoutings
    {

        private readonly ApplicationDbContext db;

        public TransactionRoutingsRepo(ApplicationDbContext db)
        {

            this.db = db;
        }


        public async Task<TransactionRoutings> AddTransactionRoutings(TransactionRoutings tr)
        {

            try
            {

                TransactionRoutings transactionRoutings = new TransactionRoutings();

                transactionRoutings.ParticipantId = tr.ParticipantId;
                transactionRoutings.KeyFieldId1 = tr.KeyFieldId1;
                transactionRoutings.KeyFIeld2 = tr.KeyFIeld2;
                transactionRoutings.KeyFIeld3 = tr.KeyFIeld3;
                transactionRoutings.KeyFIeld4 = tr.KeyFIeld4;
                transactionRoutings.KeyFIeld5 = tr.KeyFIeld5;
                transactionRoutings.CreatedOn = DateTime.Now;
                transactionRoutings.UpdateOn = DateTime.Now;
                transactionRoutings.CreatedBy = tr.CreatedBy;
                transactionRoutings.UpdatedBy = tr.UpdatedBy;


                var add = db.TransactionRoutings.AddAsync(transactionRoutings);
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {

            }

            return tr;
        }

        public void DeleteTransactionRoutings(int Id)
        {
            TransactionRoutings users = db.TransactionRoutings.Find(Id);
            db.TransactionRoutings.Remove(users);
            db.SaveChanges();
        }

        public Task<IEnumerable<TransactionRoutings>> Edit(TransactionRoutings tr)
        {
            var Data = db.TransactionRoutings.Where(x => x.Id == tr.Id).FirstOrDefault();
            if (Data != null)
            {
                Data.ParticipantId = tr.ParticipantId;
                Data.KeyFieldId1 = tr.KeyFieldId1;
                Data.KeyFIeld2 = tr.KeyFIeld2;
                Data.KeyFIeld3 = tr.KeyFIeld3;
                Data.KeyFIeld4 = tr.KeyFIeld4;
                Data.KeyFIeld5 = tr.KeyFIeld5;
                Data.CreatedOn = DateTime.Now;
                Data.UpdateOn = DateTime.Now;
                Data.CreatedBy = tr.CreatedBy;
                Data.UpdatedBy = tr.UpdatedBy;

                db.Entry(Data).State = EntityState.Modified;
                db.SaveChanges();
            }

            return null;
        }

        public async Task<TransactionRoutings> GetTransactionRoutingsID(int Id)
        {
            return await db.TransactionRoutings.FindAsync(Id);
        }

        public IEnumerable<TransactionRoutings> ListTransactionRoutings()
        {
            return db.TransactionRoutings.ToList();
        }
    }
}

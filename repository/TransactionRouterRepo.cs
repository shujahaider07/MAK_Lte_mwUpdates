using BusinessLogic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository
{
    public class TransactionRouterRepo : ITransactionRouter
    {
        private readonly ApplicationDbContext db;

        public TransactionRouterRepo(ApplicationDbContext db)
        {

            this.db = db;
        }



        public async Task<TransactionRouter> AddTransactionRouter(TransactionRouter tr)
        {

            try
            {

                TransactionRouter transaction = new TransactionRouter();

                transaction.TransactionRoutingId = tr.TransactionRoutingId;
                transaction.SendingQueue = tr.SendingQueue;
                transaction.AdaptorAddress = tr.AdaptorAddress;
                transaction.KeyFIeldValue1 = tr.KeyFIeldValue1;
                transaction.KeyFIeldValue2 = tr.KeyFIeldValue2;
                transaction.KeyFIeldValue3 = tr.KeyFIeldValue3;
                transaction.KeyFIeldValue4 = tr.KeyFIeldValue4;
                transaction.KeyFIeldValue5 = tr.KeyFIeldValue5;
                transaction.CreatedBy = tr.CreatedBy;
                transaction.CreatedOn = DateTime.Now;
                transaction.UpdateOn = DateTime.Now;
                transaction.UpdatedBy = tr.UpdatedBy;
                

                var add = db.TransactionRouter.AddAsync(transaction);
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {

            }

            return tr;
        }

        public void DeleteTransactionRouter(int Id)
        {
            TransactionRouter users = db.TransactionRouter.Find(Id);
            db.TransactionRouter.Remove(users);
            db.SaveChanges();
        }

        public Task<IEnumerable<TransactionRouter>> Edit(TransactionRouter tr)
        {
            var Data = db.TransactionRouter.Where(x => x.Id == tr.Id).FirstOrDefault();
            if (Data != null)
            {
                Data.TransactionRoutingId = tr.TransactionRoutingId;
                Data.SendingQueue = tr.SendingQueue;
                Data.AdaptorAddress = tr.AdaptorAddress;
                Data.KeyFIeldValue1 = tr.KeyFIeldValue1;
                Data.KeyFIeldValue2 = tr.KeyFIeldValue2;
                Data.KeyFIeldValue3 = tr.KeyFIeldValue3;
                Data.KeyFIeldValue4 = tr.KeyFIeldValue4;
                Data.KeyFIeldValue5 = tr.KeyFIeldValue5;
                Data.CreatedBy = tr.CreatedBy;
                Data.CreatedOn = DateTime.Now;
                Data.UpdateOn = DateTime.Now;
                Data.UpdatedBy = tr.UpdatedBy; 

                db.Entry(Data).State = EntityState.Modified;
                db.SaveChanges();
            }

            return null;
        }

        public async Task<TransactionRouter> GetTransactionRouterID(int Id)
        {
            return await db.TransactionRouter.FindAsync(Id);
        }

        public IEnumerable<TransactionRouter> ListTransactionRouter()
        {
            return  db.TransactionRouter.ToList();
        }
    }
}

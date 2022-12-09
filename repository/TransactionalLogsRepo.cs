using BusinessLogic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository
{
    public class TransactionalLogsRepo : ITransactionalLogs
    {
        private readonly ApplicationDbContext db;

        public TransactionalLogsRepo(ApplicationDbContext db)
        {

            this.db = db;
        }


        public async Task<TransactionalLogs> AddTransactionalLogs(TransactionalLogs tl)
        {
            try
            {

                TransactionalLogs transactionalLogs = new TransactionalLogs();

                transactionalLogs.MessageKey = tl.MessageKey;
                transactionalLogs.MessageBody = tl.MessageBody;
                transactionalLogs.Stan = tl.Stan;
                transactionalLogs.MessageType = tl.MessageType;
                transactionalLogs.DateTime = tl.DateTime;
                transactionalLogs.rrn = tl.rrn;
                transactionalLogs.CreatedOn = DateTime.Now;
                transactionalLogs.CreatedBy = tl.CreatedBy;
                transactionalLogs.UpdatedBy = tl.UpdatedBy;
                transactionalLogs.UpdateOn = DateTime.Now;

                var add = db.TransactionalLogs.AddAsync(transactionalLogs);
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {

            }

            return tl;
        }

        public void DeleteTransactionalLogs(int Id)
        {
            TransactionalLogs users = db.TransactionalLogs.Find(Id);
            db.TransactionalLogs.Remove(users);
            db.SaveChanges();
        }

        public Task<IEnumerable<TransactionalLogs>> Edit(TransactionalLogs tl)
        {
            var Data = db.TransactionalLogs.Where(x => x.Id == tl.Id).FirstOrDefault();
            if (Data != null)
            {
                Data.MessageKey = tl.MessageKey;
                Data.MessageBody = tl.MessageBody;
                Data.Stan = tl.Stan;
                Data.MessageType = tl.MessageType;
                Data.DateTime = tl.DateTime;
                Data.rrn = tl.rrn;
                Data.CreatedOn = DateTime.Now;
                Data.CreatedBy = tl.CreatedBy;
                Data.UpdatedBy = tl.UpdatedBy;
                Data.UpdateOn = DateTime.Now;

                db.Entry(Data).State = EntityState.Modified;
                db.SaveChanges();
            }

            return null;
        }

        public async Task<TransactionalLogs> GetTransactionalLogsByID(int Id)
        {
            return await db.TransactionalLogs.FindAsync(Id);
        }

        public IEnumerable<TransactionalLogs> ListTransactionalLogs()
        {
            return db.TransactionalLogs.ToList();
        }
    }
}

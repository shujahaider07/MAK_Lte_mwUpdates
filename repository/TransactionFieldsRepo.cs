using BusinessLogic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository
{
    public class TransactionFieldsRepo : ITransactionFields
    {

        private readonly ApplicationDbContext db;
        public TransactionFieldsRepo(ApplicationDbContext db)
        {
            this.db = db;
        }



        public async Task<TransactionFields> AddTransactionFields(TransactionFields tf)
        {
            try
            {

                TransactionFields transactionFields = new TransactionFields();

                transactionFields.TransactionIdentifierId = tf.TransactionIdentifierId;
                transactionFields.IsOptional = tf.IsOptional;
                transactionFields.CompleteFieldName = tf.CompleteFieldName;
                transactionFields.CreatedBy = tf.CreatedBy;
                transactionFields.CreatedOn = DateTime.Now;
                transactionFields.UpdatedBy = tf.UpdatedBy;
                transactionFields.UpdateOn = DateTime.Now;

                var add = db.TransactionFields.AddAsync(transactionFields);
                await db.SaveChangesAsync();


            }


            catch (Exception)
            {

            }

            return tf;
        }

        public void DeleteTransactionFields(int Id)
        {
            TransactionFields parti = db.TransactionFields.Find(Id);
            db.TransactionFields.Remove(parti);
            db.SaveChanges();
        }

        public Task<IEnumerable<TransactionFields>> Edit(TransactionFields tf)
        {
            var Data = db.TransactionFields.Where(x => x.Id == tf.Id).FirstOrDefault();
            if (Data != null)
            {
                Data.TransactionIdentifierId = tf.TransactionIdentifierId;
                Data.IsOptional = tf.IsOptional;
                Data.CompleteFieldName = tf.CompleteFieldName;
                Data.CreatedBy = tf.CreatedBy;
                Data.CreatedOn = DateTime.Now;
                Data.UpdatedBy = tf.UpdatedBy;
                Data.UpdateOn = DateTime.Now;
                db.Entry(Data).State = EntityState.Modified;

            }

            db.SaveChanges();
            //{ return null; }
            return null;
        }

        public async Task<TransactionFields> GetTransactionFieldsByID(int Id)
        {
            return await db.TransactionFields.FindAsync(Id);
        }

        public IEnumerable<TransactionFields> ListTransactionFields()
        {
            return  db.TransactionFields.ToList();
        }
    }
}

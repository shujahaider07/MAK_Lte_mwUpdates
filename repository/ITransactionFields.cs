using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository
{
    public interface ITransactionFields
    {

        public Task<TransactionFields> AddTransactionFields(TransactionFields tf);

        public IEnumerable<TransactionFields> ListTransactionFields();
        public Task<IEnumerable<TransactionFields>> Edit(TransactionFields tf);

        public Task<TransactionFields> GetTransactionFieldsByID(int Id);
        public void DeleteTransactionFields(int Id);



    }
}

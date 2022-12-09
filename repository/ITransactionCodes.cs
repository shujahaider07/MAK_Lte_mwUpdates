using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository
{
    public interface ITransactionCodes
    {

        public Task<TransactionCodes> AddtransactionCodes(TransactionCodes tc);

        public IEnumerable<TransactionCodes> ListTransactionCodes();
        public Task<IEnumerable<TransactionCodes>> Edit(TransactionCodes p);

        public Task<TransactionCodes> GetTransactionCodesByID(int Id);
        public void DeleteTransactionCodes(int Id);





    }
}

using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository
{
    public interface ITransactionIdentifier
    {

        public Task<TransactionIdentifier> AddransactionIdentifier(TransactionIdentifier t);
        public IEnumerable<TransactionIdentifier> ListTransactionIdentifier();
        public Task<IEnumerable<TransactionIdentifier>> Edit(TransactionIdentifier t);

        public Task<TransactionIdentifier> GetTransactionIdentifierID(int Id);
        public void DeleteTransactionIdentifier(int Id);





    }
}

using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository
{
    public interface ITransactionRouter
    {
        public Task<TransactionRouter> AddTransactionRouter(TransactionRouter tr);

        public IEnumerable<TransactionRouter> ListTransactionRouter();
        public Task<IEnumerable<TransactionRouter>> Edit(TransactionRouter tr);

        public Task<TransactionRouter> GetTransactionRouterID(int Id);
        public void DeleteTransactionRouter(int Id);


    }
}

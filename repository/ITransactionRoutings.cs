using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository
{
    public interface ITransactionRoutings
    {
        public Task<TransactionRoutings> AddTransactionRoutings(TransactionRoutings tr);

        public IEnumerable<TransactionRoutings> ListTransactionRoutings();
        public Task<IEnumerable<TransactionRoutings>> Edit(TransactionRoutings tr);

        public Task<TransactionRoutings> GetTransactionRoutingsID(int Id);
        public void DeleteTransactionRoutings(int Id);


    }
}

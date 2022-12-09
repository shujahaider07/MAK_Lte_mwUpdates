using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository
{
    public interface ITransactionalLogs 
    {

        public Task<TransactionalLogs> AddTransactionalLogs(TransactionalLogs tl);

        public IEnumerable<TransactionalLogs> ListTransactionalLogs();
        public Task<IEnumerable<TransactionalLogs>> Edit(TransactionalLogs tl);

        public Task<TransactionalLogs> GetTransactionalLogsByID(int Id);
        public void DeleteTransactionalLogs(int Id);

    }
}

using BusinessLogic;

namespace repository
{
    public interface ITransactionCodeMapping
    {

        public Task<TransactionCodeMapping> AddransactionCodeMapping(TransactionCodeMapping tcm);

        public IEnumerable<TransactionCodeMapping> ListTransactionCodeMapping();
        public Task<IEnumerable<TransactionCodeMapping>> Edit(TransactionCodeMapping tcm);

        public Task<TransactionCodeMapping> GetTransactionCodeMappingID(int Id);
        public void DeleteTransactionCodes(int Id);


    }
}

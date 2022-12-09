using BusinessLogic;

namespace repository
{
    public interface IResponseCodeMapping
    {
        public Task<ResponseCodeMapping> AddResponseCodeMapping(ResponseCodeMapping rcm);

        public IEnumerable<ResponseCodeMapping> ListResponseCodeMapping();
        public Task<IEnumerable<ResponseCodeMapping>> Edit(ResponseCodeMapping rcm);

        public Task<ResponseCodeMapping> GetResponseCodeMappingByID(int Id);
        public void DeleteResponseCodeMapping(int Id);




    }
}

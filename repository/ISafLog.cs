using BusinessLogic;

namespace repository
{
    public interface ISafLog
    {


        public Task<SafLog> AddSafLog(SafLog s);
        public IEnumerable<SafLog> ListSafLog();
        public Task<IEnumerable<SafLog>> Edit(SafLog s);

        public Task<SafLog> GetSafLogByID(int Id);
        public void DeleteSafLog(int Id);
    }
}

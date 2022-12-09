using BusinessLogic;

namespace repository
{
    public interface ISafConfiguration
    {

        public Task<SafConfiguration> AddSafConfiguration(SafConfiguration s);

        public IEnumerable<SafConfiguration> ListSafConfiguration();
        public Task<IEnumerable<SafConfiguration>> Edit(SafConfiguration s);

        public Task<SafConfiguration> GetSafConfigurationsByID(int Id);
        public void DeleteSafConfiguration(int Id);




    }
}

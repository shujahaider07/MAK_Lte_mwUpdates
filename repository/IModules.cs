using BusinessLogic;

namespace repository
{
    public interface IModules
    {
        public Task<Modules> AddModules(Modules m);

        public Task<IEnumerable<Modules>> ListModules();
        public Task<IEnumerable<Modules>> Edit(Modules m);

        public Task<Modules> GetModulesByID(int Id);
        public void DeleteModules(int Id);

    }
}

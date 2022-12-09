using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository
{
    public interface IApplicationPages
    {

        public Task<ApplicationPages> AddApplicationPages(ApplicationPages p);

        public Task<IEnumerable<ApplicationPages>> ListApplicationPages();
        public Task<IEnumerable<ApplicationPages>> Edit(ApplicationPages p);

        public Task<ApplicationPages> GetApplicationPagesByID(int Id);
        public void DeleteApplicationPages(int Id);

    }
}

using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository
{
    public interface IAdaptor
    {

        public Task<Adaptor> Addadaptor(Adaptor a);

        public Task<IEnumerable<Adaptor>> ListAdaptor();
        public Task<IEnumerable<Adaptor>> Edit(Adaptor a);

        public Task<Adaptor> GetAdaptorByID(int Id);
        public void DeleteAdaptor(int Id);

    }
}

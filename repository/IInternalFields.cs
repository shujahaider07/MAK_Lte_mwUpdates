using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository
{
    public interface IInternalFields
    {

        public Task<InternalFields> AddInternalFields(InternalFields i);
        public Task<IEnumerable<InternalFields>> ListInternalFields();
        public Task<IEnumerable<InternalFields>> Edit(InternalFields i);

        public Task<InternalFields> GetInternalFieldsByID(int Id);
        public void DeleteInternalFields(int Id);


    }
}

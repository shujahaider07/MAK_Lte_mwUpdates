using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository
{
    public interface IAdaptorType
    {

        public Task<AdaptorType> AddadaptorType(AdaptorType a);

        public Task<IEnumerable<AdaptorType>> ListAdaptorType();
        public Task<IEnumerable<AdaptorType>> Edit(AdaptorType a);

        public Task<AdaptorType> GetAdaptorTypeByID(int Id);
        public void DeleteAdaptorType(int Id);




    }
}

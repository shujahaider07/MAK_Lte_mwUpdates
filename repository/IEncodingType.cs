using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository
{
    public interface IEncodingType
    {

        public Task<EncodingType> AddEncodingType(EncodingType e);
        public Task<IEnumerable<EncodingType>> ListEncodingType();
        public Task<IEnumerable<EncodingType>> Edit(EncodingType e);

        public Task<EncodingType> GetEncodingTypeByID(int Id);
        public void DeleteEncodingType(int Id);

    }
}

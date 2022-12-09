using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository
{
    public interface IResponseCodes
    {

        public Task<ResponseCodes> AddResponseCodes(ResponseCodes r);

        public Task<IEnumerable<ResponseCodes>> ListResponseCodes();
        public Task<IEnumerable<ResponseCodes>> Edit(ResponseCodes r);

        public Task<ResponseCodes> GetAddResponseCodesByID(int Id);
        public void DeleteResponseCodes(int Id);

    }
}

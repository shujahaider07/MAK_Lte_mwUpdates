using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository
{
    public interface IResponeCodes
    {
        public Task<ResponeCodes> AddResponeCodes(ResponeCodes r);

        public  Task<IEnumerable<ResponeCodes>> ListResponeCodes();
        public Task<IEnumerable<ResponeCodes>> Edit(ResponeCodes r);

        public Task<ResponeCodes> GetResponeCodesByID(int Id);
        public void DeleteResponeCodes(int Id);


    }
}

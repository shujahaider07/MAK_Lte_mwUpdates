using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository
{
    public interface Iusers
    {

        public Task<Users> AddUsers(Users u);
        public Task<IEnumerable<Users>> ListUsers();
        public Task<IEnumerable<Users>> Edit(Users u);

        public Task<Users> GetUsersByID(int Id);
        public void DeleteUsers(int Id);


    }
}

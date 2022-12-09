using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository
{
    public interface IUserRoles
    {
        public Task<UserRoles> AddUSerRoles(UserRoles a);

        public Task<IEnumerable<UserRoles>> ListUserRoles();
        public Task<IEnumerable<UserRoles>> Edit(UserRoles a);

        public Task<UserRoles> GetUserRolesByID(int Id);
        public void DeletUserRoles(int Id);

    }
}

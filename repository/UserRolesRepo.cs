using BusinessLogic;
using Microsoft.EntityFrameworkCore;

namespace repository
{
    public class UserRolesRepo : IUserRoles
    {

        private readonly ApplicationDbContext db;

        public UserRolesRepo(ApplicationDbContext db)
        {

            this.db = db;
        }

        public async Task<UserRoles> AddUSerRoles(UserRoles a)
        {

            try
            {

                UserRoles userRoles = new UserRoles();

                userRoles.Name = a.Name;
                userRoles.View = a.View;
                userRoles.Edit = a.Edit;
                userRoles.delete = a.delete;
                userRoles.CreatedOn = DateTime.Now;
                userRoles.CreatedBy = a.CreatedBy;
                userRoles.UpdatedBy = a.UpdatedBy;
                userRoles.UpdatedOn = DateTime.Now;

                var add = db.UserRoles.AddAsync(userRoles);
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {

            }

            return a;

        }

        public void DeletUserRoles(int Id)
        {
            UserRoles users = db.UserRoles.Find(Id);
            db.UserRoles.Remove(users);
            db.SaveChanges();
        }

        public Task<IEnumerable<UserRoles>> Edit(UserRoles a)
        {
            var Data = db.UserRoles.Where(x => x.Id == a.Id).FirstOrDefault();
            if (Data != null)
            {
                Data.Name = a.Name;
                Data.View = a.View;
                Data.Edit = a.Edit;
                Data.delete = a.delete;
                Data.CreatedOn = DateTime.Now;
                Data.CreatedBy = a.CreatedBy;
                Data.UpdatedBy = a.UpdatedBy;
                Data.UpdatedOn = DateTime.Now;

                db.Entry(Data).State = EntityState.Modified;
                db.SaveChanges();
            }

            return null;
        }

        public async Task<UserRoles> GetUserRolesByID(int Id)
        {
            return await db.UserRoles.FindAsync(Id);
        }

        public async Task<IEnumerable<UserRoles>> ListUserRoles()
        {
            return await db.UserRoles.ToListAsync();
        }
    }
}

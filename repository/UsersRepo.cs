using BusinessLogic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository
{
    public class UsersRepo : Iusers
    {

        private readonly ApplicationDbContext db;
        public UsersRepo(ApplicationDbContext db)
        {
            this.db = db;
        }



        public async Task<Users> AddUsers(Users u)
        {
            try
            {

                Users users = new Users();

                users.Name = u.Name;
                users.Email = u.Email;
                users.Address = u.Name;
                users.Phone = u.Phone;
                users.AssociationId = u.AssociationId;
                users.IsActive = u.IsActive;
                users.CreatedBy = u.CreatedBy;
                users.CreatedOn = DateTime.Now;
                users.UpdatedBy = u.UpdatedBy;
                users.UpdateOn = DateTime.Now;
                users.RoleId = u.RoleId;
           
              

                var add = db.users.AddAsync(users);
                await db.SaveChangesAsync();


            }

            catch (Exception)
            {

            }

            return u;

        }

        public void DeleteUsers(int Id)
        {
            Users aso = db.users.Find(Id);
            db.users.Remove(aso);
            db.SaveChanges();
        }

        public Task<IEnumerable<Users>> Edit(Users u)
        {

            var users = db.users.Where(x => x.Id == u.Id).FirstOrDefault();
            if (users != null)
            {

                users.Name = u.Name;
                users.Email = u.Email;
                users.Address = u.Name;
                users.Phone = u.Phone;
                users.AssociationId = u.AssociationId;
                users.IsActive = u.IsActive;
                users.CreatedBy = u.CreatedBy;
                users.CreatedOn = DateTime.Now;
                users.UpdatedBy = u.UpdatedBy;
                users.UpdateOn = DateTime.Now;
                users.RoleId = u.RoleId;
                db.Entry(users).State = EntityState.Modified;
                db.SaveChanges();
            }

            { return null; }
        }

        public async Task<Users> GetUsersByID(int Id)
        {
            return await db.users.FindAsync(Id);
        }

        public async Task<IEnumerable<Users>> ListUsers()
        {
            return await db.users.ToListAsync();
        }
    }
}

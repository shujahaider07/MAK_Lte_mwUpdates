using BusinessLogic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository
{
    public class ApplicationPagesRepo : IApplicationPages
    {


        private readonly ApplicationDbContext db;

        public ApplicationPagesRepo(ApplicationDbContext db)
        {

            this.db = db;
        }

        public async Task<ApplicationPages> AddApplicationPages(ApplicationPages p)
        {

            try
            {

                ApplicationPages applicationPages = new ApplicationPages();

                applicationPages.PageName = p.PageName;
                applicationPages.PageUrl = p.PageUrl;
                applicationPages.PageImagePath = p.PageImagePath;
             


                var add = db.ApplicationPages.AddAsync(applicationPages);
                await db.SaveChangesAsync();


            }


            catch (Exception)
            {

            }

            return p;

        }

        public void DeleteApplicationPages(int Id)
        {
            ApplicationPages ada = db.ApplicationPages.Find(Id);
            db.ApplicationPages.Remove(ada);
            db.SaveChanges();
        }

        public Task<IEnumerable<ApplicationPages>> Edit(ApplicationPages p)
        {
            var applicationPages = db.ApplicationPages.Where(x => x.Id == p.Id).FirstOrDefault();
            if (applicationPages != null)
            {
                applicationPages.PageName = p.PageName;
                applicationPages.PageUrl = p.PageUrl;
                applicationPages.PageImagePath = p.PageImagePath;



                db.Entry(applicationPages).State = EntityState.Modified;
                db.SaveChanges();
            }

            return null;
        }

        public async Task<ApplicationPages> GetApplicationPagesByID(int Id)
        {
            return await db.ApplicationPages.FindAsync(Id);
        }

        public async Task<IEnumerable<ApplicationPages>> ListApplicationPages()
        {
            return await db.ApplicationPages.ToListAsync();
        }
    }
}

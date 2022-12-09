using BusinessLogic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository
{
    public class PageActionRepo : IPageAction
    {
        private readonly ApplicationDbContext db;
        public PageActionRepo(ApplicationDbContext db)
        {
            this.db = db;
        }



        public async Task<PageAction> AddPageAction(PageAction p)
        {
            try
            {

                PageAction pageAction = new PageAction();


                pageAction.Description = p.Description ;
           

                var add = db.pageAction.AddAsync(pageAction);
                await db.SaveChangesAsync();


            }

            catch (Exception)
            {

            }

            return p;


        }

        public void DeletePageAction(int Id)
        {
            PageAction ada = db.pageAction.Find(Id);
            db.pageAction.Remove(ada);
            db.SaveChanges();
        }

        public Task<IEnumerable<PageAction>> Edit(PageAction p)
        {
            var pageAction = db.pageAction.Where(x => x.Id == p.Id).FirstOrDefault();
            if (pageAction != null)
            {

                pageAction.Description = p.Description;

                db.Entry(pageAction).State = EntityState.Modified;
                db.SaveChanges();
            }

            return null;
        }

        public async Task<PageAction> GetPageActionByID(int Id)
        {
            return await db.pageAction.FindAsync(Id);
        }

        public async Task<IEnumerable<PageAction>> ListPageAction()
        {
            return await db.pageAction.ToListAsync();
        }
    }
}

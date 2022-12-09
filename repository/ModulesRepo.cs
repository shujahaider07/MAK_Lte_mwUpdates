using BusinessLogic;
using Microsoft.EntityFrameworkCore;

namespace repository
{
    public class ModulesRepo : IModules
    {

        private readonly ApplicationDbContext db;
        public ModulesRepo(ApplicationDbContext db)
        {
            this.db = db;
        }


        public async Task<Modules> AddModules(Modules m)
        {

            try
            {

                Modules modules = new Modules();

                modules.Type = m.Type;
                modules.InQueueName = m.InQueueName;
                modules.OutQueue = m.OutQueue;
                modules.LogFilePath = m.LogFilePath;
                modules.LogFilePattern = m.LogFilePattern;
                modules.LogFileSize = m.LogFileSize;
                modules.CreatedOn = DateTime.Now;
                modules.CreatedBy = m.CreatedBy;


                var add = db.Modules.AddAsync(modules);
                await db.SaveChangesAsync();


            }

            catch (Exception)
            {

            }

            return m;


        }

        public void DeleteModules(int Id)
        {
            Modules aso = db.Modules.Find(Id);
            db.Modules.Remove(aso);
            db.SaveChanges();


        }

        public Task<IEnumerable<Modules>> Edit(Modules m)
        {
            var modules = db.Modules.Where(x => x.Id == m.Id).FirstOrDefault();
            if (modules != null)
            {
                modules.Type = m.Type;
                modules.InQueueName = m.InQueueName;
                modules.OutQueue = m.OutQueue;
                modules.LogFilePath = m.LogFilePath;
                modules.LogFilePattern = m.LogFilePattern;
                modules.LogFileSize = m.LogFileSize;
                modules.CreatedOn = DateTime.Now;
                modules.CreatedBy = m.CreatedBy;


                db.Entry(modules).State = EntityState.Modified;
                db.SaveChanges();
            }

            { return null; }
        }

        public async Task<Modules> GetModulesByID(int Id)
        {
            return await db.Modules.FindAsync(Id);
        }

        public async Task<IEnumerable<Modules>> ListModules()
        {
            return await db.Modules.ToListAsync();

        }
    }
}

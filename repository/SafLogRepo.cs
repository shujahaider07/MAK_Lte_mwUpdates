using BusinessLogic;
using Microsoft.EntityFrameworkCore;

namespace repository
{
    public class SafLogRepo : ISafLog
    {

        private readonly ApplicationDbContext db;

        public SafLogRepo(ApplicationDbContext db)
        {

            this.db = db;
        }



        public async Task<SafLog> AddSafLog(SafLog s)
        {
            try
            {

                SafLog safLog = new SafLog();

                safLog.ParticipantId = s.ParticipantId;
                safLog.Message = s.Message;
                safLog.Retries = s.Retries;
                safLog.CreatedOn = DateTime.Now;
                safLog.CreatedBy = s.CreatedBy;
                safLog.UpdatedBy = s.UpdatedBy;
                safLog.UpdateOn = DateTime.Now;



                var add = db.SafLog.AddAsync(safLog);
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {

            }

            return s;
        }

        public void DeleteSafLog(int Id)
        {
            SafLog safLog = db.SafLog.Find(Id);
            db.Remove(safLog);
            db.SaveChanges();
        }

        public async Task<IEnumerable<SafLog>> Edit(SafLog s)
        {
            var data =  db.SafLog.Where(x => x.Id == s.Id).FirstOrDefault();
            if (data != null)
            {
                data.ParticipantId = s.ParticipantId;
                data.Message = s.Message;
                data.Retries = s.Retries;
                data.CreatedBy = s.CreatedBy;
                data.CreatedOn = DateTime.Now;
                data.UpdatedBy = s.UpdatedBy;
                data.UpdateOn = DateTime.Now;

                db.Entry(s).State=EntityState.Modified;
                //db.SaveChanges();

            }

            return null;
        }

        public async Task<SafLog> GetSafLogByID(int Id)
        {
            return await db.SafLog.FindAsync(Id);
        }

        public IEnumerable<SafLog> ListSafLog()
        {
            return db.SafLog.ToList();
        }
    }
}

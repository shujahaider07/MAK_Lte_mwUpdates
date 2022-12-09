using BusinessLogic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository
{
    public class SafConfigurationRepo : ISafConfiguration
    {

        private readonly ApplicationDbContext db;
        public SafConfigurationRepo(ApplicationDbContext db)
        {
            this.db = db;
        }




        public async Task<SafConfiguration> AddSafConfiguration(SafConfiguration s)
        {

            try
            {

                SafConfiguration SafConfiguration = new SafConfiguration();

                SafConfiguration.ParticipantId = s.ParticipantId;
                SafConfiguration.RetryCount = s.RetryCount;
                SafConfiguration.MaxRetires = s.MaxRetires;
                SafConfiguration.CreatedOn = DateTime.Now;
                SafConfiguration.UpdateOn = DateTime.Now;
                SafConfiguration.CreatedBy = s.CreatedBy;
                SafConfiguration.UpdateBy = s.UpdateBy;


                var add = db.SafConfiguration.AddAsync(SafConfiguration);
                await db.SaveChangesAsync();


            }


            catch (Exception)
            {

            }

            return s;
        }

        public void DeleteSafConfiguration(int Id)
        {
            SafConfiguration parti = db.SafConfiguration.Find(Id);
            db.SafConfiguration.Remove(parti);
            db.SaveChanges();
        }

        public Task<IEnumerable<SafConfiguration>> Edit(SafConfiguration s)
        {
            var Data = db.SafConfiguration.Where(x => x.Id == s.Id).FirstOrDefault();
            if (Data != null)
            {
                Data.ParticipantId = s.ParticipantId;
                Data.RetryCount = s.RetryCount;
                Data.MaxRetires = s.MaxRetires;
                Data.CreatedOn = DateTime.Now;
                Data.UpdateOn = DateTime.Now;
                Data.CreatedBy = s.CreatedBy;
                Data.UpdateBy = s.UpdateBy;

                db.Entry(Data).State = EntityState.Modified;

            }

            db.SaveChanges();
            //{ return null; }
            return null;
        }

        public async Task<SafConfiguration> GetSafConfigurationsByID(int Id)
        {
            return await db.SafConfiguration.FindAsync(Id);
        }

        public IEnumerable<SafConfiguration> ListSafConfiguration()
        {
            return db.SafConfiguration.ToList();
        }
    }
}

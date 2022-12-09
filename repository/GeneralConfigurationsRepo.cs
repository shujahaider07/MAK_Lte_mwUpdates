using BusinessLogic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository
{
    public class GeneralConfigurationsRepo : IGeneralConfigurations
    {

        private readonly ApplicationDbContext db;
        public GeneralConfigurationsRepo(ApplicationDbContext db)
        {
            this.db = db;
        }


        public async Task<GeneralConfigurations> AddGeneralConfigurations(GeneralConfigurations g)
        {
            try
            {

                GeneralConfigurations generalConfigurations = new GeneralConfigurations();

                
                generalConfigurations.Description = g.Description;
                generalConfigurations.Reserved1 = g.Reserved1;
                generalConfigurations.Reserved2 = g.Reserved2;
                generalConfigurations.Reserved3 = g.Reserved3;
                generalConfigurations.Reserved4 = g.Reserved4;
                generalConfigurations.Reserved5 = g.Reserved5;
                generalConfigurations.Reserved6 = g.Reserved6;
                generalConfigurations.Reserved7 = g.Reserved7;
                generalConfigurations.Reserved8 = g.Reserved8;
                generalConfigurations.Reserved9 = g.Reserved9;
                generalConfigurations.Reserved10 = g.Reserved10;


                var add = db.GeneralConfigurations.AddAsync(generalConfigurations);
                await db.SaveChangesAsync();


            }

            catch (Exception)
            {

            }

            return g;
        }

        public void DeleteGeneralConfigurations(int Id)
        {
            GeneralConfigurations aso = db.GeneralConfigurations.Find(Id);
            db.GeneralConfigurations.Remove(aso);
            db.SaveChanges();
        }

        public async Task<IEnumerable<GeneralConfigurations>> Edit(GeneralConfigurations g)
        {
            var generalConfigurations = db.GeneralConfigurations.Where(x => x.Id == g.Id).FirstOrDefault();
            if (generalConfigurations != null)
            {
                generalConfigurations.Description = g.Description;
                generalConfigurations.Reserved1 = g.Reserved1;
                generalConfigurations.Reserved2 = g.Reserved2;
                generalConfigurations.Reserved3 = g.Reserved3;
                generalConfigurations.Reserved4 = g.Reserved4;
                generalConfigurations.Reserved5 = g.Reserved5;
                generalConfigurations.Reserved6 = g.Reserved6;
                generalConfigurations.Reserved7 = g.Reserved7;
                generalConfigurations.Reserved8 = g.Reserved8;
                generalConfigurations.Reserved9 = g.Reserved9;
                generalConfigurations.Reserved10 = g.Reserved10;



                db.Entry(generalConfigurations).State = EntityState.Modified;
                db.SaveChanges();
            }

            { return null; }
        }

        public async Task<GeneralConfigurations> GetGeneralConfigurationsByID(int Id)
        {
            return await db.GeneralConfigurations.FindAsync(Id);
        }

        public async Task<IEnumerable<GeneralConfigurations>> ListGeneralConfigurations()
        {
            return await db.GeneralConfigurations.ToListAsync();
        }
    }
}

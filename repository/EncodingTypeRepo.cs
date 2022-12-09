using BusinessLogic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository
{
    public class EncodingTypeRepo : IEncodingType
    {

        private readonly ApplicationDbContext db;
        public EncodingTypeRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<EncodingType> AddEncodingType(EncodingType e)
        {
            try
            {

                EncodingType encodingType = new EncodingType();

               // encodingType.Id = e.Id;
                encodingType.Description = e.Description;
               
                var add = db.EncodingType.AddAsync(encodingType);
                await db.SaveChangesAsync();


            }

            catch (Exception)
            {

            }

            return e;

        }

        public void DeleteEncodingType(int Id)
        {
            EncodingType aso = db.EncodingType.Find(Id);
            db.EncodingType.Remove(aso);
            db.SaveChanges();
        }

        public Task<IEnumerable<EncodingType>> Edit(EncodingType e)
        {
            var Data = db.EncodingType.Where(x => x.Id == e.Id).FirstOrDefault();
            if (Data != null)
            {
                Data.Description = e.Description;
                
               

                db.Entry(Data).State = EntityState.Modified;
                db.SaveChanges();
            }

            { return null; }
        }

        public async Task<EncodingType> GetEncodingTypeByID(int Id)
        {
            return await db.EncodingType.FindAsync(Id);
        }

        public async Task<IEnumerable<EncodingType>> ListEncodingType()
        {
            return await db.EncodingType.ToListAsync();
        }
    }
}

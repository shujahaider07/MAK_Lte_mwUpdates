using BusinessLogic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository
{
    public class ResponseCodeMappingRepo : IResponseCodeMapping
    {
        private readonly ApplicationDbContext db;

        public ResponseCodeMappingRepo(ApplicationDbContext db)
        {

            this.db = db;
        }



        public async Task<ResponseCodeMapping> AddResponseCodeMapping(ResponseCodeMapping rcm)
        {
            try
            {

                ResponseCodeMapping respone = new ResponseCodeMapping();

                respone.ExternalResponseCode = rcm.ExternalResponseCode;
                respone.InternalResponseCode = rcm.InternalResponseCode;
                respone.CreatedBy = rcm.CreatedBy;
                respone.UpdatedBy = rcm.UpdatedBy;
                respone.UpdatedOn = DateTime.Now;
                respone.CreatedOn = DateTime.Now;


                var add = db.ResponseCodeMapping.AddAsync(respone);
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {

            }

            return rcm;
        }

        public void DeleteResponseCodeMapping(int Id)
        {
            ResponseCodeMapping users = db.ResponseCodeMapping.Find(Id);
            db.ResponseCodeMapping.Remove(users);
            db.SaveChanges();
        }

        public Task<IEnumerable<ResponseCodeMapping>> Edit(ResponseCodeMapping rcm)
        {

            var Data = db.ResponseCodeMapping.Where(x => x.Id == rcm.Id).FirstOrDefault();
            if (Data != null)
            {
                Data.ExternalResponseCode = rcm.ExternalResponseCode;
                Data.InternalResponseCode = rcm.InternalResponseCode;
                Data.CreatedBy = rcm.CreatedBy;
                Data.UpdatedBy = rcm.UpdatedBy;
                Data.UpdatedOn = rcm.UpdatedOn;
                Data.CreatedOn = rcm.CreatedOn;



                db.Entry(Data).State = EntityState.Modified;
                db.SaveChanges();
            }

            return null;
        }

        public async Task<ResponseCodeMapping> GetResponseCodeMappingByID(int Id)
        {
            return await db.ResponseCodeMapping.FindAsync(Id);
        }

        public async Task <IEnumerable<ResponseCodeMapping>> ListResponseCodeMapping()
        {
            return db.ResponseCodeMapping.ToList();
        }
    }
}

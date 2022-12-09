using BusinessLogic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository
{
    public class ResponseCodesRepo : IResponseCodes
    {

        private readonly ApplicationDbContext db;
        public ResponseCodesRepo(ApplicationDbContext db)
        {
            this.db = db;   

        }




        public async Task<ResponseCodes> AddResponseCodes(ResponseCodes r)
        {
            try
            {

                ResponseCodes responseCodes = new ResponseCodes();


                responseCodes.Description = r.Description;
                responseCodes.CreatedOn = DateTime.Now;
                responseCodes.CreatedBy = r.CreatedBy;
                responseCodes.UpdatedBy = r.UpdatedBy;
                responseCodes.UpdateOn = DateTime.Now; 


                var add = db.ResponseCodes.AddAsync(responseCodes);
                await db.SaveChangesAsync();


            }

            catch (Exception)
            {

            }

            return r;
        }

        public void DeleteResponseCodes(int Id)
        {
            ResponseCodes ada = db.ResponseCodes.Find(Id);
            db.ResponseCodes.Remove(ada);
            db.SaveChanges();
        }

        public Task<IEnumerable<ResponseCodes>> Edit(ResponseCodes r)
        {
            var responseCodes = db.ResponseCodes.Where(x => x.Id == r.Id).FirstOrDefault();
            if (responseCodes != null)
            {

                responseCodes.Description = r.Description;
                responseCodes.CreatedOn = DateTime.Now;
                responseCodes.CreatedBy = r.CreatedBy;
                responseCodes.UpdatedBy = r.UpdatedBy;
                responseCodes.UpdateOn = DateTime.Now;

                db.Entry(responseCodes).State = EntityState.Modified;
                db.SaveChanges();
            }

            return null;
        }

        public async Task<ResponseCodes> GetAddResponseCodesByID(int Id)
        {
            return await db.ResponseCodes.FindAsync(Id);
        }

        public async Task<IEnumerable<ResponseCodes>> ListResponseCodes()
        {
            return await db.ResponseCodes.ToListAsync();
        }
    }
}

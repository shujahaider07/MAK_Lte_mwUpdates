using BusinessLogic;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Net;

namespace repository
{
    public class Associationrepo : IAssociation
    {

        private readonly ApplicationDbContext db;
        public Associationrepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<Association> Addassociation(Association a)
        {
            try
            {

                Association association = new Association();

                association.Name = a.Name;
                association.Email = a.Email;
                association.CC = a.CC;
                association.Address = a.Address;
                association.UpdatedBy = a.UpdatedBy;
                association.CreatedBy = a.CreatedBy;
                association.ContactInfo = a.ContactInfo;
                association.CreatedOn = DateTime.Now;
                association.UpdatedOn = DateTime.Now;

                var add = db.association.AddAsync(association);
                await db.SaveChangesAsync();

                    
            }

            catch (Exception)
            {

            }

            return a;



        }

        public void DeleteAssociation(int Id)
        {
            Association aso = db.association.Find(Id);
            db.association.Remove(aso);
            db.SaveChanges();
           
           
        }

        public async Task<IEnumerable<Association>> Edit(Association a)
        {
            var Data = db.association.Where(x => x.Id == a.Id).FirstOrDefault();
            if (Data != null)
            {
                Data.Name = a.Name;
                Data.Address = a.Address;
                Data.CC = a.CC;
                Data.Email = a.Email;
                Data.CreatedBy = a.CreatedBy;
                Data.ContactInfo = a.ContactInfo;
                Data.UpdatedBy = a.UpdatedBy;
                Data.UpdatedOn = DateTime.Now;
                Data.CreatedOn = DateTime.Now;

                db.Entry(Data).State = EntityState.Modified;
                db.SaveChanges();
            }

            { return null; }

        }

        public async Task<Association> GetAssociationByID(int Id)
        {
          
            return await db.association.FindAsync(Id);
        }

        public async Task<IEnumerable<Association>> Listassociation()
        {
            return await db.association.ToListAsync();
            
        }

        
      



    }
}
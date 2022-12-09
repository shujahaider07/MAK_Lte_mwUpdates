using BusinessLogic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository
{
    public class MessageFormatconfigurationRepo : IMessageFormatconfiguration
    {


        private readonly ApplicationDbContext db;
        public MessageFormatconfigurationRepo(ApplicationDbContext db)
        {
            this.db = db;
        }




        public async Task<MessageFormatconfiguration> AddMessageFormatconfiguration(MessageFormatconfiguration m)
        {

            try
            {

                MessageFormatconfiguration messageFormat = new MessageFormatconfiguration();


                messageFormat.AssociationId = m.AssociationId;
                messageFormat.PaticipantId  = m.PaticipantId;
                messageFormat.FieldName = m.FieldName;
                messageFormat.InternalFieldId = m.InternalFieldId;
                messageFormat.EncodingTypeId = m.EncodingTypeId;
                messageFormat.Alias = m.Alias;
                messageFormat.PaticipantTypeId = m.PaticipantTypeId;
                messageFormat.ParentTagId = m.ParentTagId;
                messageFormat.Identifier = m.Identifier;
                messageFormat.Mask = m.Mask;
                messageFormat.Encrypt = m.Encrypt;
                messageFormat.BitmappedId = m.BitmappedId;
                messageFormat.BitNumber = m.BitNumber;
                messageFormat.StartIndex = m.StartIndex;
                messageFormat.EndIndex = m.EndIndex;
                messageFormat.Delimiter = m.Delimiter;
                messageFormat.MetaLengthTypeId = m.MetaLengthTypeId;
                messageFormat.MetaLength = m.MetaLength;
                messageFormat.CreatedOn = DateTime.Now;
                messageFormat.CreatedBy = m.CreatedBy;
                messageFormat.UpdatedOn = DateTime.Now;
                messageFormat.UpdatedBy = m.UpdatedBy;




                var add = db.MessageFormatconfiguration.AddAsync(messageFormat);
                await db.SaveChangesAsync();


            }

            catch (Exception)
            {

            }

            return m;
        }

        public void DeleteMessageFormatconfiguration(int Id)
        {
            MessageFormatconfiguration aso = db.MessageFormatconfiguration.Find(Id);
            db.MessageFormatconfiguration.Remove(aso);
            db.SaveChanges();
        }

        public Task<IEnumerable<MessageFormatconfiguration>> Edit(MessageFormatconfiguration m)
        {
            var messageFormat = db.MessageFormatconfiguration.Where(x => x.Id == m.Id).FirstOrDefault();
            if (messageFormat != null)
            {

                messageFormat.AssociationId = m.AssociationId;
                messageFormat.PaticipantId = m.PaticipantId;
                messageFormat.FieldName = m.FieldName;
                messageFormat.InternalFieldId = m.InternalFieldId;
                messageFormat.EncodingTypeId = m.EncodingTypeId;
                messageFormat.Alias = m.Alias;
                messageFormat.PaticipantTypeId = m.PaticipantTypeId;
                messageFormat.ParentTagId = m.ParentTagId;
                messageFormat.Identifier = m.Identifier;
                messageFormat.Mask = m.Mask;
                messageFormat.Encrypt = m.Encrypt;
                messageFormat.BitmappedId = m.BitmappedId;
                messageFormat.BitNumber = m.BitNumber;
                messageFormat.StartIndex = m.StartIndex;
                messageFormat.EndIndex = m.EndIndex;
                messageFormat.Delimiter = m.Delimiter;
                messageFormat.MetaLengthTypeId = m.MetaLengthTypeId;
                messageFormat.MetaLength = m.MetaLength;
                messageFormat.CreatedOn = DateTime.Now;
                messageFormat.CreatedBy = m.CreatedBy;
                messageFormat.UpdatedOn = DateTime.Now;
                messageFormat.UpdatedBy = m.UpdatedBy;




                db.Entry(messageFormat).State = EntityState.Modified;
                db.SaveChanges();
            }

            { return null; }
        }

        public async Task<MessageFormatconfiguration> GetMessageFormatconfigurationByID(int Id)
        {
            return await db.MessageFormatconfiguration.FindAsync(Id);
        }

        public async Task<IEnumerable<MessageFormatconfiguration>> ListMessageFormatconfiguration()
        {
            return await db.MessageFormatconfiguration.ToListAsync();
        }
    }
}

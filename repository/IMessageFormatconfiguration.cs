using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository
{
    public interface IMessageFormatconfiguration
    {


        public Task<MessageFormatconfiguration> AddMessageFormatconfiguration(MessageFormatconfiguration m);

        public Task<IEnumerable<MessageFormatconfiguration>> ListMessageFormatconfiguration();
        public Task<IEnumerable<MessageFormatconfiguration>> Edit(MessageFormatconfiguration m);

        public Task<MessageFormatconfiguration> GetMessageFormatconfigurationByID(int Id);
        public void DeleteMessageFormatconfiguration(int Id);
    }
}

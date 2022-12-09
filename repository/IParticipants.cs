using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository
{
    public interface IParticipants 
    {

        public Task<Participants> Addparticipant(Participants p);
        public Task<IEnumerable<Participants>> ListParticipants();
        public Task<IEnumerable<Participants>> Edit(Participants p);

        public Task<Participants> GetParticipantsByID(int Id);
        public void DeleteParticipants(int Id);
    }
}

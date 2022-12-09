using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository
{
    public interface IParticipantType
    {

        public Task<ParticipantType> AddparticipantType(ParticipantType p);

        public IEnumerable<ParticipantType> ListParticipantType();
        public Task<IEnumerable<ParticipantType>> Edit(ParticipantType p);

        public Task<ParticipantType> GetParticipantTypeByID(int Id);
        public void DeleteParticipantType(int Id);
    }
}

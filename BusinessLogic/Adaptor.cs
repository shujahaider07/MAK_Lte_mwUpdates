using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Adaptor
    {
        [Key]
        public int Id { get; set; }
        public int ParticipantId { get; set; }
        public string AdaptorTypeId { get; set; }
        public string Address { get; set; }
        public char IsServer { get; set; }
        public string AllowedIp { get; set; }
        public int TimeoutInSec { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdateOn { get; set; }
        public int UpdatedBy { get; set; }
        public char IsActive { get; set; }
        public int AssociationId { get; set; }

        [NotMapped]
        public bool IsActiveNew { get; set; }


        
    }
}

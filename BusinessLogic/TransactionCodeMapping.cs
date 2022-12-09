using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class TransactionCodeMapping
    {
        [Key]
        public int Id { get; set; }
        public string InternalCode { get; set; }
        public string ExternalCode { get; set; }
        public int ParticipantId { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdateOn { get; set; }
        public int UpdatedBy { get; set; }
    }
}

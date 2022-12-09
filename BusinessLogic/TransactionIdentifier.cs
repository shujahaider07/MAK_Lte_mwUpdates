using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class TransactionIdentifier
    {
        [Key]
        public int Id { get; set; }
        public int ParticipantId { get; set; }
        public string KeyField1 { get; set; }
        public string KeyField2 { get; set; }
        public string KeyField3 { get; set; }
        public string KeyField4 { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int UpdatedBy { get; set; }
    }
}

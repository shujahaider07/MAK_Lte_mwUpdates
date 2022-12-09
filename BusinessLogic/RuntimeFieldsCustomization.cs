using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class RuntimeFieldsCustomization
    {
        [Key]
        public int Id { get; set; }
        public int ParticipantId { get; set; }
        public int TransactionIdentifierId { get; set; }
        public string Condition { get; set; }
        public string Value { get; set; }
        public string Sequence { get; set; }
        public int InternalFieldId { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int UpdatedBy { get; set; }


    }
}

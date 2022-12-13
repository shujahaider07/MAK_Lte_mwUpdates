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
        [Required]
        public int ParticipantId { get; set; }
        [Required]
        public int TransactionIdentifierId { get; set; }
        [Required]
        public string Condition { get; set; }
        [Required]
        public string Value { get; set; }
        [Required]
        public string Sequence { get; set; }
        [Required]
        public int InternalFieldId { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public int CreatedBy { get; set; }
        [Required]
        public DateTime UpdatedOn { get; set; }
        [Required]
        public int UpdatedBy { get; set; }


    }
}

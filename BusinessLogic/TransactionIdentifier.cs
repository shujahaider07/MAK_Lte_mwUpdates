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
        [Required]
        public int ParticipantId { get; set; }
        [Required]
        public string KeyField1 { get; set; }
        [Required]
        public string KeyField2 { get; set; }
        [Required]
        public string KeyField3 { get; set; }
        [Required]
        public string KeyField4 { get; set; }
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

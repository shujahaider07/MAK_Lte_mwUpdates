using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class TransactionRoutings
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ParticipantId { get; set; }
        [Required]
        public string KeyFieldId1 { get; set; }
        [Required]
        public string KeyFIeld2 { get; set; }
        [Required]
        public string KeyFIeld3 { get; set; }
        [Required]
        public string KeyFIeld4 { get; set; }
        [Required]
        public string KeyFIeld5 { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public int CreatedBy { get; set; }
        [Required]
        public DateTime UpdateOn { get; set; }
        [Required]
        public int UpdatedBy { get; set; }


    }
}

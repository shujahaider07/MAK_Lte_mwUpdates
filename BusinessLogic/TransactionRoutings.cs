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
        public int ParticipantId { get; set; }
        public int KeyFieldId1 { get; set; }
        public int KeyFIeld2 { get; set; }
        public int KeyFIeld3 { get; set; }
        public int KeyFIeld4 { get; set; }
        public int KeyFIeld5 { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdateOn { get; set; }
        public string UpdatedBy { get; set; }


    }
}

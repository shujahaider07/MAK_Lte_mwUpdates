using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class TransactionRouter
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int TransactionRoutingId { get; set; }
        [Required]
        public string SendingQueue { get; set; }
        [Required]
        public string AdaptorAddress { get; set; }
        [Required] 
        public string KeyFIeldValue1 { get; set; }
        [Required] 
        public string KeyFIeldValue2 { get; set; }
        [Required]
        public string KeyFIeldValue3 { get; set; }
        [Required]
        public string KeyFIeldValue4 { get; set; }
        [Required]
        public string KeyFIeldValue5 { get; set; }
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

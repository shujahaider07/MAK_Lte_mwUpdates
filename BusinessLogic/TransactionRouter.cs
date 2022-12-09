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
        public int TransactionRoutingId { get; set; }
        public string SendingQueue { get; set; }
        public string AdaptorAddress { get; set; }
        public string KeyFIeldValue1 { get; set; }
        public string KeyFIeldValue2 { get; set; }
        public string KeyFIeldValue3 { get; set; }
        public string KeyFIeldValue4 { get; set; }
        public string KeyFIeldValue5 { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdateOn { get; set; }
        public int UpdatedBy { get; set; }

    }
}

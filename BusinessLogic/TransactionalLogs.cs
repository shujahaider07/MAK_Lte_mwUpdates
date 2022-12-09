using System.ComponentModel.DataAnnotations;

namespace BusinessLogic
{
    public class TransactionalLogs
    {
        [Key]
        public int Id { get; set; }
        public string MessageKey { get; set; }
        public string MessageBody { get; set; }
        public string Stan { get; set; }
        public string MessageType { get; set; }
        public string DateTime { get; set; }
        public string rrn { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdateOn { get; set; }
        public int UpdatedBy { get; set; }

    }
}

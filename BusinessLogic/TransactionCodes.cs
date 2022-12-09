using System.ComponentModel.DataAnnotations;

namespace BusinessLogic
{
    public class TransactionCodes
    {
        [Key]
        public int Id { get; set; }
        public string InternalCode { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdateOn { get; set; }
        public string UpdatedBy { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace BusinessLogic
{
    public class TransactionFields
    {
        [Key]
        public int Id { get; set; }
        public int TransactionIdentifierId { get; set; }
        public string IsOptional { get; set; }
        public string CompleteFieldName { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdateOn { get; set; }
        public int? UpdatedBy { get; set; }

    }
}

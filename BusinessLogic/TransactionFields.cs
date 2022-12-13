using System.ComponentModel.DataAnnotations;

namespace BusinessLogic
{
    public class TransactionFields
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int TransactionIdentifierId { get; set; }
        [Required]
        public string IsOptional { get; set; }
        [Required]
        public string CompleteFieldName { get; set; }
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

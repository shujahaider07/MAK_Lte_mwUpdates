using System.ComponentModel.DataAnnotations;

namespace BusinessLogic
{
    public class AdaptorType
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Type is req")]
        public int Type { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int CreatedBy { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public int AdaptorTypeId { get; set; }
    }
}

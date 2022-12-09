using System.ComponentModel.DataAnnotations;

namespace BusinessLogic
{
    public class Association
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string CC { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [Display(Name="Contact Information")]
        [StringLength(11, MinimumLength = 11)]
        [DataType(DataType.PhoneNumber)]
        public string ContactInfo { get; set; }
        [Required]
        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; }
        [Required]
        [Display(Name = "Created By")]
        public int CreatedBy { get; set; }
        [Required]
        [Display(Name = "Updated On")]
        public DateTime UpdatedOn { get; set; }
        [Required]
        [Display(Name = "Updated By")]
        public int UpdatedBy { get; set; }
  

    }
}

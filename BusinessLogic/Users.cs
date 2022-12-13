using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLogic
{
    public class Users
    {

        [Key]
        public int Id { get; set; }
        [Required]
        //[Required(ErrorMessageResourceName = "Username is Required")]
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }
     //   [Required(ErrorMessageResourceName = "Password Required")]
        //public string Password { get; set; }
        public string Address { get; set; }
        [Required]
        public Decimal Phone { get; set; }
        [Required]
        public int AssociationId { get; set; }
        [Required]
        public char IsActive { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public int CreatedBy { get; set; }
        [Required]
        public DateTime UpdateOn { get; set; }
        [Required]
        public int UpdatedBy { get; set; }
        [Required]
        public int RoleId { get; set; }
        [Required]

        [NotMapped]
        public bool IsActiveNew { get; set; }   
        //public string plainpassword { get; set; }
    }
}


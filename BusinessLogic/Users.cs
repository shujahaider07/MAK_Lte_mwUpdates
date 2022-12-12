using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLogic
{
    public class Users
    {

        [Key]
        public int Id { get; set; }

        //[Required(ErrorMessageResourceName = "Username is Required")]
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
     //   [Required(ErrorMessageResourceName = "Password Required")]
        //public string Password { get; set; }
        public string Address { get; set; }
        public Decimal Phone { get; set; }
        public int AssociationId { get; set; } 
        public char IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdateOn { get; set; }
        public int UpdatedBy { get; set; }
        public int RoleId { get; set; }

        [NotMapped]
        public bool IsActiveNew { get; set; }   
        //public string plainpassword { get; set; }
    }
}


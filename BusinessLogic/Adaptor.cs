using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLogic
{
    public class Adaptor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ParticipantId { get; set; }
        [Required]
        public string AdaptorTypeId { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public char IsServer { get; set; }
        [Required]
        public string AllowedIp { get; set; }
        [Required]
        public int TimeoutInSec { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public int CreatedBy { get; set; }
        [Required]
        public DateTime UpdateOn { get; set; }
        [Required]
        public int UpdatedBy { get; set; }
        [Required]
        public char IsActive { get; set; }
        [Required]
        public int AssociationId { get; set; }
        [Required]

        [NotMapped]
        public bool IsActiveNew { get; set; }



    }
}

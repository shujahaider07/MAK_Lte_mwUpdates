using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Participants
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="ParticipantId is required")]
        public int ParticipantTypeId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required(ErrorMessage ="Name is required")]
        public string Code { get; set; }
        [Required(ErrorMessage ="Bins Required")]
        public string Bins { get; set; }
        [Required(ErrorMessage ="Is Echo required")]
        //[Display(Name= "IsEcho Enable ")]
        public char IsEchoEnable  { get; set; }
        [Required]
        public int MsgEchoTimer { get; set; }
        [Required]
        public char IsActive { get; set; }
        [Required]
        public int AssociationId { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public int CreatedBy { get; set; }
        [Required]
        public DateTime UpdateOn { get; set; }
        [Required]
        public int UpdatedBy { get; set; }

        [NotMapped]
        public bool IsActiveNew { get; set; }

        //public List<Association> AssociationList { get; set; }

    }
}

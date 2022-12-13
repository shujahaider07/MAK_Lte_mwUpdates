using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class SafLog
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public int ParticipantId { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public int Retries { get; set; }
        [Required]
        public DateTime? CreatedOn { get; set; }
        [Required]
        public int CreatedBy { get; set; }
        [Required]
        public DateTime? UpdateOn { get; set; }
        [Required]
        public int UpdatedBy { get; set; }


    }
}

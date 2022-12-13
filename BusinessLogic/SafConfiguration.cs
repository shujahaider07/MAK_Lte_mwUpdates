using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class SafConfiguration
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ParticipantId { get; set; }
        [Required]
        public int RetryCount { get; set; }
        [Required]
        public int MaxRetires { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public int CreatedBy { get; set; }
        [Required]
        public DateTime UpdateOn { get; set; }
        [Required]
        public int UpdateBy { get; set; }

    }
}

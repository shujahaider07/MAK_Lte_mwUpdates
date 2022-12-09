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
        public int ParticipantId { get; set; }
        public int RetryCount { get; set; }
        public int MaxRetires { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdateOn { get; set; }
        public int UpdateBy { get; set; }

    }
}

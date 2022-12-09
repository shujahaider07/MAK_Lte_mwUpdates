using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Modules
    {
        [Key]
        public int Id { get; set; }
        public int Type { get; set; }
        public string InQueueName { get; set; } 
        public string OutQueue { get; set; }
        public string LogFilePath { get; set; }
        public string LogFilePattern { get; set; }
        public int LogFileSize { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }

    }
}

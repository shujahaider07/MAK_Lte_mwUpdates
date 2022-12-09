using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class ApplicationPages
    {
        [Key]
        public int Id { get; set; }
        public string PageName { get; set; }
        public string PageUrl { get; set; }
        public string PageImagePath { get; set; }


    }
}

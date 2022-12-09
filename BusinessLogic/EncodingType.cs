using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class EncodingType
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
    }
}

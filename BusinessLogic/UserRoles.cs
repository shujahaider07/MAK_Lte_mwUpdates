using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class UserRoles
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int View { get; set; }
        public int Edit { get; set; }
        public int delete { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int UpdatedBy { get; set; }


    }
}

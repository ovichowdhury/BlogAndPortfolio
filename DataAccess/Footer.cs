using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Footer
    {
        public int id { get; set; }
        [Required]
        public string copyright { get; set; }
        [Required]
        public string fbUrl { get; set; }
        [Required]
        public string gitUrl { get; set; }
    }
}

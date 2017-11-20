using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserDetails
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string occupation { get; set; }
        [Required]
        public string education { get; set; }
        [Required]
        public string skills { get; set; }
        [Required]
        public string contact { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        public string about { get; set; }
    }
}

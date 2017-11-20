using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Feedback
    {
        public int id { get; set; }

        [Required]
        public string visitorName { get; set; }

        [Required]
        public string visitorEmail { get; set; }

        [Required]
        public string message { get; set; }
        public DateTime date { get; set; }
    }
}

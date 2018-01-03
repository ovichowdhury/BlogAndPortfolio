using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWEntity
{
    public class Footer : Entity
    {
        [Required]
        public string copyright { get; set; }
        [Required]
        public string fbUrl { get; set; }
        [Required]
        public string gitUrl { get; set; }
    }
}

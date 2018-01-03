using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWEntity
{
    public class Project : Entity
    {
        [Required]
        public string projectName { get; set; }
        [Required]
        public string projectDetails { get; set; }
        [Required]
        public string sourceUrl { get; set; }
    }
}

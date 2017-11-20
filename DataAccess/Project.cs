using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Project
    {
        public int projectId { get; set; }
        [Required]
        public string projectName { get; set; }
        [Required]
        public string projectDetails { get; set; }
        [Required]
        public string sourceUrl { get; set; }
    }
}

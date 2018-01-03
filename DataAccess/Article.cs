using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Article
    {
        [Key]
        public int articleId { get; set; }
        [Required]
        public string subject { get; set; }
        [Required]
        public string content { get; set; }
        public string attachmentUrl { get; set; }
        public DateTime date { get; set; }
        public List<ArticleComment> comments { get; set; }
    }
}

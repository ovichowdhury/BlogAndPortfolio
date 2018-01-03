using PWEntity;
using PWRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWService
{
    public class ArticleService : Service<Article> , IArticleService
    {
        IArticleRepository repo = new ArticleRepository();
        public List<Article> Search(string keyword)
        {
            return this.repo.Search(keyword);
        }


        public void Update(Article article)
        {
            repo.Update(article);
        }
    }
}

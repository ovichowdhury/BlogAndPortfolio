using PWEntity;
using PWRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWService
{
    public class ArticleCommentService : Service<ArticleComment>, IArticleCommentService
    {
        IArticleCommentRepository repo = new ArticleCommentRepository();
        public List<ArticleComment> GetAll(int id)
        {
            return this.repo.GetAll(id);
        }


        public int Update(ArticleComment ac)
        {
            return repo.Update(ac);
        }
    }
}

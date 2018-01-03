using PWEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWRepository
{
    public class ArticleCommentRepository : Repository<ArticleComment>, IArticleCommentRepository
    {
        public List<ArticleComment> GetAll(int id)
        {
            return this.context.ArticleComments.Where(ac => ac.articleId == id).ToList();
        }

        public int Update(ArticleComment articleComment)
        {
            ArticleComment articleCommentToUpdate = this.context.ArticleComments.SingleOrDefault(ac => ac.id == articleComment.id);
            articleCommentToUpdate.comment = articleComment.comment;
            articleCommentToUpdate.commenterEmail = articleComment.commenterEmail;
            articleCommentToUpdate.commenterName = articleComment.commenterName;

            return this.context.SaveChanges();
        }
    }
}

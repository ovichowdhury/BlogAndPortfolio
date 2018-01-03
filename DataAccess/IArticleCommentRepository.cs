using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IArticleCommentRepository
    {
        List<ArticleComment> GetAll(int articleId);
        ArticleComment Get(int id);
        int Insert(ArticleComment articleComment);
        int Update(ArticleComment articleComment);
        int Delete(int id);
    }
}

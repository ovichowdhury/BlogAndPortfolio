using PWEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWRepository
{
    public interface IArticleCommentRepository: IRepository<ArticleComment>
    {
        List<ArticleComment> GetAll(int id);
        int Update(ArticleComment articleComment);
    }
}

using PWEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWService
{
    public interface IArticleCommentService : IService<ArticleComment>
    {
        List<ArticleComment> GetAll(int id);
        int Update(ArticleComment ac);
    }
}

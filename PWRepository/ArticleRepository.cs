using PWEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWRepository
{
    public class ArticleRepository : Repository<Article> , IArticleRepository
    {
        public List<Article> Search(string keyword)
        {
            List<Article> list = this.context.Articles.Where(x => x.subject.Contains(keyword)).ToList();
            return list;
        }


        public void Update(Article article)
        {
           /* Article articleToUpdate = this.context.Articles.SingleOrDefault(a => a.id == article.id);
            articleToUpdate.subject = article.subject;
            articleToUpdate.attachmentUrl = article.attachmentUrl;
            articleToUpdate.content = article.content;
            articleToUpdate.date = article.date;
           // articleToUpdate.comments = article.comments;

            return this.context.SaveChanges();*/
            Article updatedArticle;
            using (var ctx = new DataAccessContext())
            {
                updatedArticle = ctx.Articles.Where(a => a.id == article.id).FirstOrDefault<Article>();
                
            }

            if (updatedArticle != null)
            {
                updatedArticle.subject = article.subject;
                updatedArticle.content = article.content;
                updatedArticle.attachmentUrl = article.attachmentUrl;
            }

            using (var ctx = new DataAccessContext())
            {
                ctx.Entry(updatedArticle).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
            }
        }
    }
}

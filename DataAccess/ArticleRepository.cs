using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
   public class ArticleRepository:IArticleRepository
    {
        private DataAccessContext dataAccessContext;

        public ArticleRepository()
        {
            this.dataAccessContext=new DataAccessContext();
        }
        public List<Article> GetAll()
        {
            return this.dataAccessContext.Articles.ToList();
        }

        public Article Get(int id)
        {
            try
            {
              return this.dataAccessContext.Articles.SingleOrDefault(a =>a.articleId  == id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e.GetBaseException();
            }
        }


        public int Insert(Article article)
        {
            this.dataAccessContext.Articles.Add(article);
            return this.dataAccessContext.SaveChanges();
        }

        public int Update(Article article)
        {
            Article articleToUpdate = this.dataAccessContext.Articles.SingleOrDefault(a => a.articleId == article.articleId);
            articleToUpdate.subject = article.subject;
            articleToUpdate.attachmentUrl = article.attachmentUrl;
            articleToUpdate.content = article.content;
            articleToUpdate.date = article.date;
            articleToUpdate.comments = article.comments;

            return this.dataAccessContext.SaveChanges();
        }

        public int Delete(int id)
        {
            Article articleToDelete = this.dataAccessContext.Articles.SingleOrDefault(a => a.articleId == id);
            this.dataAccessContext.Articles.Remove(articleToDelete);
            return this.dataAccessContext.SaveChanges();
        }


        public List<Article> Search(string keyword)
        {
            List<Article> list = dataAccessContext.Articles.Where(x => x.subject.Contains(keyword)).ToList();
            return list;
        }

    }
}

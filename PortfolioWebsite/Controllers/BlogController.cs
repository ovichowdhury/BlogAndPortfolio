using PortfolioWebsite.App_Start;
using PortfolioWebsite.Attributes;
using PWEntity;
using PWService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace PortfolioWebsite.Controllers
{
    public class BlogController : Controller
    {
        private ServiceFactory services;

        public BlogController()
        {
            this.services = Injector.container.Resolve<ServiceFactory>();
            //this.services = new ServiceFactory();
        }
        public ActionResult Index()
        {
            this.AddSiteLayoutData();
            return View(services.articleService.GetAll().OrderByDescending(x => x.date));
        }

        [AdminAuthentication]
        public ActionResult CreateNew()
        {
            return View();
        }

        [AdminAuthentication,HttpPost,ValidateInput(false)]
        public ActionResult CreateNew(Article article, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    string path = Path.Combine(Server.MapPath("~/attachments/"), file.FileName);
                    file.SaveAs(path);
                    article.attachmentUrl = "~/attachments/" + file.FileName;
                }
                article.date = DateTime.Now;
                services.articleService.Insert(article);
                TempData["message"] = "Created successfully";
                return RedirectToAction("CreateNew");
            }
            else
            {
                TempData["message"] = "Check your inputs properly";
                return RedirectToAction("CreateNew");
            }
        }

        [AdminAuthentication]
        public ActionResult ShowAll()
        {
            return View(services.articleService.GetAll().OrderByDescending(x => x.date));
        }

        public ActionResult Details(int id)
        {
            this.AddSiteLayoutData();
            Article art = services.articleService.Get(id);
            ViewBag.comments = services.articleCommentService.GetAll(art.id);
            return View(art);
        }

        [HttpPost,ActionName("Details")]
        public ActionResult AddArticleComment(ArticleComment ac)
        {
            if (ModelState.IsValid)
            {
                ac.date = DateTime.Now;
                services.articleCommentService.Insert(ac);
                Session["message"] = "Successfully posted";
                return RedirectToAction("Details");
            }
            else
            {
                Session["message"] = "Failed to post!!! please recheck your information";
                return RedirectToAction("Details");
            }
            
        }

        [AdminAuthentication]
        public ActionResult Delete(int id)
        {
            services.articleService.Delete(id);
            return RedirectToAction("ShowAll");
        }

        [AdminAuthentication]
        public ActionResult Edit(int id)
        {
            return View(services.articleService.Get(id));
        }

        [AdminAuthentication, HttpPost, ValidateInput(false)]
        public ActionResult Edit(Article article, HttpPostedFileBase file)
        {
            if (file != null)
            {
                string previousPath = Request.MapPath(article.attachmentUrl);
                string path = Path.Combine(Server.MapPath("~/attachments/"), file.FileName);
                file.SaveAs(path);
                article.attachmentUrl = "~/attachments/" + file.FileName;

                if (System.IO.File.Exists(previousPath))
                {
                    System.IO.File.Delete(previousPath);
                }
            }
            services.articleService.Update(article);
            TempData["message"] = "Successfully updated";
            return RedirectToAction("Edit");

        }


        [HttpPost]
        public ActionResult Search(string keyword)
        {
            this.AddSiteLayoutData();
            return View(services.articleService.Search(keyword));
        }


        public ActionResult Download(int articleId)
        {
            try
            {
                string path = Server.MapPath(services.articleService.Get(articleId).attachmentUrl);
                byte[] fileBytes = System.IO.File.ReadAllBytes(path);
                string fileName = Path.GetFileName(path);
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            }
            catch (Exception)
            {
                return Content("File not found");
            }
            
        }

        [AdminAuthentication]
        public ActionResult Comments()
        {
            List<ArticleComment> comments = services.articleCommentService.GetAll();
            foreach (var comment in comments)
            {
                comment.parentArticle = services.articleService.Get(comment.articleId);
            }
            return View(comments.OrderByDescending(x => x.date));
        }


        [AdminAuthentication]
        public ActionResult DeleteComment(int id)
        {
            services.articleCommentService.Delete(id);
            return RedirectToAction("Comments");
        }


        [NonAction]
        private void AddSiteLayoutData()
        {
            ViewBag.Name = services.userDetailsService.Get().name;
            ViewBag.Copyright = services.footerService.Get().copyright;
            ViewBag.FbUrl = services.footerService.Get().fbUrl;
            ViewBag.GitUrl = services.footerService.Get().gitUrl;
        }
	}
}
using PortfolioWebsite.App_Start;
using PWEntity;
using PWService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioWebsite.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private ServiceFactory services;

        public HomeController()
        {
            this.services = Injector.container.Resolve<ServiceFactory>();
            //this.services = new ServiceFactory();
         
        }

        public ActionResult Home()
        {
            this.AddSiteLayoutData();
            ViewBag.LatestArticles = services.articleService.GetAll().OrderByDescending(x => x.date).Take(3);
            ViewBag.Occupation = services.userDetailsService.Get().occupation;
            ViewBag.ImagePath = services.imageService.Get().imageUrl;
            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Name = services.userDetailsService.Get().name;
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login log)
        {
            ViewBag.Name = services.userDetailsService.Get().name;
            Login lg = services.loginService.Get();
            if (lg.username.Equals(log.username) && lg.password.Equals(log.password))
            {
                Session["username"] = lg.username;
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                TempData["error"] = "Please check your username and password";
                return RedirectToAction("Login");
            }
        }

        public ActionResult About()
        {
            ViewBag.Name = services.userDetailsService.Get().name;
            ViewBag.About = services.userDetailsService.Get().about;
            return View();
        }

        public ActionResult Qualification()
        {
            this.AddSiteLayoutData();
            ViewBag.Education = services.userDetailsService.Get().education;
            ViewBag.Skills = services.userDetailsService.Get().skills;
            return View();
        }

        public ActionResult Projects()
        {
            this.AddSiteLayoutData();
            List<Project> pro = services.projectService.GetAll();
            return View(pro);
        }

        public ActionResult Contact()
        {
            ViewBag.Name = services.userDetailsService.Get().name;
            ViewBag.Contact = services.userDetailsService.Get().contact;
            ViewBag.Address = services.userDetailsService.Get().address;
            return View();
        }

        [HttpPost]
        public ActionResult Contact(Feedback feed)
        {
            if (ModelState.IsValid)
            {
                feed.date = DateTime.Now;
                services.feedbackService.Insert(feed);
                Session["feedMessage"] = "Thanks for your comment";
            }
            else
            {
                Session["feedMessage"] = "Failed to send the message";
            }
            return RedirectToAction("Contact");
        }

        [HttpPost]
        public JsonResult SearchAutoComplete(string prefix)
        {
            /*var response = (from article in services.articleService.GetAll()
                            where article.subject.Contains(prefix)
                            select article.subject
                            ).ToList();
            return Json(response);*/
            var response = (from article in services.articleService.GetAll()
                            where article.subject.ToLower().Contains(prefix.ToLower())
                            select article.subject
                            ).ToList();
            return Json(response);
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
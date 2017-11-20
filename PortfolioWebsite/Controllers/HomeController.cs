using DataAccess;
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
        private AllRepositories repositories = new AllRepositories();

        public ActionResult Home()
        {
            ViewBag.Name = repositories.userDetailsRepository.Get().name;
            ViewBag.Occupation = repositories.userDetailsRepository.Get().occupation;
            ViewBag.Copyright = repositories.footerRepository.Get().copyright;
            ViewBag.FbUrl = repositories.footerRepository.Get().fbUrl;
            ViewBag.GitUrl = repositories.footerRepository.Get().gitUrl;
            ViewBag.ImagePath = repositories.imageRepository.Get().imageUrl;

            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Name = repositories.userDetailsRepository.Get().name;
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login log)
        {
            ViewBag.Name = repositories.userDetailsRepository.Get().name;
            Login lg = repositories.loginRepository.Get();
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
            ViewBag.Name = repositories.userDetailsRepository.Get().name;
            ViewBag.About = repositories.userDetailsRepository.Get().about;
            return View();
        }

        public ActionResult Qualification()
        {
            ViewBag.Name = repositories.userDetailsRepository.Get().name;
            ViewBag.Copyright = repositories.footerRepository.Get().copyright;
            ViewBag.FbUrl = repositories.footerRepository.Get().fbUrl;
            ViewBag.GitUrl = repositories.footerRepository.Get().gitUrl;
            ViewBag.Education = repositories.userDetailsRepository.Get().education;
            ViewBag.Skills = repositories.userDetailsRepository.Get().skills;
            return View();
        }

        public ActionResult Projects()
        {
            ViewBag.Name = repositories.userDetailsRepository.Get().name;
            ViewBag.Copyright = repositories.footerRepository.Get().copyright;
            ViewBag.FbUrl = repositories.footerRepository.Get().fbUrl;
            ViewBag.GitUrl = repositories.footerRepository.Get().gitUrl;
            List<Project> pro = repositories.projectRepository.GetAll();
            return View(pro);
        }

        public ActionResult Contact()
        {
            ViewBag.Name = repositories.userDetailsRepository.Get().name;
            ViewBag.Contact = repositories.userDetailsRepository.Get().contact;
            ViewBag.Address = repositories.userDetailsRepository.Get().address;
            return View();
        }

        [HttpPost]
        public ActionResult Contact(Feedback feed)
        {
            if (ModelState.IsValid)
            {
                feed.date = DateTime.Now;
                repositories.feedbackRepository.Insert(feed);
                Session["feedMessage"] = "Thanks for your comment";
            }
            else
            {
                Session["feedMessage"] = "Failed to send the message";
            }
            return RedirectToAction("Contact");
        }

        public ActionResult Test()
        {
            return View("_DashboardLayout");
        }

	}
}
using PortfolioWebsite.App_Start;
using PortfolioWebsite.Attributes;
using PWEntity;
using PWService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioWebsite.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        private ServiceFactory services;

        public AdminController()
        {
            services = Injector.container.Resolve<ServiceFactory>();
            //this.services = new ServiceFactory();
        }

        [AdminAuthentication]
        public ActionResult Index()
        {
            return View(services.feedbackService.GetAll().OrderByDescending(x => x.date));
        }

        public ActionResult DeleteFeed(int id)
        {
            if (Session["username"] != null)
            {
                return View(services.feedbackService.Get(id));
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpPost,ActionName("DeleteFeed")]
        public ActionResult DeleteFeedConfirm(int id)
        {
            if (Session["username"] != null)
            {
                services.feedbackService.Delete(id);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        public ActionResult Logout()
        {
            if(Session["username"] != null)
                Session.Remove("username");
            return RedirectToAction("Login", "Home");
        }

        public ActionResult UserDetails()
        {
            if (Session["username"] != null)
            {
                return View(services.userDetailsService.Get());
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpPost,ValidateInput(false)]
        public ActionResult UserDetails(UserDetails ud)
        {
            if (Session["username"] != null)
            {
                if (ModelState.IsValid)
                {
                    ud.id = 1;
                    services.userDetailsService.Update(ud);
                    TempData["message"] = "Update Successfull";
                    return RedirectToAction("UserDetails");
                }
                else
                {
                    TempData["message"] = "Please fill all the details properly";
                    return RedirectToAction("UserDetails"); 
                }
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }


        public ActionResult Picture()
        {
            if (Session["username"] != null)
            {
                ViewBag.ImageUrl = services.imageService.Get().imageUrl;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
            
        }

        [HttpPost]
        public ActionResult Picture(HttpPostedFileBase file)
        {
            if (Session["username"] != null)
            {
                string ext = Path.GetExtension(file.FileName);
                if (file != null && ext.Equals(".jpg") || ext.Equals(".png"))
                {
                    string path = Path.Combine(Server.MapPath("~/Images/"), file.FileName);
                    file.SaveAs(path);
                    Image img = new Image();
                    img.id = 1;
                    img.imageUrl = "~/Images/" + file.FileName;
                    services.imageService.Update(img);

                    TempData["message"] = "Update Successfull";
                    return RedirectToAction("Picture");
                }
                else
                {
                    TempData["message"] = "Failed to Update";
                    return RedirectToAction("Picture");
                }
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }   
                
        }


        public ActionResult Projects()
        {
            if (Session["username"] != null)
            {
                return View(services.projectService.GetAll());
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        public ActionResult CreateProject()
        {
            if (Session["username"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpPost]
        public ActionResult CreateProject(Project pro)
        {
            if (Session["username"] != null)
            {
                if (ModelState.IsValid)
                {
                    services.projectService.Insert(pro);
                    TempData["message"] = "New project created successfully";
                    return RedirectToAction("CreateProject");
                }
                else
                {
                    TempData["message"] = "Failed to create new project";
                    return RedirectToAction("CreateProject");
                }
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }


        public ActionResult EditProject(int id)
        {
            if (Session["username"] != null)
            {
                return View(services.projectService.Get(id));
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpPost]
        public ActionResult EditProject(Project pro)
        {
            if (Session["username"] != null)
            {
                if (ModelState.IsValid)
                {
                    services.projectService.Update(pro);
                    TempData["message"] = "Updated Successfully";
                    return RedirectToAction("EditProject");
                }
                else
                {
                    TempData["message"] = "Failed to Update";
                    return RedirectToAction("EditProject");
                }
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }


        public ActionResult DeleteProject(int id)
        {
            if (Session["username"] != null)
            {
                return View(services.projectService.Get(id));
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpPost,ActionName("DeleteProject")]
        public ActionResult DeleteProjectConfirm(int id)
        {
            if (Session["username"] != null)
            {
                services.projectService.Delete(id);
                return RedirectToAction("Projects");
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }


        public ActionResult Footer()
        {
            if (Session["username"] != null)
            {
                return View(services.footerService.Get());
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpPost]
        public ActionResult Footer(Footer ft)
        {
            if (Session["username"] != null)
            {
                if (ModelState.IsValid)
                {
                    ft.id = 1;
                    services.footerService.Update(ft);
                    TempData["message"] = "Updated Successfully";
                    return RedirectToAction("Footer");
                }
                else
                {
                    TempData["message"] = "Failed to Update";
                    return RedirectToAction("Footer");
                }
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        public ActionResult UpdateLogin()
        {
            if (Session["username"] != null)
            {
                ViewBag.Username = services.loginService.Get().username;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpPost]
        public ActionResult UpdateLogin(FormCollection formData)
        {
            if (Session["username"] != null)
            {
                if (Convert.ToString(formData["oldpass"]).Equals(services.loginService.Get().password))
                {
                    Login lg = new Login();
                    lg.id = 1;
                    lg.username = Convert.ToString(formData["username"]);
                    lg.password = Convert.ToString(formData["newpass"]);
                    services.loginService.Update(lg);

                    TempData["message"] = "Login Credentials updated successfully";
                    return RedirectToAction("UpdateLogin");
                }
                else
                {
                    TempData["message"] = "Please provide the current password correctly";
                    return RedirectToAction("UpdateLogin");
                }
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }


        [AdminAuthentication]
        public ActionResult Statistics()
        {

            this.SetStatData();
            return View();
        }

        [NonAction]
        private void SetStatData()
        {
            ViewBag.TotalFeedbacks = services.feedbackService.GetAll().Count;
            ViewBag.TotalComments = services.articleCommentService.GetAll().Count;
            ViewBag.TotalArticles = services.articleService.GetAll().Count;

            int totalFeedThisMonth = 0;
            int totalCommentsThisMonth = 0;
            int totalArticlesThisMonth = 0;
            foreach (var feedback in services.feedbackService.GetAll())
            {
                if (feedback.date.Month == DateTime.Now.Month && feedback.date.Year == DateTime.Now.Year)
                    totalFeedThisMonth++;
            }
            foreach (var comment in services.articleCommentService.GetAll())
            {
                if (comment.date.Month == DateTime.Now.Month && comment.date.Year == DateTime.Now.Year)
                    totalCommentsThisMonth++;
            }
            foreach (var article in services.articleService.GetAll())
            {
                if (article.date.Month == DateTime.Now.Month && article.date.Year == DateTime.Now.Year)
                    totalArticlesThisMonth++;
            }

            ViewBag.FeedsThisMonth = totalFeedThisMonth;
            ViewBag.CommentsThisMonth = totalCommentsThisMonth;
            ViewBag.ArticlesThisMonth = totalArticlesThisMonth;
        }


	}
}
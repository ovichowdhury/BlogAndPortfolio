using DataAccess;
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
        private AllRepositories repositories = new AllRepositories();
        public ActionResult Index()
        {
            if (Session["username"] != null)
            {
                return View(repositories.feedbackRepository.GetAll().OrderByDescending(x => x.date));
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
                
        }

        public ActionResult DeleteFeed(int id)
        {
            if (Session["username"] != null)
            {
                return View(repositories.feedbackRepository.Get(id));
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
                repositories.feedbackRepository.Delete(id);
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
                return View(repositories.userDetailsRepository.Get());
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
                    repositories.userDetailsRepository.Update(ud);
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
                ViewBag.ImageUrl = repositories.imageRepository.Get().imageUrl;
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
                    img.imageUrl = "~/Images/" + file.FileName;
                    repositories.imageRepository.Update(img);

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
                return View(repositories.projectRepository.GetAll());
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
                    repositories.projectRepository.Insert(pro);
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
                return View(repositories.projectRepository.Get(id));
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
                    repositories.projectRepository.Update(pro);
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
                return View(repositories.projectRepository.Get(id));
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
                repositories.projectRepository.Delete(id);
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
                return View(repositories.footerRepository.Get());
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
                    repositories.footerRepository.Update(ft);
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
                ViewBag.Username = repositories.loginRepository.Get().username;
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
                if (Convert.ToString(formData["oldpass"]).Equals(repositories.loginRepository.Get().password))
                {
                    Login lg = new Login();
                    lg.username = Convert.ToString(formData["username"]);
                    lg.password = Convert.ToString(formData["newpass"]);
                    repositories.loginRepository.Update(lg);

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



	}
}
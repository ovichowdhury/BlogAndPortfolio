using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWService
{
    public class ServiceFactory
    {
        public IArticleService articleService;
        public IArticleCommentService articleCommentService;
        public IFeedbackService feedbackService;
        public IFooterService footerService;
        public IImageService imageService;
        public ILoginService loginService;
        public IProjectService projectService;
        public IUserDetailsService userDetailsService;

        public ServiceFactory()
        {
            this.articleService = new ArticleService();
            this.articleCommentService = new ArticleCommentService();
            this.feedbackService = new FeedbackService();
            this.footerService = new FooterService();
            this.imageService = new ImageService();
            this.loginService = new LoginService();
            this.projectService = new ProjectService();
            this.userDetailsService = new UserDetailsService();
        }
    }
}

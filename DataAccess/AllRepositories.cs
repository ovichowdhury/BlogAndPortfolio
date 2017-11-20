using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AllRepositories
    {
        public FeedbackRepository feedbackRepository;
        public FooterRepository footerRepository;
        public ImageRepository imageRepository;
        public LoginRepository loginRepository;
        public ProjectRepository projectRepository;
        public UserDetailsRepository userDetailsRepository;

        public ArticleRepository articleRepository;
        public ArticleCommentRepository articleCommentRepository;

        public AllRepositories()
        {
            this.feedbackRepository = new FeedbackRepository();
            this.footerRepository = new FooterRepository();
            this.imageRepository = new ImageRepository();
            this.projectRepository = new ProjectRepository();
            this.loginRepository = new LoginRepository();
            this.userDetailsRepository = new UserDetailsRepository();

            this.articleRepository = new ArticleRepository();
            this.articleCommentRepository = new ArticleCommentRepository();
        }
    }
}

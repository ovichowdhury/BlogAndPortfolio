using PWEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWRepository
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public int Update(Project pro)
        {
            Project project = this.Get(pro.id);
            project.projectDetails = pro.projectDetails;
            project.projectName = pro.projectName;
            project.sourceUrl = pro.sourceUrl;

            return this.context.SaveChanges();
        }
    }
}

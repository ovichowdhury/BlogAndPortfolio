using PWEntity;
using PWRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWService
{
    public class ProjectService : Service<Project>, IProjectService
    {
        IProjectRepository repo = new ProjectRepository();
        public int Update(Project pro)
        {
            return this.repo.Update(pro);
        }
    }
}

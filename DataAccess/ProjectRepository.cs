using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProjectRepository : IProjectRepository
    {
        private DataAccessContext context;

        public ProjectRepository()
        {
            this.context = new DataAccessContext();
        }
        public List<Project> GetAll()
        {
            return this.context.Projects.ToList();
        }

        public Project Get(int id)
        {
            return this.context.Projects.SingleOrDefault(x => x.projectId == id);
        }

        public int Insert(Project pro)
        {
            this.context.Projects.Add(pro);
            return this.context.SaveChanges();
        }

        public int Update(Project pro)
        {
            Project project = this.Get(pro.projectId);
            project.projectDetails = pro.projectDetails;
            project.projectName = pro.projectName;
            project.sourceUrl = pro.sourceUrl;

            return this.context.SaveChanges();
        }

        public int Delete(int id)
        {
            Project dProject = this.Get(id);
            this.context.Projects.Remove(dProject);
            return this.context.SaveChanges();
        }
    }
}

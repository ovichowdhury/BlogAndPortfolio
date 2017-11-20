using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    interface IProjectRepository
    {
        List<Project> GetAll();
        Project Get(int id);
        int Insert(Project pro);
        int Update(Project pro);
        int Delete(int id);
    }
}

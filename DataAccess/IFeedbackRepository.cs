using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    interface IFeedbackRepository
    {
        List<Feedback> GetAll();
        Feedback Get(int id);
        int Insert(Feedback feed);
        int Delete(int id);
    }
}

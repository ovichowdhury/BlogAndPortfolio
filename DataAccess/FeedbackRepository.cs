using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private DataAccessContext context;

        public FeedbackRepository()
        {
            this.context = new DataAccessContext();
        }
        public List<Feedback> GetAll()
        {
            return context.Feedbacks.ToList();
        }

        public Feedback Get(int id)
        {
            return context.Feedbacks.SingleOrDefault(x => x.id == id);
        }

        public int Insert(Feedback feed)
        {
            context.Feedbacks.Add(feed);
            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            Feedback dFeedback = context.Feedbacks.SingleOrDefault(x => x.id == id);
            context.Feedbacks.Remove(dFeedback);
            return context.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class FooterRepository : IFooterRepository
    {
        private DataAccessContext context;

        public FooterRepository()
        {
            this.context = new DataAccessContext();
        }
        public Footer Get()
        {
            List<Footer> footer = context.FooterInfo.ToList();
            return footer[0];
        }

        public int Update(Footer ft)
        {
            Footer footer = this.Get();
            footer.copyright = ft.copyright;
            footer.fbUrl = ft.fbUrl;
            footer.gitUrl = ft.gitUrl;

            return context.SaveChanges();
        }
    }
}

using PWEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWRepository
{
    public class FooterRepository : Repository<Footer>, IFooterRepository
    {
        public int Update(Footer ft)
        {
            Footer footer = this.Get(1);
            footer.copyright = ft.copyright;
            footer.fbUrl = ft.fbUrl;
            footer.gitUrl = ft.gitUrl;

            return context.SaveChanges();
        }
    }
}

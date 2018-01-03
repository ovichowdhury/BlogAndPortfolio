using PWEntity;
using PWRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWService
{
    public class FooterService : Service<Footer>, IFooterService
    {
        IFooterRepository repo = new FooterRepository();
        public Footer Get()
        {
            return this.Get(1);
        }

        public int Update(Footer ft)
        {
            return this.repo.Update(ft);
        }
    }
}

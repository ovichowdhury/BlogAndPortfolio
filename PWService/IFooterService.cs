using PWEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWService
{
    public interface IFooterService : IService<Footer>
    {
        Footer Get();
        int Update(Footer ft);
    }
}

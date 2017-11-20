using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    interface IFooterRepository
    {
        Footer Get();
        int Update(Footer ft);
    }
}

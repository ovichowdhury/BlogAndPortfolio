using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    interface IUserDetailsRepository
    {
        UserDetails Get();
        int Update(UserDetails userDet);
    }
}

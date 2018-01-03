using PWEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWRepository
{
    public interface IUserDetailsRepository : IRepository<UserDetails>
    {
        int Update(UserDetails userDet);
    }
}

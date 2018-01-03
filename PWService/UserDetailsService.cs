using PWEntity;
using PWRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWService
{
    public class UserDetailsService : Service<UserDetails>, IUserDetailsService
    {
        IUserDetailsRepository repo = new UserDetailsRepository();
        public UserDetails Get()
        {
            return this.Get(1);
        }

        public int Update(UserDetails ud)
        {
            return this.repo.Update(ud);
        }
    }
}

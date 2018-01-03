using PWEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWRepository
{
    public class LoginRepository : Repository<Login>, ILoginRepository
    { 
        public int Update(Login lg)
        {
            Login login = this.Get(1);
            login.username = lg.username;
            login.password = lg.password;
            
            return context.SaveChanges();
        }
    }
}

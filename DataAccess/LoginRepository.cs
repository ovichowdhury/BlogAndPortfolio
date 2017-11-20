using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class LoginRepository : ILoginRepository
    {
        private DataAccessContext context;

        public LoginRepository()
        {
            this.context = new DataAccessContext();
        }
        public Login Get()
        {
            List<Login> login = this.context.LoginInfo.ToList();
            return login[0];
        }

        public int Update(Login lg)
        {
            Login login = this.Get();
            login.username = lg.username;
            login.password = lg.password;
            
            return context.SaveChanges();
        }
    }
}

using PWEntity;
using PWRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWService
{
    public class LoginService : Service<Login> , ILoginService
    {
        ILoginRepository repo = new LoginRepository();
        public Login Get()
        {
            return this.Get(1);
        }

        public int Update(Login lg)
        {
            return this.repo.Update(lg);
        }
    }
}

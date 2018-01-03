﻿using PWEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWService
{
    public interface IUserDetailsService : IService<UserDetails>
    {
        UserDetails Get();
        int Update(UserDetails ud);
    }
}

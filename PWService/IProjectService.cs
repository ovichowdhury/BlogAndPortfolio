﻿using PWEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWService
{
    public interface IProjectService : IService<Project>
    {
        int Update(Project pro);
    }
}

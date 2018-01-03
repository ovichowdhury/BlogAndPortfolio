﻿using PWEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWService
{
    public interface IArticleService : IService<Article>
    {
        List<Article> Search(string keyword);
        void Update(Article article);
    }
}

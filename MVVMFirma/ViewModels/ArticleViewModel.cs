﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class ArticleViewModel:WorkspaceViewModel
    {
        public ArticleViewModel() 
        {
            base.DisplayName = "Article";
        }
    }
}

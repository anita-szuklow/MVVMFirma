﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class AllEmployeesViewModel:WorkspaceViewModel
    {
        public AllEmployeesViewModel() 
        {
            base.DisplayName = "All employees";
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dispatcher;

namespace APISelfHost
{
    internal class CustomAssembliesResolver : DefaultAssembliesResolver
    {
        public override ICollection<System.Reflection.Assembly> GetAssemblies()
        {
            var assemblies = base.GetAssemblies();

            // Interestingly, if we push the same assembly twice in the collection,
            // an InvalidOperationException suggests that there is different 
            // controllers of the same name (I think it's a bug of WebApi 2.1).
            var customControllersAssembly = typeof(QuotationAPI.Controllers.UserManagementController).Assembly;
            if (!assemblies.Contains(customControllersAssembly))
                assemblies.Add(customControllersAssembly);

            return assemblies;
        }
    }
}

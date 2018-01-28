using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Quotation.Core.Utilities
{
    public static class IdentityUtility
    {
        public static string GetLoggedInUserName()
        {
            string loggedInName = string.Empty;
            CustomPrincipal customPrincipal = Thread.CurrentPrincipal as CustomPrincipal;
            if (customPrincipal != null)
            {
                CustomIdentity identity = customPrincipal.Identity as CustomIdentity;
                loggedInName = identity.Name;
            }

            return loggedInName;
        }

        public static string GetLoggedInUserRole()
        {
            string loggedInRole = string.Empty;
            CustomPrincipal customPrincipal = Thread.CurrentPrincipal as CustomPrincipal;
            if (customPrincipal != null)
            {
                CustomIdentity identity = customPrincipal.Identity as CustomIdentity;
                loggedInRole = identity.Role;
            }

            return loggedInRole;
        }

        public static bool IsAdministrator(string roleName)
        {
            bool isAdministrator = false;
            CustomPrincipal customPrincipal = Thread.CurrentPrincipal as CustomPrincipal;
            if (customPrincipal != null)
            {
                isAdministrator = customPrincipal.IsInRole(roleName);
            }

            return isAdministrator;
        }

        public static bool IsFormAccessible(string formName)
        {
            bool isFormAccessible = false;
            CustomPrincipal customPrincipal = Thread.CurrentPrincipal as CustomPrincipal;
            if (customPrincipal != null)
            {
                isFormAccessible = customPrincipal.IsFormAccessible(formName);
            }

            return isFormAccessible;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.Core
{
    public class CustomPrincipal : IPrincipal
    {
        private CustomIdentity _identity;

        public CustomIdentity Identity
        {
            get { return _identity ?? new AnonymousIdentity(); }
            set { _identity = value; }
        }

        #region IPrincipal Members
        IIdentity IPrincipal.Identity
        {
            get { return this.Identity; }
        }

        public bool IsInRole(string role)
        {
            return _identity.Role.Equals(role);
        }

        public bool IsFormAccessible(string formName)
        {
            return _identity.FormNames.Any(fn => fn == formName);
        }
        #endregion
    }
}

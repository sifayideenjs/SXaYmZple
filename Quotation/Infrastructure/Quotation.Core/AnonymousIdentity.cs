using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.Core
{
    public class AnonymousIdentity : CustomIdentity
    {
        public AnonymousIdentity() : base("Anonymous", string.Empty, new string[] { })
        {
        }
    }
}

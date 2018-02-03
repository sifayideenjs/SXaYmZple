using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.Core.Utilities
{
    public static class ClockTampering
    {
        /// <summary>
        /// check the creation date/time on an essential file.
        /// </summary>
        /// <returns></returns>
        public static bool IsClockTampered()
        {
            // use the config file:
            var me = Assembly.GetExecutingAssembly().Location + ".config";
            if (File.Exists(me))
            {
                // get the existing last-write
                var createdOn = File.GetCreationTime(me);
                if (createdOn < DateTime.Now)
                {
                    // set the last write time on the assembly:
                    File.SetCreationTime(me, DateTime.Now);
                    return true;
                }
            }
            return false;
        }
    }
}

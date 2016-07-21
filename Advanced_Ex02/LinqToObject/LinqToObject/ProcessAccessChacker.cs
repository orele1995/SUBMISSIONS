using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToObject
{
    class ProcessAccessChacker
    {
        public bool canAccess(Process p) {
            try
            {
                DateTime d = p.StartTime;
                return true;
            }
            catch (System.ComponentModel.Win32Exception e)
            { return false; }
            catch (System.InvalidOperationException e)
            { return false; }

        }
    }
}

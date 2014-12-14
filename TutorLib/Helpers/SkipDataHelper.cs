using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorLib.Helpers
{
    class SkipDataHelper
    {
        public static int getSkippedNo(int pageno,int pagesize)
        {
            return (pageno - 1) * pagesize;
        }
    }
}

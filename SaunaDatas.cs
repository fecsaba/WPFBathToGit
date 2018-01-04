using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFBath
{
    class SaunaDatas
    {
        public List<DateTime> SaunaTimes { get; private set; }
        public List<bool> SaunaInOut { get; private set; }
        public int Gid { get; set; }
        public TimeSpan SaunaSum { get; set; }

        public SaunaDatas(TimeSpan times, int gid)
        {
            Gid = gid;
            SaunaSum = times;

        }

    }
}

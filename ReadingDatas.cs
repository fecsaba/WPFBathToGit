using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFBath
{
    class ReadingDatas
    {
        public string Sn(int secCode)
        {
            switch (secCode)
            {
                case 0:
                    return "Dressing room ";
                case 1:
                    return "Swimming pool";
                case 2:
                    return "Saunas";
                case 3:
                    return "Spa";
                case 4:
                    return "Beach";
                default:
                    return "The code is shit";

            }
        }
        DateTime timeInBath;
        public int GuestId { get; private set; }
        public int SectionId { get; private set; }
        public string SectionName { get; private set; }
        public bool EnterOrLeave { get; private set; }
        public string TimeStr { get; private set; }
        public long TimeLng { get; private set; }
        public DateTime TimeInBath { get => timeInBath; set => timeInBath = value; }
        public bool SwitchOfValidity { get; set; }

        public ReadingDatas(string Rec)
        {
            string[] f = Rec.Split(' ');
            SwitchOfValidity = true;
            GuestId = int.Parse(f[0]);
            SectionId = int.Parse(f[1]);
            SectionName = Sn(int.Parse(f[1]));

            EnterOrLeave = (f[2] == '0'.ToString() ? false : true);
            DateTime time = new DateTime(1970, 1, 1, int.Parse(f[3]), int.Parse(f[4]), int.Parse(f[5]));

            TimeStr = time.ToLongTimeString();
            TimeLng = time.Ticks;
            TimeInBath = time;

        }
        public ReadingDatas()
        {

        }

    }
}

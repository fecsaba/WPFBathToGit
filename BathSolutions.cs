using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFBath
{
    class BathSolutions
    {
        
        public List<ReadingDatas> RD { get; private set; }
        public HashSet<int> FilteredRD { get; private set; }
        public List<string> Dat { get; private set; }
        public StreamReader Sr { get; private set; }
        public List<SaunaDatas> S { get; private set; }



        public BathSolutions() // Task1
        {


            Sr = new StreamReader("furdoadat.txt");
            RD = new List<ReadingDatas>();
            while (!Sr.EndOfStream)
            {
                RD.Add(new ReadingDatas(Sr.ReadLine()));
            }
            Sr.Close();
        }
        public string Task2()
        {
            var timeMin = RD
                .Where(s => s.SectionId == 0)
                .Where(s => s.EnterOrLeave)
                .Min(s => s.TimeLng);
            int minIndex = RD.FindIndex(x => x.TimeLng == timeMin);
            var timeMax = RD
               .Where(s => s.SectionId == 0)
               .Where(s => s.EnterOrLeave)
               .Max(s => s.TimeLng);
            int maxIndex = RD.FindIndex(x => x.TimeLng == timeMax);
            return ($"\nAz első az {RD[minIndex].GuestId} sz. kuncsaft, " +
                $"{RD[minIndex].TimeStr}-kor,\n " +
                $"az utolsó az {RD[maxIndex].GuestId} sz., " +
                $"{RD[maxIndex].TimeStr}-kor \nlépett ki az öltözőből");
        }
        public string Task3()
        {
            List<List<int>> one = new List<List<int>>();
            int id = 0;
            int j = -1;
            foreach (var item in RD)
            {
                if (item.GuestId != id)
                {
                    one.Add(new List<int>());
                    j++;
                    one[j].Add(item.GuestId);
                }
                else
                {
                    one[j].Add(item.GuestId);

                }
                id = item.GuestId;

            }
            int piece = 0;
            foreach (var item in one)
            {
                if (item.Count == 4)
                {
                    piece++;
                }
            }
            return ($"\n{piece} kuncsaft volt 1 helyen");
        }
        public string Task4()
        {
            int id = 0;
            int indexOfMax;
            DateTime enter = new DateTime();
            DateTime leave;
            TimeSpan total;
            TimeSpan maxTotal;
            List<TimeSpan> mt = new List<TimeSpan>();
            List<int> mi = new List<int>();
            foreach (var item in RD.Where(x => x.SectionId == 0))
            {
                if (item.GuestId != id)
                {

                    enter = item.TimeInBath;
                    mi.Add(item.GuestId);
                }
                else
                {



                    leave = item.TimeInBath;
                    total = leave - enter;
                    mt.Add(total);


                }
                id = item.GuestId;


            }
            maxTotal = mt.Max(x => x);
            indexOfMax = mt.IndexOf(maxTotal);
            return ($"\nA legtöbb időt eltöltő \nkuncsaft a {mi[indexOfMax]}. sz., \n" +
                $"{maxTotal} ideig áztatta a seggét. ");
        }
        public string Task5(int from, string to)
        {
            int guests = 0;
            foreach (var item in RD.Where(x => x.SectionId == 0)
                .Where(x => x.EnterOrLeave)
                .Where(x => x.TimeInBath.Hour >= from && x.TimeInBath <
                DateTime.Parse("1970.01.01." + to)))

            {

                guests++;
            }
            return ($"{from}-{to}-ig {guests} kuncsaft járt itt");

        }
        public string Task6()
        {
            List<int> ids = new List<int>();

            DateTime timeIn = new DateTime();
            DateTime timeOut = new DateTime();
            var i = 0;
            S = new List<SaunaDatas>();

            foreach (var item in RD.Where(x => x.SectionId == 2))
            {
                i++;
                if (!item.EnterOrLeave) timeIn = item.TimeInBath;
                else timeOut = item.TimeInBath;
                if (i % 2 == 0)
                {
                    S.Add(new SaunaDatas(timeOut - timeIn, item.GuestId));
                }
            }
            for (int a = 0; a < S.Count - 1; a++)
            {
                for (int b = a + 1; b < S.Count; b++)
                {
                    if (S[a].Gid == S[b].Gid)
                    {

                        S[a].SaunaSum = S[a].SaunaSum + S[b].SaunaSum;
                        S[b].Gid = 0;
                    }
                }
            }
            S.RemoveAll(x => x.Gid == 0);
            StreamWriter sw = new StreamWriter("szauna.txt");
            foreach (var item in S)
            {
                sw.WriteLine($"{item.Gid} {item.SaunaSum}");

            }
            sw.Close();
            return "szauna.txt kész";

        }
        public string Task7(int sid)
        {
            ReadingDatas c = new ReadingDatas();
            string n = c.Sn(sid);
            FilteredRD = new HashSet<int>();
            foreach (var item in RD.Where(x => x.SectionId == sid))
            {
                FilteredRD.Add(item.GuestId);
            }
            return ($"{n}: {FilteredRD.Count}");


        }
    }
}

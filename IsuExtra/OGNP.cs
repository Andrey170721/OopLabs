using System.Collections.Generic;
using Isu.Services;

namespace IsuExtra
{
    public class OGNP
    {
        public OGNP(string mf)
        {
            MegaFaculty = mf;
        }

        public string MegaFaculty { get; }
        public List<Stream> Streams { get; }

        public void AddNewStream(Timetable timetable, int placeNum)
        {
            Streams.Add(new Stream(timetable, placeNum));
        }
    }
}
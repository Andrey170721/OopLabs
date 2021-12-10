using System.Collections.Generic;
using Isu.Services;
using IsuExtra.Entity;
using IsuExtra.Tools;

namespace IsuExtra
{
    public class OGNP
    {
        public OGNP(string mf)
        {
            if (mf.Length > 1)
            {
                throw new IsuExtraException("Invalid MegafacultyName");
            }

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
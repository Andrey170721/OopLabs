using System.Collections.Generic;
using Isu.Services;
using IsuExtra.Entity;
using IsuExtra.Tools;

namespace IsuExtra
{
    public class OGNP
    {
        private readonly List<Stream> _streams;

        public OGNP(char mf)
        {
            MegaFaculty = mf;
            _streams = new List<Stream>();
        }

        public char MegaFaculty { get; }

        public IReadOnlyList<Stream> Streams => _streams.AsReadOnly();

        public void AddNewStream(Timetable timetable, int placeNum)
        {
            _streams.Add(new Stream(timetable, placeNum));
        }
    }
}
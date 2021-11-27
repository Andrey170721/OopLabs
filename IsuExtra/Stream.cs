namespace IsuExtra
{
    public class Stream
    {
        public Stream(Timetable timetable, int placeNum)
        {
            Timetable = timetable;
            PlaceNum = placeNum;
        }

        public Timetable Timetable { get; }
        public int PlaceNum { get; }
    }
}
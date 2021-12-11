using System.Collections.Generic;
using IsuExtra.Entity;

namespace IsuExtra
{
    public class Stream
    {
        private int _currPlaces = 0;
        public Stream(Timetable timetable, int placeNum)
        {
            Timetable = timetable;
            PlaceNum = placeNum;
            Students = new List<ExtraStudent>();
        }

        public List<ExtraStudent> Students { get; }

        public Timetable Timetable { get; }
        public int PlaceNum { get; }
        public bool CheckTimetables(Timetable timetable1, Timetable timetable2)
        {
            foreach (var couple1 in timetable1.Couples)
            {
                foreach (var couple2 in timetable2.Couples)
                {
                    if (couple1.DayOfWeek == couple2.DayOfWeek
                        && (!(couple1.StartTime < couple2.StartTime && couple1.EndTime < couple2.EndTime)
                            || !(couple1.StartTime > couple2.StartTime && couple1.EndTime > couple2.EndTime)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool AddStudent(ExtraStudent newStudent)
        {
            if (_currPlaces == PlaceNum)
            {
                return false;
            }

            Students.Add(newStudent);
            _currPlaces++;
            return true;
        }

        public void RemoveStudent(ExtraStudent student)
        {
            Students.Remove(student);
            _currPlaces--;
        }
    }
}
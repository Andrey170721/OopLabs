using System.Collections.Generic;
using IsuExtra.Entity;
using IsuExtra.Tools;

namespace IsuExtra
{
    public class Stream
    {
        private readonly List<ExtraStudent> _students;
        private int _currPlaces = 0;
        public Stream(Timetable timetable, int placeNum)
        {
            Timetable = timetable;
            PlaceNum = placeNum;
            _students = new List<ExtraStudent>();
        }

        public IReadOnlyList<ExtraStudent> Students => _students.AsReadOnly();

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

            _students.Add(newStudent);
            _currPlaces++;
            return true;
        }

        public void RemoveStudent(ExtraStudent student)
        {
            if (_students.Exists(s => s == student))
            {
                _students.Remove(student);
            }
            else
            {
                throw new IsuExtraException("student doesn't exists");
            }

            _currPlaces--;
        }
    }
}
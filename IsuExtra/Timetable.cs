using System;
using System.Collections.Generic;

namespace IsuExtra
{
    public class Timetable
    {
        public Timetable()
        {
        }

        public List<Couple> Couples { get; }
        public void AddNewCouple(DayOfWeek dayOfWeek, float startTime, float endTime)
        {
            Couple couple = new Couple(dayOfWeek, startTime, endTime);
            foreach (var item in Couples)
            {
                CheckCouples(item, couple);
            }

            Couples.Add(couple);
        }

        public void CheckTimetables(Timetable timetable)
        {
            foreach (var item1 in timetable.Couples)
            {
                foreach (var item2 in Couples)
                {
                    CheckCouples();
                }
            }
        }

        public void CheckCouples(Couple couple1, Couple couple2)
        {
            if (couple1.DayOfWeek == couple2.DayOfWeek
                && (!(couple1.StartTime < couple2.StartTime && couple1.EndTime < couple2.EndTime)
                    || !(couple1.StartTime > couple2.StartTime && couple1.EndTime > couple2.EndTime)))
            {
                throw new Exception("intersection of pairs");
            }
        }
    }
}
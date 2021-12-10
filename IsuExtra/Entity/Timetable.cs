using System;
using System.Collections.Generic;
using IsuExtra.Tools;

namespace IsuExtra.Entity
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
                if (CheckCouples(item, couple))
                    throw new IsuExtraException("intersection of pairs");
            }

            Couples.Add(couple);
        }

        public bool CheckCouples(Couple couple1, Couple couple2)
        {
            if (couple1.DayOfWeek == couple2.DayOfWeek
                && (!(couple1.StartTime < couple2.StartTime && couple1.EndTime < couple2.EndTime)
                    || !(couple1.StartTime > couple2.StartTime && couple1.EndTime > couple2.EndTime)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
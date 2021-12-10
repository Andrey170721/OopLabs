using System;

namespace IsuExtra
{
    public class Couple
    {
        public Couple(DayOfWeek dayOfWeek, float startTime, float endTime)
        {
            DayOfWeek = dayOfWeek;
            StartTime = startTime;
            EndTime = endTime;
        }

        public DayOfWeek DayOfWeek { get; }
        public float StartTime { get; }
        public float EndTime { get; }
    }
}
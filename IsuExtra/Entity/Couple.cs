using System;

namespace IsuExtra
{
    public class Couple : IEquatable<Couple>
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

        public bool Equals(Couple other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return DayOfWeek == other.DayOfWeek
                   && StartTime.Equals(other.StartTime)
                   && EndTime.Equals(other.EndTime);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Couple)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine((int)DayOfWeek, StartTime, EndTime);
        }
    }
}
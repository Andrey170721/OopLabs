using Isu.Services;

namespace IsuExtra.Entity
{
    public class ExtraGroup : Group
    {
        public ExtraGroup(ExtraGroupName newGroup, int maxStudentNumber, Timetable timetable)
            : base(newGroup, maxStudentNumber)
        {
            Timetable = timetable;
        }

        public Timetable Timetable { get; }
        public new ExtraGroupName GroupName { get; }
    }
}
using System.Collections.Generic;
using Isu.Services;
using IsuExtra.Tools;

namespace IsuExtra.Entity
{
    public class ExtraGroup : Group
    {
        public ExtraGroup(ExtraGroupName newGroup, int maxStudentNumber, Timetable timetable)
            : base(newGroup, maxStudentNumber)
        {
            Timetable = timetable;
            GroupName = newGroup;
            Students = new List<ExtraStudent>();
        }

        public Timetable Timetable { get; }
        public new ExtraGroupName GroupName { get; }
        public new List<ExtraStudent> Students { get; }
        public void AddStudent(ExtraStudent student)
        {
            NumberOfStudents++;
            if (NumberOfStudents > MaxStudentNum) throw new IsuExtraException("Max students exceeded");
            Students.Add(student);
        }
    }
}
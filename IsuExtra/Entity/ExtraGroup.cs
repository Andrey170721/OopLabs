using System.Collections.Generic;
using Isu.Services;
using IsuExtra.Tools;

namespace IsuExtra.Entity
{
    public class ExtraGroup : Group
    {
        private readonly List<ExtraStudent> _students;
        public ExtraGroup(ExtraGroupName newGroup, int maxStudentNumber, Timetable timetable)
            : base(newGroup, maxStudentNumber)
        {
            Timetable = timetable;
            GroupName = newGroup;
            _students = new List<ExtraStudent>();
        }

        public Timetable Timetable { get; }
        public new ExtraGroupName GroupName { get; }
        public new IReadOnlyList<ExtraStudent> Students => _students.AsReadOnly();
        public void AddStudent(ExtraStudent student)
        {
            NumberOfStudents++;
            if (NumberOfStudents > MaxStudentNum) throw new IsuExtraException("Max students exceeded");
            _students.Add(student);
        }
    }
}
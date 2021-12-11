using System.Collections.Generic;
using Isu.Tools;

namespace Isu.Services
{
    public class Group
    {
        public Group(GroupName newGroup, int maxStudentNumber)
        {
            Students = new List<Student>();
            GroupName = newGroup;
            MaxStudentNum = maxStudentNumber;
        }

        public GroupName GroupName { get; }
        public List<Student> Students { get; }
        public int MaxStudentNum { get; }
        public int NumberOfStudents { get; set; }

        public void AddStudent(Student student)
        {
            NumberOfStudents++;
            if (NumberOfStudents > MaxStudentNum) throw new IsuException("Max students exceeded");
            Students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            Students.Remove(student);
            NumberOfStudents--;
        }
    }
}
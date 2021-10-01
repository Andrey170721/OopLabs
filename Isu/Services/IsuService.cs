using System.Collections.Generic;
using System.Text.RegularExpressions;
using Isu.Tools;

namespace Isu.Services
{
    public class IsuService : IIsuService
    {
        private List<Group> _groups = new List<Group>();
        private List<Student> _students = new List<Student>();
        private int _id = 0;

        public Group AddGroup(GroupName name, int maxStudentNumber)
        {
            var group = new Group(name, maxStudentNumber);
            _groups.Add(group);
            return group;
        }

        public Student AddStudent(Group group, string name)
        {
            if (!_groups.Exists(g => g == group)) throw new IsuException("Group not exist");
            var student = new Student(_id, name, group.GroupName);
            _students.Add(student);
            group.AddStudent(student);
            _id++;
            return student;
        }

        public Student GetStudent(int id)
        {
            return _students.Find(s => s.Id == id) ?? throw new IsuException("ID not exist");
        }

        public Student FindStudent(string name)
        {
            return _students.Find(s => s.Name == name);
        }

        public List<Student> FindStudents(string groupName)
        {
            return _students.FindAll(s => s.GroupName.FullName == groupName);
        }

        public List<Student> FindStudents(CourseNumber courseNumber)
        {
            return _students.FindAll(s => s.GroupName.NumberOfCourse == courseNumber);
        }

        public Group FindGroup(string groupName)
        {
            return _groups.Find(g => g.GroupName.FullName == groupName);
        }

        public List<Group> FindGroups(CourseNumber courseNumber)
        {
            return _groups.FindAll(g => g.GroupName.NumberOfCourse == courseNumber);
        }

        public void ChangeStudentGroup(Student student, Group newGroup)
        {
            if (!_students.Exists(s => s == student)) throw new IsuException("student not exist");
            if (!_groups.Exists(g => g == newGroup)) throw new IsuException("group not exist");
            Group oldGroup = _groups.Find(g => g.GroupName == student.GroupName);

            oldGroup?.RemoveStudent(student);
            newGroup.AddStudent(student);
            _students.Add(new Student(student.Id, student.Name, newGroup.GroupName));
            _students.Remove(student);
        }
    }
}

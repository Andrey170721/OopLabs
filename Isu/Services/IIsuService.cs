using System.Collections.Generic;

namespace Isu.Services
{
    public interface IIsuService
    {
        Group AddGroup(GroupName name, int maxStudentNumber);
        Student AddStudent(Group group, string name);

        Student GetStudent(int id);
        Student FindStudent(string name);
        List<Student> FindStudents(string groupName);
        List<Student> FindStudents(CourseNumber courseNumber);
        Group FindGroup(string groupName);
        List<Group> FindGroups(CourseNumber courseNumber);
        void ChangeStudentGroup(Student student, Group newGroup);
    }
}
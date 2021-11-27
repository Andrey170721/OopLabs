using System;
using System.Collections.Generic;
using Isu.Services;

namespace IsuExtra
{
    public class IsuExtraService : IsuService
    {
        private List<ExtraGroup> _groups = new List<ExtraGroup>();
        private List<ExtraStudent> _students = new List<ExtraStudent>();
        private int _id = 0;
        public ExtraGroup AddGroup(ExtraGroupName name, int maxStudentNumber, Timetable timetable)
        {
            var group = new ExtraGroup(name, maxStudentNumber, timetable);
            _groups.Add(group);
            return group;
        }

        public Student AddStudent(ExtraGroup group, string name)
        {
            if (!_groups.Exists(g => g == group)) throw new Exception("Group not exist");
            var student = new ExtraStudent(_id, name, group.GroupName);
            _students.Add(student);
            group.AddStudent(student);
            _id++;
            return student;
        }

        public OGNP AddNewOgnp(string megaFaculty)
        {
            var newOGNP = new OGNP(megaFaculty);
            return newOGNP;
        }

        public void AddStreamToOgnp(OGNP ognp, Timetable timetable, int placeNum)
        {
            ognp.AddNewStream(timetable, placeNum);
        }

        public void AddStudentToOGNP(ExtraStudent student, OGNP oGNP)
        {
            ExtraGroup group = _groups.Find(g => student.GroupName == g.GroupName);
            List<Couple> groupTimetable = group.Timetable.Couples;
            foreach() 
                student.AddOGNP(oGNP);
        }

        public void RemoveStudentFromOGNP(ExtraStudent student, OGNP oGNP)
        {
            student.RemoveOGNP(oGNP);
        }

        public void GetCourseStreams()
        {
            
        }

        public void GetStudentListFromOgnpGroup()
        {
            
        }

        public void GetStudentsWithoutOgnp()
        {
            
        }
    }
}
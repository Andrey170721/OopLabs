using System;
using System.Collections.Generic;
using System.Linq;
using Isu.Services;
using IsuExtra.Entity;
using IsuExtra.Tools;

namespace IsuExtra.Services
{
    public class IsuExtraService
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

        public ExtraStudent AddStudent(ExtraGroup group, string name)
        {
            if (!_groups.Exists(g => g == group)) throw new IsuExtraException("Group not exist");
            var student = new ExtraStudent(_id, name, group.GroupName);
            _students.Add(student);
            group.AddStudent(student);
            _id++;
            return student;
        }

        public OGNP AddNewOgnp(char megaFaculty)
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
            foreach (Stream stream in oGNP.Streams)
            {
                bool isTimetablesNotOverlap = stream.CheckTimetables(stream.Timetable, group.Timetable);
                bool isEnoughPlaces = stream.AddStudent(student);
                if (isEnoughPlaces & isTimetablesNotOverlap)
                {
                    student.AddOGNP(oGNP);
                }
            }

            if (!student.CheckOgnp(oGNP))
            {
                throw new IsuExtraException("the student has an overlap with the timetable or no places");
            }
        }

        public void RemoveStudentFromOGNP(ExtraStudent student, OGNP oGNP)
        {
            student.RemoveOGNP(oGNP);
            foreach (var stream in oGNP.Streams)
            {
                if (stream.Students.Contains(student))
                {
                    stream.RemoveStudent(student);
                }
            }
        }

        public IReadOnlyList<Stream> GetCourseStreams(OGNP ognp)
        {
            return (List<Stream>)ognp.Streams;
        }

        public List<ExtraStudent> GetStudentListFromOgnpGroup(Stream stream)
        {
            return (List<ExtraStudent>)stream.Students;
        }

        public IReadOnlyList<ExtraStudent> GetStudentsWithoutOgnp(ExtraGroup group)
        {
            List<ExtraStudent> students = group.Students.Where(student => student.IsStudentInOgnp() == false).ToList();
            return students;
        }
    }
}
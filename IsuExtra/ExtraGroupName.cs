using System;
using Isu.Services;

namespace IsuExtra
{
    public class ExtraGroupName : GroupName
    {
        public ExtraGroupName(string name)
        {
            MegaFaculty = name[0].ToString();
            NumberOfCourse = (CourseNumber)int.Parse(name[2].ToString());
            NumberOfGroup = (int.Parse(name[3].ToString()) * 10) + int.Parse(name[4].ToString());
            if (name[1] != '3'
                || FullName.Length > 5
                || FullName.Length < 5) throw new Exception("Invalid group name");
        }

        public string MegaFaculty { get; }
        public new CourseNumber NumberOfCourse { get; }
        public new int NumberOfGroup { get; }
        public new string FullName { get; }
    }
}
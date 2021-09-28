using System.Collections.Generic;
using Isu.Tools;

namespace Isu.Services
{
    public class GroupName
    {
        public GroupName(string name)
        {
            int buff1 = name[3] - '0';
            int buff2 = name[4] - '0';
            NumberOfGroup = (buff1 * 10) + buff2;
            NumberOfCourse = new CourseNumber(name);
            FullName = name;
            if (name[0] != 'M'
                || name[1] != '3'
                || NumberOfGroup > 99
                || NumberOfGroup < 1
                || FullName.Length > 5
                || FullName.Length < 5) throw new IsuException("Invalid group name");
        }

        public CourseNumber NumberOfCourse { get; }
        public int NumberOfGroup { get; }
        public string FullName { get; }
    }
}
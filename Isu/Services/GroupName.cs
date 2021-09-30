using System.Collections.Generic;
using Isu.Tools;

namespace Isu.Services
{
    public class GroupName
    {
        public GroupName(string name)
        {
            int buff0 = int.Parse(name[2].ToString());
            int buff1 = int.Parse(name[3].ToString());
            int buff2 = int.Parse(name[4].ToString());
            NumberOfGroup = (buff1 * 10) + buff2;
            NumberOfCourse = (CourseNumber)buff0;
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
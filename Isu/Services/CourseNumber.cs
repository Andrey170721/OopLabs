using Isu.Tools;

namespace Isu.Services
{
    public class CourseNumber
    {
        public CourseNumber(string name)
        {
            Number = name[2] - '0';
            if (Number > 6 || Number < 1) throw new IsuException("Invalid Course Number");
        }

        public int Number { get; }
    }
}
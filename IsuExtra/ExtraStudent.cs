using Isu.Services;

namespace IsuExtra
{
    public class ExtraStudent : Student
    {
        private OGNP firstOGNP = null;
        private OGNP secondOGNP = null;
        public ExtraStudent(int id, string name, ExtraGroupName newGroup)
            : base(id, name, newGroup)
        {
        }

        public void AddOGNP(OGNP oGNP)
        {
            if (firstOGNP == null)
            {
                firstOGNP = oGNP;
            }
            else
            {
                secondOGNP = oGNP;
            }
        }

        public void RemoveOGNP(OGNP oGNP)
        {
            if (firstOGNP == oGNP)
            {
                firstOGNP = null;
            }

            if (secondOGNP == oGNP)
            {
                secondOGNP = null;
            }
        }
    }
}
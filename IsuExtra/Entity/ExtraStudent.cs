using System;
using Isu.Services;

namespace IsuExtra.Entity
{
    public class ExtraStudent : Student
    {
        private OGNP firstOGNP = null;
        private OGNP secondOGNP = null;
        public ExtraStudent(int id, string name, ExtraGroupName newGroup)
            : base(id, name, newGroup)
        {
            GroupName = newGroup;
        }

        public new ExtraGroupName GroupName { get; }

        public void AddOGNP(OGNP oGNP)
        {
            if (GroupName.MegaFaculty == oGNP.MegaFaculty)
            {
                throw new Exception("Student has the same MegaFaculty as OGNP");
            }

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

        public bool CheckOgnp(OGNP ognp)
        {
            if (firstOGNP == ognp || secondOGNP == ognp)
            {
                return true;
            }

            return false;
        }

        public bool IsStudentInOgnp()
        {
            if (firstOGNP == null || secondOGNP == null)
            {
                return false;
            }

            return true;
        }
    }
}
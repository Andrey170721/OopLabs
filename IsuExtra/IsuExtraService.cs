using Isu.Services;

namespace IsuExtra
{
    public class IsuExtraService
    {
        public OGNP AddNewOGNP(string megaFaculty, int placeNum)
        {
            var newOGNP = new OGNP(megaFaculty, placeNum);
            return newOGNP;
        }

        public void AddStudentToOGNP(ExtraStudent student, OGNP oGNP)
        {
            student.AddOGNP(oGNP);
        }

        public void RemoveOGNP(ExtraStudent student, OGNP oGNP)
        {
            student.RemoveOGNP(oGNP);
        }
    }
}
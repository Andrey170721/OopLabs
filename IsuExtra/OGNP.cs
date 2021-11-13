namespace IsuExtra
{
    public class OGNP
    {
        public OGNP(string mf, int num)
        {
            MegaFaculty = mf;
            PlaceNum = num;
        }

        public string MegaFaculty { get; }
        public int PlaceNum { get; }
    }
}
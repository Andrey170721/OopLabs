using System;
using Isu.Services;

namespace IsuExtra
{
    public class ExtraGroupName : GroupName
    {
        public ExtraGroupName(string name)
        {
            MegaFaculty = name[0].ToString();
        }

        public string MegaFaculty { get; }
    }
}
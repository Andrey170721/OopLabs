using System;

namespace Reports.Tools
{
    public class ReportException :Exception
    {
        public ReportException()
        {
        }

        public ReportException(string message)
            : base(message)
        {
        }

        public ReportException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
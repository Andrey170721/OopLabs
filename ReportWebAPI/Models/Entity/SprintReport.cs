using System.Collections.Generic;

namespace Reports.Entity
{
    public class SprintReport
    {
        public SprintReport(List<Report> reports)
        {
            Tasks = new List<Task>();
            foreach (var report in reports)
            {
                Tasks.AddRange(report.Tasks);
            }
        }
        public List<Task> Tasks { get; }
    }
}
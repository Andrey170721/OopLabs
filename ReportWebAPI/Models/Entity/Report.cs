using System.Collections.Generic;

namespace Reports.Entity
{
    public class Report
    {
        public Report(List<Task> tasks, Employee employee)
        {
            Employee = employee;
            Tasks = tasks;
        }

        public Employee Employee { get; }
        public List<Task> Tasks { get; }
    }
}
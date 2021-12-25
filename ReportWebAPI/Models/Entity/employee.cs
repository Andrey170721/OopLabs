using System.Collections.Generic;
using Reports.Tools;

namespace Reports.Entity
{
    public class Employee
    {
        public Employee(string name)
        {
            Name = name;
            Subordinates = new List<Employee>();
        }
        public List<Employee> Subordinates { get; }
        public string Name { get; }

        public void AddSubordinate(Employee employee)
        {
            if (Subordinates.Exists(s => s == employee)) throw new ReportException("subordinate already added");
            Subordinates.Add(employee);
        }
    }
}
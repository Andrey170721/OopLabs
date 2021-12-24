using Reports.Tools;

namespace Reports.Entity
{
    public class Task
    {
        public Task(string name, Employee employee)
        {
            Name = name;
            Status = Status.Open;
            Employee = employee;

        }
        public string Name { get; }
        public Status Status { get; private set; }
        public string Comment { get; private set; }
        public Employee Employee { get; private set; }

        public void AddComment(string comment)
        {
            Comment = comment;
        }

        public void ChangeStatus(Status status)
        {
            Status = status;
        }
        public void ChangeEmployee(Employee employee)
        {
            Employee = employee;
        }
    }
}
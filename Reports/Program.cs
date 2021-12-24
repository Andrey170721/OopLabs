using Reports.Entity;
using Reports.Services;
using Reports.Tools;

namespace Reports
{
    internal class Program
    {
        public static void Main()
        {
            TaskService taskService = new TaskService("Matvey");
            Employee employee1 = taskService.AddNewEmployee("Andrey");
            Employee employee2 = taskService.AddNewEmployee("Ivan");
            Task task1 = taskService.AddNewTask("протестировать Report", employee1, "тестируй");
            Task task2 = taskService.AddNewTask("тоже самое", employee2);
            taskService.ChangeStatus(Status.Resolved, task2);
            taskService.ChangeStatus(Status.Active, task1);
            taskService.MakeReport(employee1);
            taskService.MakeReport(employee2);
            SprintReport sprintReport = taskService.MakeSprintReport();
        }
    }
}
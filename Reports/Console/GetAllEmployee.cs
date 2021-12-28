using System.Collections.Generic;
using Reports.Entity;
using Reports.Services;

namespace Reports.Console
{
    public class GetAllEmployee
    {
        public static int GetAll(TaskService taskService)
        {
            int count = 2;
            List<Employee> employees = taskService.GetAllEmployees();
            if (employees == null)
            {
                System.Console.WriteLine("1. " + taskService.TeamLead.Name);
                return 0;
            }
            System.Console.WriteLine("1. " + taskService.TeamLead.Name);
            foreach (var employee in employees)
            {
                System.Console.WriteLine(count + ". " + employee.Name);
                count++;
            }

            return count - 1;
        }
    }
}
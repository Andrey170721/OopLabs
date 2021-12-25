using System.Collections.Generic;
using Reports.Entity;
using Reports.Services;

namespace Reports.Console
{
    public class MakeReport
    {
        public static int Report(TaskService taskService)
        {
            System.Console.WriteLine("Choose employee");
            int Ecount = GetAllEmployee.GetAll(taskService);
            string enter = System.Console.ReadLine();
            Employee employee = null;
            List<Employee> employees = taskService.GetAllEmployees();
            for (int i = 2; i <= Ecount; i++)
            {
                string strI = i.ToString();
                if (enter == strI)
                {
                    employee = employees[i - 2];
                }
            }

            if (employee == null)
            {
                System.Console.WriteLine("Error, try again");
                return 0;
            }

            taskService.MakeReport(employee);
            System.Console.WriteLine("Report created");
            return 0;
        }
        public static int SprintReport(TaskService taskService)
        {
            taskService.MakeSprintReport();
            System.Console.WriteLine("Sprint report created");
            return 0;
        }
    }
}
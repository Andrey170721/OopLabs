using System.Collections.Generic;
using Reports.Entity;
using Reports.Services;

namespace Reports.Console
{
    public class CreateNewEmployee
    {
        public static void Create(TaskService taskService)
        {
            System.Console.WriteLine("Enter the name");
            string name = System.Console.ReadLine();
            System.Console.WriteLine("Choose head of Employee");
            int count = GetAllEmployee.GetAll(taskService);
            string enter = System.Console.ReadLine();
            List<Employee> employees = taskService.GetAllEmployees();
            for (int i = 1; i <= count; i++)
            {
                string strI = i.ToString();
                if (enter == "1")
                {
                    taskService.AddNewEmployee(name);
                    System.Console.WriteLine("Employee created");
                    break;
                }
                if (enter == strI)
                {
                    taskService.AddNewEmployee(name, employees[i - 2]);
                    System.Console.WriteLine("Employee created");
                    break;
                }
            }
        }
    }
}
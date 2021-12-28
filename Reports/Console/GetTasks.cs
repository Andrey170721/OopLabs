using System.Collections.Generic;
using Reports.Entity;
using Reports.Services;

namespace Reports.Console
{
    public class GetTasks
    {
        public static List<Task> GetAll(TaskService taskService)
        {
            List <Task> tasks = taskService.GetAllTasks();
            if (tasks == null)
            {
                System.Console.WriteLine("No one tasks");
                return null;
            }
            int count = 1;
            foreach (var task in tasks)
            {
                System.Console.WriteLine(count + ". " + task.Name);
                System.Console.WriteLine(task.Status);
                System.Console.WriteLine(task.Employee.Name);
                System.Console.WriteLine(task.Comment);
                
                count++;
            }

            return tasks;
        }

        public static List<Task> GetEmployeeTasks(TaskService taskService)
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
                return null;
            }

            List<Task> tasks = taskService.GetEmployeeTask(employee);
            if (tasks == null)
            {
                System.Console.WriteLine("No one tasks");
                return null;
            }
            int count = 1;
            foreach (var task in tasks)
            {
                System.Console.WriteLine(count + ". " + task.Name);
                System.Console.WriteLine(task.Status);
                System.Console.WriteLine(task.Employee.Name);
                System.Console.WriteLine(task.Comment);
                count++;
            }

            return tasks;
        }
    }
}
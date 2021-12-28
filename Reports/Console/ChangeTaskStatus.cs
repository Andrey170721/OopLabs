using System.Collections.Generic;
using System.Xml;
using Reports.Entity;
using Reports.Services;
using Reports.Tools;

namespace Reports.Console
{
    public class ChangeTaskStatus
    {
        public static void Change(TaskService taskService)
        {
            List<Task> tasks = GetTasks.GetAll(taskService);
            int count = 1;
            System.Console.WriteLine("Choose Task");
            string enter = System.Console.ReadLine();
            foreach (var task in tasks)
            {
                string strCount = count.ToString();
                if (enter == strCount)
                {
                    System.Console.WriteLine("Choose status");
                    System.Console.WriteLine("1. Active");
                    System.Console.WriteLine("2. Resolved");
                    enter = System.Console.ReadLine();
                    switch (enter)
                    {
                        case "1":
                            taskService.ChangeStatus(Status.Active, task);
                            System.Console.WriteLine("Status changed");
                            break;
                        case "2":
                            taskService.ChangeStatus(Status.Resolved, task);
                            System.Console.WriteLine("Status changed");
                            break;
                    }

                    break;
                } 
            }
            
        }
    }
}
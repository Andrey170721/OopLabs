using System.Collections.Generic;
using Reports.Entity;
using Reports.Services;
using Reports.Tools;

namespace Reports.Console
{
    public class ChangeComment
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
                    System.Console.WriteLine("Write new comment");
                    enter = System.Console.ReadLine();
                    taskService.AddComment(enter, task);
                    break;
                } 
            }
        }
    }
}
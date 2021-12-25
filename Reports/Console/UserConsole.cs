using System.Collections.Generic;
using Reports.Entity;
using Reports.Services;

namespace Reports.Console
{
    public class UserConsole
    {
        public static TaskService TaskService;
        public static void Run()
        {
            System.Console.WriteLine("Enter TeamLead name");
            string teamLeadName = System.Console.ReadLine();
            TaskService taskService = new TaskService(teamLeadName);
            TaskService = taskService;
            UserConsole.FuncChoose();
        }

        public static int FuncChoose()
        {
            string enter = null;
            while (enter != "4")
            {
                System.Console.WriteLine("1. Employees");
                System.Console.WriteLine("2. Tasks");
                System.Console.WriteLine("3. Reports");
                System.Console.WriteLine("4. End programm");
                enter = System.Console.ReadLine();
                switch (enter)
                {
                    case "1":
                        UserConsole.Employees();
                        break;
                    case "2":
                        UserConsole.Tasks();
                        break;
                    case "3":
                        UserConsole.Reports();
                        break;
                    case "4":
                        break;
                    default:
                        System.Console.WriteLine("Invalid input");
                        break;
                }
            }

            return 0;
        }

        public static void Employees()
        {
            string enter = null;
            while (enter != "3")
            {
                System.Console.WriteLine("1. GetAll");
                System.Console.WriteLine("2. Create");
                System.Console.WriteLine("3. Back");
                enter = System.Console.ReadLine();
                switch (enter)
                {
                    case "1":
                        GetAllEmployee.GetAll(TaskService);
                        break;
                    case "2":
                        CreateNewEmployee.Create(TaskService);
                        break;
                    case "3":
                        break;
                    default:
                        System.Console.WriteLine("Invalid input");
                        break;
                }
            }
        }

        public static void Tasks()
        {
            string enter = null;
            while (enter != "5")
            {
                System.Console.WriteLine("1. GetAll");
                System.Console.WriteLine("2. GetEmployeeTasks");
                System.Console.WriteLine("3. ChangeTaskStatus");
                System.Console.WriteLine("4. ChangeComment");
                System.Console.WriteLine("5. Back");
                enter = System.Console.ReadLine();
                switch (enter)
                {
                    case "1":
                        GetTasks.GetAll(TaskService);
                        break;
                    case "2":
                        GetTasks.GetEmployeeTasks(TaskService);
                        break;
                    case "3":
                        ChangeTaskStatus.Change(TaskService);
                        break;
                    case "4":
                        ChangeComment.Change(TaskService);
                        break;
                    case "5":
                        break;
                    default:
                        System.Console.WriteLine("Invalid input");
                        break;
                }
            }
        }

        public static void Reports()
        {
            string enter = null;
            while (enter != "4")
            {
                System.Console.WriteLine("1. Make report");
                System.Console.WriteLine("2. Make sprint report");
                System.Console.WriteLine("3. Back");
                enter = System.Console.ReadLine();
                switch (enter)
                {
                    case "1":
                        MakeReport.Report(TaskService);
                        break;
                    case "2":
                        MakeReport.SprintReport(TaskService);
                        break;
                    case "3":
                        break;
                    default:
                        System.Console.WriteLine("Invalid input");
                        break;
                }
            }
        }
    }
}
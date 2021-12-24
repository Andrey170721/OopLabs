using System;
using System.Collections.Generic;
using Reports.Entity;
using Reports.Tools;

namespace Reports.Services
{
    public class TaskService
    {
        private List<Employee> _employees = new List<Employee>();
        private List<Task> _tasks = new List<Task>();
        private List<Report> _reports = new List<Report>();
        private TeamLead TeamLead;

        public TaskService(string teamLeadName)
        {
            TeamLead = new TeamLead(teamLeadName);
        }
        public Employee AddNewEmployee(string name)
        {
            var employee = new Employee(name);
            TeamLead.AddSubordinate(employee);
            _employees.Add(employee);
            return employee;
        }

        public Employee AddNewEmployee(string name, Employee head)
        {
            var employee = new Employee(name);
            head.AddSubordinate(employee);
            _employees.Add(head);
            return employee;
        }

        public Task AddNewTask(string taskName, Employee employee, string comment)
        {
            if (_reports.Exists(r => r.Employee == employee)) throw new Exception("saved report cannot be changed");
            if (_tasks.Exists(t => t.Name == taskName)) throw new ReportException("This TaskName already Exists");
            var task = new Task(taskName, employee);
            task.AddComment(comment);
            _tasks.Add(task);
            return task;
        }
        public Task AddNewTask(string taskName, Employee employee)
        {
            if (_reports.Exists(r => r.Employee == employee)) throw new Exception("saved report cannot be changed");
            if (_tasks.Exists(t => t.Name == taskName)) throw new ReportException("This TaskName already Exists");
            var task = new Task(taskName, employee);
            _tasks.Add(task);
            return task;
        }

        public void AddComment(string comment, Task task)
        {
            if (_reports.Exists(r => r.Employee == task.Employee)) throw new Exception("saved report cannot be changed");
            task.AddComment(comment);
        }

        public void ChangeStatus(Status status, Task task)
        {
            if (_reports.Exists(r => r.Employee == task.Employee)) throw new Exception("saved report cannot be changed");
            task.ChangeStatus(status);
        }

        public Report MakeReport(Employee employee)
        {
            List<Task> tasks = _tasks.FindAll(t => t.Employee == employee);
            if (tasks.Count == 0) throw new ReportException("no tasks found for report");
            var report = new Report(tasks, employee);
            _reports.Add(report);
            return report;
        }

        public SprintReport MakeSprintReport()
        {
            if (_reports.Count != _employees.Count) throw new ReportException("not all employees have uploaded reports");
            SprintReport sprintReport = new SprintReport(_reports);
            return sprintReport;
        }
    }
}
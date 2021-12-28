using System.IO;
using BackupsExtra.Entity;

namespace BackupsExtra
{
    internal class Program
    {
        private static void Main()
        {
            BackupJobExtra backupJob = new BackupJobExtra("/Users/andrejpodvysockij/Desktop", 3, "File");
            backupJob.AddJobObject("/Users/andrejpodvysockij/Desktop/Files/File A.txt");
            backupJob.AddJobObject("/Users/andrejpodvysockij/Desktop/Files/File C.txt");
            backupJob.CreateRestorePoint("Split");
            backupJob.RemoveJobObject("/Users/andrejpodvysockij/Desktop/Files/File C.txt");
            backupJob.CreateRestorePoint("Split");
            backupJob.CreateRestorePoint("Split");
            backupJob.CreateRestorePoint("Split");
        }
    }
}

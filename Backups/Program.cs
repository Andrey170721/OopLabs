using System.IO;
using Backups.Entity;

namespace Backups
{
    internal class Program
    {
        private static void Main()
        {
             BackupJob backupJob = new BackupJob("/Users/andrejpodvysockij/Desktop");
             backupJob.AddJobObject("/Users/andrejpodvysockij/Desktop/Files/File A.txt");
             backupJob.AddJobObject("/Users/andrejpodvysockij/Desktop/Files/File C.txt");
             backupJob.CreateRestorePoint("Split");
             backupJob.CreateRestorePoint("Single");
             backupJob.AddJobObject("/Users/andrejpodvysockij/Desktop/Files/File B.txt");
             backupJob.RemoveJobObject("/Users/andrejpodvysockij/Desktop/Files/File A.txt");
             backupJob.CreateRestorePoint("Split");
        }
    }
}

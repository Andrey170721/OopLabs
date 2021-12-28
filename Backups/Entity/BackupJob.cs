using System;
using System.Collections.Generic;
using System.IO;
using Backups.Repositories;
using Backups.Tools;

namespace Backups.Entity
{
    public class BackupJob
    {
        public BackupJob(string path)
        {
            Path = path + "/Backup";
            Id = 0;
            JobObjects = new List<string>();
            FileStorage = new FileStorageRepository();
            RestorePoints = new List<RestorePoint>();
            Storages = new List<Storage>();
        }

        public int Id { get; set; }
        public List<string> JobObjects { get; }
        public FileStorageRepository FileStorage { get; }
        public List<RestorePoint> RestorePoints { get; }
        public List<Storage> Storages { get; }
        public string Path { get; }
        public void AddJobObject(string fileName)
        {
            JobObjects.Add(fileName);
        }

        public void RemoveJobObject(string fileName)
        {
            JobObjects.Remove(fileName);
        }

        public void CreateRestorePoint(string algorithm)
        {
            var newPoint = new RestorePoint(JobObjects, Id);
            Storage storage;
            if (algorithm == "Split")
            {
                storage = new Storage(FileStorage.CreateSplitStorage(JobObjects, Path), Id);
            }
            else if (algorithm == "Single")
            {
                storage = new Storage(FileStorage.CreateSingleStorage(JobObjects, Path), Id);
            }
            else
            {
                throw new BackupsException("invalid storage algorithm");
            }

            Id++;
            Storages.Add(storage);
            RestorePoints.Add(newPoint);
        }
    }
}
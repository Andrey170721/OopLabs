using System;
using System.Collections.Generic;
using System.IO;
using Backups.Repositories;
using Backups.Tools;

namespace Backups.Entity
{
    public class BackupJob
    {
        protected int _id = 0;
        protected List<string> jobObjects = new List<string>();
        protected FileStorageRepository fileStorage = new FileStorageRepository();
        protected List<RestorePoint> _restorePoints = new List<RestorePoint>();
        protected List<Storage> _storages = new List<Storage>();

        public BackupJob(string path)
        {
            Path = path + "/Backup";
        }

        public string Path { get; }
        public void AddJobObject(string fileName)
        {
            jobObjects.Add(fileName);
        }

        public void RemoveJobObject(string fileName)
        {
            jobObjects.Remove(fileName);
        }

        public void CreateRestorePoint(string algorithm)
        {
            var newPoint = new RestorePoint(jobObjects, _id);
            Storage storage;
            if (algorithm == "Split")
            {
                storage = new Storage(fileStorage.CreateSplitStorage(jobObjects, Path), _id);
            }
            else if (algorithm == "Single")
            {
                storage = new Storage(fileStorage.CreateSingleStorage(jobObjects, Path), _id);
            }
            else
            {
                throw new BackupsException("invalid storage algorithm");
            }

            _id++;
            _storages.Add(storage);
            _restorePoints.Add(newPoint);
        }
    }
}
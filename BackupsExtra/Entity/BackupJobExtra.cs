using System;
using Backups.Entity;
using Backups.Repositories;
using BackupsExtra.Repositories;
using BackupsExtra.Tools;

namespace BackupsExtra.Entity
{
    public class BackupJobExtra : BackupJob
    {
        private int _maxNumberOfRestorePoints;
        private string _logerType;
        public BackupJobExtra(string path, int maxNumberOfRestorePoints, string logerType)
            : base(path)
        {
            FileStorage = new FileStorageRepositoryExtra();
            _maxNumberOfRestorePoints = maxNumberOfRestorePoints;
            if (!(logerType == "Console" || logerType == "File"))
            {
                throw new BackupsExtraException("InvalidLogerType");
            }

            _logerType = logerType;
        }

        public new FileStorageRepositoryExtra FileStorage { get; }

        public new void CreateRestorePoint(string algorithm)
        {
            var newPoint = new RestorePoint(JobObjects, Id);
            Storage storage;
            if (algorithm == "Split")
            {
                storage = new Storage(FileStorage.CreateSplitStorage(JobObjects, Path), Id);
                string message = "Split storage created:" + storage.Path;
                Loger.WriteLog(message, _logerType);
            }
            else if (algorithm == "Single")
            {
                storage = new Storage(FileStorage.CreateSingleStorage(JobObjects, Path), Id);
                string message = "Single storage created:" + storage.Path;
                Loger.WriteLog(message, _logerType);
            }
            else
            {
                throw new BackupsExtraException("invalid storage algorithm");
            }

            Id++;
            Storages.Add(storage);
            RestorePoints.Add(newPoint);
            FileStorage.CleanPoints(_maxNumberOfRestorePoints, Storages, _logerType);
        }

        public void Recover(Storage restorePoint, string restorePath)
        {
            FileStorage.Recover(restorePoint, restorePath);
            string message = "Recover restore point: " + restorePoint.Path + " in directory " + restorePath;
            Loger.WriteLog(message, _logerType);
        }
    }
}
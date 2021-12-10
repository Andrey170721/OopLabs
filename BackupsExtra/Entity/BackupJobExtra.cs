using System;
using Backups.Entity;
using Backups.Repositories;
using BackupsExtra.Repositories;
using BackupsExtra.Tools;

namespace BackupsExtra.Entity
{
    public class BackupJobExtra : BackupJob
    {
        private new FileStorageRepositoryExtra fileStorage = new FileStorageRepositoryExtra();
        private int _maxNumberOfRestorePoints;
        private string _logerType;
        public BackupJobExtra(string path, int maxNumberOfRestorePoints, string logerType)
            : base(path)
        {
            _maxNumberOfRestorePoints = maxNumberOfRestorePoints;
            if (!(logerType == "Console" || logerType == "File"))
            {
                throw new BackupsExtraException("InvalidLogerType");
            }

            _logerType = logerType;
        }

        public new void CreateRestorePoint(string algorithm)
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
                throw new BackupsExtraException("invalid storage algorithm");
            }

            _id++;
            _storages.Add(storage);
            _restorePoints.Add(newPoint);
            fileStorage.CleanPoints(_maxNumberOfRestorePoints, _storages);
        }

        public void Recover(Storage restorePoint, string restorePath)
        {
            
        }
    }
}
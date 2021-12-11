using System.Collections.Generic;
using System.IO;
using System.Linq;
using Backups.Entity;
using Backups.Repositories;
using BackupsExtra.Entity;

namespace BackupsExtra.Repositories
{
    public class FileStorageRepositoryExtra : FileStorageRepository
    {
        public bool CleanPoints(int maxNumberOfRestorePoints, List<Storage> restorePoints, string logerType)
        {
            int count = 0;
            Storage mergePoint = null;
            Storage oldPoint = null;
            foreach (Storage restorePoint in restorePoints)
            {
                count++;
                if (count == 2)
                {
                    mergePoint = restorePoint;
                }

                if (count == 1)
                {
                    oldPoint = restorePoint;
                }

                if (count > maxNumberOfRestorePoints)
                {
                    MergeRestorePoints(mergePoint, oldPoint);
                    restorePoints.Remove(oldPoint);
                    string message = "Restore point: " + oldPoint.Path + " merged with " + mergePoint.Path;
                    Loger.WriteLog(message, logerType);
                    return true;
                }
            }

            return true;
        }

        public bool MergeRestorePoints(Storage newPoint, Storage oldPoint)
        {
            FileAttributes attr = File.GetAttributes(newPoint.Path);
            FileAttributes attr2 = File.GetAttributes(oldPoint.Path);
            if (!(attr.HasFlag(FileAttributes.Directory) || attr2.HasFlag(FileAttributes.Directory)))
            {
                Directory.Delete(oldPoint.Path);
                return true;
            }

            var newFiles1 = Directory.GetFiles(newPoint.Path);
            var oldFiles2 = Directory.GetFiles(oldPoint.Path);
            List<string> newFiles = newFiles1.ToList();
            List<string> oldFiles = oldFiles2.ToList();
            foreach (var oldFile in oldFiles)
            {
                string destFile = newPoint.Path + "/" + Path.GetFileName(oldFile);
                if (!newFiles.Exists(f => Path.GetFileName(f) == Path.GetFileName(oldFile)))
                {
                    File.Copy(oldFile, destFile);
                }
            }

            Directory.Delete(oldPoint.Path, true);
            return true;
        }

        public void Recover(Storage restorePoint, string restorePath)
        {
            var arrFiles = Directory.GetFiles(restorePoint.Path);
            List<string> files = arrFiles.ToList();
            foreach (var file in files)
            {
                File.Copy(file, restorePath);
            }
        }
    }
}
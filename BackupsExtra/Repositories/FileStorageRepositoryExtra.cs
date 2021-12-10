using System.Collections.Generic;
using System.IO;
using System.Linq;
using Backups.Entity;
using Backups.Repositories;

namespace BackupsExtra.Repositories
{
    public class FileStorageRepositoryExtra : FileStorageRepository
    {
        public void CleanPoints(int maxNumberOfRestorePoints, List<Storage> restorePoints)
        {
            int count = 0;
            Storage mergePoint = null;
            foreach (var restorePoint in restorePoints)
            {
                count++;
                if (count == maxNumberOfRestorePoints)
                {
                    mergePoint = restorePoint;
                }

                if (count > maxNumberOfRestorePoints)
                {
                    MergeRestorePoints(mergePoint, restorePoint);
                    restorePoints.Remove(restorePoint);
                }
            }
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
                string destFile = newPoint.Path + Path.GetFileName(oldFile);
                if (!newFiles.Exists(f => f == oldFile))
                {
                    File.Copy(oldFile, destFile);
                }
            }

            Directory.Delete(oldPoint.Path);
            return true;
        }

        public void Recover(Storage restorePoint, string restorePath)
        {
            
        }
    }
}
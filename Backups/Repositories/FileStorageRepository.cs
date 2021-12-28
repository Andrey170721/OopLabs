using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace Backups.Repositories
{
    public class FileStorageRepository
    {
        private int _storageNum = 1;
        public string CreateSplitStorage(List<string> files, string path)
        {
            string directoryName = path + "/" + "RestorePoint_" + _storageNum;
            _storageNum++;
            Directory.CreateDirectory(directoryName);
            foreach (string sourceFile in files)
            {
                string name = Path.GetFileName(sourceFile);
                string destFileName = directoryName + "/" + name;
                File.Copy(sourceFile, destFileName);
            }

            return directoryName;
        }

        public string CreateSingleStorage(List<string> files, string path)
        {
            string directoryName = path + "/" + "RestorePoint_" + _storageNum;
            _storageNum++;
            Directory.CreateDirectory(directoryName);
            foreach (string sourceFile in files)
            {
                string name = Path.GetFileName(sourceFile);
                string destFileName = directoryName + "/" + name;
                File.Copy(sourceFile, destFileName);
            }

            string zipFileName = directoryName + "_zip";
            ZipFile.CreateFromDirectory(directoryName, zipFileName);
            Directory.Delete(directoryName, true);
            return zipFileName;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace Backups.Repositories
{
    public class FileStorageRepository
    {
        private int _storageNum = 1;
        public string CreateSplitStorage(List<string> lines, string path)
        {
            int fileNum = 1;
            string directoryName = path + "/" + "RestorePoint_" + _storageNum;
            _storageNum++;
            Directory.CreateDirectory(directoryName);
            foreach (string line in lines)
            {
                string fileName = path + "/" + "file_" + fileNum;
                File.Copy(path, fileName);
                fileNum++;
            }

            return directoryName;
        }

        public string CreateSingleStorage(List<string> lines, string path)
        {
            int fileNum = 1;
            string directoryName = path + "/" + "RestorePoint_" + _storageNum;
            _storageNum++;
            Directory.CreateDirectory(directoryName);
            foreach (string line in lines)
            {
                string fileName = path + "/" + "file_" + fileNum;
                File.Copy(path, fileName);
                fileNum++;
            }

            string zipFileName = directoryName + "_zip";
            ZipFile.CreateFromDirectory(directoryName, zipFileName);
            File.Delete(directoryName);
            return zipFileName;
        }
    }
}

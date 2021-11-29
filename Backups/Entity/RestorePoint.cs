using System.Collections.Generic;

namespace Backups.Entity
{
    public class RestorePoint
    {
        private List<string> _objects;
        public RestorePoint(List<string> lines, int id)
        {
            Id = id;
            _objects = lines;
        }

        public int Id { get; }
    }
}
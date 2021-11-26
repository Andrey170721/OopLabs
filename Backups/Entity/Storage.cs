namespace Backups.Entity
{
    public class Storage
    {
        public Storage(string path, int id)
        {
            Path = path;
            Id = id;
        }

        public string Path { get; }
        public int Id { get; }
    }
}
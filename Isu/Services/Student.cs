namespace Isu.Services
{
    public class Student
    {
        private static int id = 0;
        public Student(string name, GroupName newGroup)
        {
            id++;
            ID = id;
            Name = name;
            GroupName = newGroup;
        }

        public int ID { get; }
        public string Name { get; }
        public GroupName GroupName { get; private set; }

        public void ChangeGroup(GroupName newGroup)
        {
            GroupName = newGroup;
        }
    }
}
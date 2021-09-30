namespace Isu.Services
{
    public class Student
    {
        public Student(int id, string name, GroupName newGroup)
        {
            Id = id;
            Name = name;
            GroupName = newGroup;
        }

        public int Id { get; }
        public string Name { get; }
        public GroupName GroupName { get; private set; }

        public void ChangeGroup(GroupName newGroup)
        {
            GroupName = newGroup;
        }
    }
}
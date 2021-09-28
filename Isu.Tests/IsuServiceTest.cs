using Isu.Services;
using Isu.Tools;
using NUnit.Framework;

namespace Isu.Tests
{
    public class Tests
    {
        private IIsuService _isuService;

        [SetUp]
        public void Setup()
        {
            _isuService = new IsuService();
        }

        [Test]
        public void AddStudentToGroup_StudentHasGroupAndGroupContainsStudent()
        {
            var name1 = new GroupName("M3211");
            Group group1 = _isuService.AddGroup(name1);
            Student student1 = _isuService.AddStudent(group1, "IVAN");
            Assert.Contains(student1, group1.Students);
            Assert.AreEqual(group1.GroupName, student1.GroupName);
        }

        [Test]
        public void ReachMaxStudentPerGroup_ThrowException()
        {
            Assert.Catch<IsuException>(() =>
            {
                var name1 = new GroupName("M3211");
                Group group1 = _isuService.AddGroup(name1);
                Student student1 = _isuService.AddStudent(group1, "IVAN");
                Student student2 = _isuService.AddStudent(group1, "VASYA");
                Student student3 = _isuService.AddStudent(group1, "ANNA");
                Student student4 = _isuService.AddStudent(group1, "PETYA");
                Student student5 = _isuService.AddStudent(group1, "VOVA");
                Student student6 = _isuService.AddStudent(group1, "NATASHA");
            });
        }

        [Test]
        public void CreateGroupWithInvalidName_ThrowException()
        {
            Assert.Catch<IsuException>(() =>
            {
                GroupName name1 = new GroupName("M321123432");
                Group group1 = _isuService.AddGroup(name1);
            });
        }

        [Test]
        public void TransferStudentToAnotherGroup_GroupChanged()
        { 
            GroupName name1 = new GroupName("M3211");
            GroupName name2 = new GroupName("M3111");
            Group group1 = _isuService.AddGroup(name1);
            Group group2 = _isuService.AddGroup(name2);
            Student student1 = _isuService.AddStudent(group1, "IVAN");
            _isuService.ChangeStudentGroup(student1, group2);
            Assert.Contains(student1, group2.Students);
        }
    }
}
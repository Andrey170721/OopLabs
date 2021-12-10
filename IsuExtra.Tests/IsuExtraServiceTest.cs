using System;
using IsuExtra.Entity;
using IsuExtra.Services;
using NUnit.Framework;

namespace IsuExtra.Tests
{
    public class IsuExtraServiceTest
    {
        private IsuExtraService _isuService;

        [SetUp]
        public void Setup()
        {
            _isuService = new IsuExtraService();
        }

        [Test]
        public void AddStudentToOgnp()
        {
            ExtraGroupName groupName = new ExtraGroupName("M3211");
            Timetable timetable1 = new Timetable();
            Timetable timetable2 = new Timetable();
            timetable1.AddNewCouple(DayOfWeek.Friday, 18, 20);
            timetable1.AddNewCouple(DayOfWeek.Monday, 18, 20);
            ExtraGroup group = _isuService.AddGroup(groupName, 4, timetable1);
            ExtraStudent student = _isuService.AddStudent(group, "IVAN");
            OGNP ognp = _isuService.AddNewOgnp("E");
            ognp.AddNewStream(timetable2, 4);
            _isuService.AddStudentToOGNP(student, ognp);
        }

        [Test]
        public void ReachMaxStudentPerGroup_ThrowException()
        {
            
        }

        [Test]
        public void CreateGroupWithInvalidName_ThrowException()
        {
            
        }

        [Test]
        public void TransferStudentToAnotherGroup_GroupChanged()
        { 
            
        }
    }
}
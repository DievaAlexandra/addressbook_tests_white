using System;
using System.Collections.Generic;
using NUnit.Framework;


namespace addressbook_tests_white
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void TestGroupRemove()
        {
            GroupData newGroup = new GroupData(){Name = "white"};

            int groupcount = app.Groups.GetGroupList().Count;

            if (groupcount <= 1) //условие, если кол-во групп меньше или равно 1, то создать группу
            {
                app.Groups.Add(newGroup);
            }

            List<GroupData> oldGroups = app.Groups.GetGroupList();//получили старый список групп

            app.Groups.Remove(0);

            List<GroupData> newGroups = app.Groups.GetGroupList();//получили новый список групп

            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
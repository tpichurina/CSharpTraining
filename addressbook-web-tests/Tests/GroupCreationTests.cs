﻿using NUnit.Framework;
using System.Collections.Generic;

namespace webAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)

                });
            }
            return groups;
        }

        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void GroupCreationTest(GroupData group)
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        ////[Test]
        ////public void BadNemeGroupCreationTest()
        ////{
        ////    GroupData group = new GroupData("a'a");
        ////    group.Header = "";
        ////    group.Footer = "";

        ////    List<GroupData> oldGroups = app.Groups.GetGroupList();

        ////    app.Groups.Create(group);

        //List<GroupData> newGroups = app.Groups.GetGroupList();
        //oldGroups.Add(group);
        //    oldGroups.Sort();
        //    newGroups.Sort();
        //    Assert.AreEqual(oldGroups, newGroups);
        ////}

    }
}

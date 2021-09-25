using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace webAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestbase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("testname")
            {
                Header = null,
                Footer = null
            };

            if (!app.Groups.IsElementPresent(By.Name("selected[]")))
            {
                app.Groups.Create(newData);
            }

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toModifi = oldGroups[0];

            toModifi.Name = newData.Name;

            app.Groups.Modify(toModifi);

            List<GroupData> newGroups = GroupData.GetAll();

            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}

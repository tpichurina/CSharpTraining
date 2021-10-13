using System.Collections.Generic;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : TestBase
    {

        [Test]
        public void ProjectCreatiomTest()
        {
            ProjectData project = new ProjectData() { Name = "test" };
            AccountData account = new AccountData("administrator", "root");

            List<ProjectData> oldList = app.API.GetAllProjects(account);

            app.API.CreateNewProject(account, project);

            List<ProjectData> newList = app.API.GetAllProjects(account);

            oldList.Add(project);

            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}

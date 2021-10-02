using System.Collections.Generic;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectRemovalTests : AuthTestBase
    {
        [Test]
        public void TestProjectRemoval()
        {

            AccountData account = new AccountData("administrator", "root");
            List<ProjectData> oldList = app.API.GetAllProjects(account);

            if (oldList.Count < 1)
            {
                ProjectData project = new ProjectData() { Name = "test" };

                app.API.CreateNewProject(account, project);
            }

            oldList = app.API.GetAllProjects(account);
            ProjectData projectToRemove = oldList[0];

            app.API.RemoveProject(account, projectToRemove);

            List<ProjectData> newList = app.API.GetAllProjects(account);

            oldList.Remove(projectToRemove);

            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}

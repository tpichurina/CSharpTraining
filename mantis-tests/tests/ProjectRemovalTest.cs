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

            List<ProjectData> oldList = app.Project.GetAllProjects();

            if (oldList.Count < 1)
            {
                ProjectData project = new ProjectData()
                {
                    Name = "test1",
                };

                app.Project.Create(project);
            }

            oldList = app.Project.GetAllProjects();
            ProjectData projectToRemove = oldList[0];

            app.Project.RemoveProject(projectToRemove);

            List<ProjectData> newList = app.Project.GetAllProjects();

            oldList.Remove(projectToRemove);

            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}

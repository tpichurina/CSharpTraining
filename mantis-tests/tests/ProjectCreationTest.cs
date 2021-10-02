using System.Collections.Generic;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : AuthTestBase
    {

        [Test]
        public void ProjectCreatiomTest()
        {
            List<ProjectData> oldList = app.Project.GetAllProjects();

            ProjectData project = new ProjectData()
            {
                Name = "test",
            };

            ProjectData duplicateProjectName = oldList.Find(p => p.Name == project.Name);
            if (duplicateProjectName != null)
            {
                app.Project.RemoveProject(duplicateProjectName);
            }

            oldList = app.Project.GetAllProjects();
            app.Project.Create(project);

            List<ProjectData> newList = app.Project.GetAllProjects();

            oldList.Add(project);

            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}

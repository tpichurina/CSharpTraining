using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class APIHelper : BaseHelper
    {
        private Task<Mantis.ProjectData[]> projectArr;

        public APIHelper(ApplicationManager manager) : base(manager)
        {

        }

        public void CreateNewProject(AccountData account, ProjectData projectData)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData project = new Mantis.ProjectData();
            project.name = projectData.Name;
            client.mc_project_addAsync(account.Username, account.Password, project);
        }

        public List<ProjectData> GetAllProjects(AccountData account)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            List<ProjectData> projectList = new List<ProjectData>();
            projectArr = client.mc_projects_get_user_accessibleAsync(account.Username, account.Password);

            foreach (ProjectData pr in projectList)
            {
                ProjectData project = new ProjectData();
                project.Name = pr.Name;
                project.Id = pr.Id;
                projectList.Add(project);
            }
            return projectList;
        }

        public void RemoveProject(AccountData account, ProjectData project)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData projectToRemove = new Mantis.ProjectData();
            projectToRemove.id = project.Id;
            client.mc_project_deleteAsync(account.Username, account.Password, project.Id);
        }
    }

}

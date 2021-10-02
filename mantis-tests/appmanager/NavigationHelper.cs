﻿namespace mantis_tests
{
    public class NavigationHelper : BaseHelper
    {
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager) { this.baseURL = baseURL; }

        public void OpenLoginPage()
        {
            if (driver.Url == baseURL + "/login_page.php")
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + "/login_page.php");
        }

        public void OpenProjectsPage()
        {
            if (driver.Url == baseURL + "/manage_proj_page.php")
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + "/manage_proj_page.php");
        }
        public void OpenProjectEditPage(ProjectData project)
        {
            if (driver.Url == baseURL + "/manage_proj_edit_page.php?project_id=" + project.Id)
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + "/manage_proj_edit_page.php?project_id=" + project.Id);
        }

        public void OpenLogoutPage()
        {
            driver.Navigate().GoToUrl(baseURL + "/logout_page.php");
        }
    }
}

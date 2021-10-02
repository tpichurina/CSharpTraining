using OpenQA.Selenium;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace mantis_tests
{
    public class ProjectHelper : BaseHelper
    {
        public ProjectHelper(ApplicationManager manager) : base(manager) { }

        public void Create(ProjectData project)
        {
            manager.Navigate.OpenProjectsPage();
            InitiateProjectCreation();
            FillProjectForm(project);
            SubmitProjectCreation();
        }

        public List<ProjectData> GetAllProjects()
        {
            manager.Navigate.OpenProjectsPage();
            List<ProjectData> projects = new List<ProjectData>();
            IWebElement table = driver.FindElement(By.CssSelector(".widget-box"));
            IList<IWebElement> rows = table.FindElements(By.CssSelector("table tbody tr"));
            foreach (IWebElement row in rows)
            {
                IWebElement link = row.FindElement(By.TagName("a"));
                string title = link.Text;
                string href = link.GetAttribute("href");
                Match m = Regex.Match(href, @"\d+$");
                string id = m.Value;
                projects.Add(new ProjectData()
                {
                    Name = title,
                    Id = id
                });

            }
            return projects;
        }

        public void SubmitProjectCreation()
        {
            driver.FindElement(By.XPath("//form[@id='manage-project-create-form']/div/div[3]/input")).Click();
        }

        public void FillProjectForm(ProjectData project)
        {
            driver.FindElement(By.Id("project-name")).Click();
            driver.FindElement(By.Id("project-name")).Clear();
            driver.FindElement(By.Id("project-name")).SendKeys(project.Name);
        }

        public void InitiateProjectCreation()
        {
            driver.FindElement(By.CssSelector(".form-inline.inline.single-button-form")).Click();
        }

        public void RemoveProject(ProjectData project)
        {
            manager.Navigate.OpenProjectEditPage(project);
            driver.FindElement(By.CssSelector("input.btn.btn-primary.btn-sm.btn-white.btn-round")).Click();
            driver.FindElement(By.CssSelector("input.btn.btn-primary.btn-white.btn-round")).Click();
        }
    }
}

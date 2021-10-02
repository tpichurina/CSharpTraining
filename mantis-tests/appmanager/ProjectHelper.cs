using OpenQA.Selenium;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace mantis_tests
{
    public class ProjectHelper : BaseHelper
    {
        public ProjectHelper(ApplicationManager manager) : base(manager) { }

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

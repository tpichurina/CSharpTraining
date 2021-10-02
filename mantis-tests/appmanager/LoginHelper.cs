using OpenQA.Selenium;

namespace mantis_tests
{
    public class LoginHelper : BaseHelper
    {
        public LoginHelper(ApplicationManager manager) : base(manager) { }

        public void LoginAsUser(AccountData account)
        {
            manager.Navigate.OpenLoginPage();
            driver.FindElement(By.Name("username")).Clear();
            driver.FindElement(By.Name("username")).SendKeys(account.Username);
            driver.FindElement(By.XPath("//form[@id='login-form']/fieldset/input[2]")).Click();
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys(account.Password);
            driver.FindElement(By.XPath("//form[@id='login-form']/fieldset/input[3]")).Click();
        }
    }
}

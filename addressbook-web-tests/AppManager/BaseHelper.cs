using OpenQA.Selenium;

namespace webAddressbookTests
{
    public class BaseHelper
    {
        public IWebDriver driver;
        public ApplicationManager manager;
        public BaseHelper(ApplicationManager manager)
        {
            this.manager = manager;
            this.driver = manager.Driver;
        }

        public BaseHelper(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Type(By locator, string text)
        {
            if (text != null)
            {
                driver.FindElement(locator).Clear();
                driver.FindElement(locator).SendKeys(text);
            }
        }
        public bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}

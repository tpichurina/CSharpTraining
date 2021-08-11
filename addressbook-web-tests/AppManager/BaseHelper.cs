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

    }
}

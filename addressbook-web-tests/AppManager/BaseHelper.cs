using OpenQA.Selenium;

namespace webAddressbookTests
{
    public class BaseHelper
    {
        protected IWebDriver driver;
        public BaseHelper(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}

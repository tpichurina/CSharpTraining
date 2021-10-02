using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Threading;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace mantis_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;
        protected LoginHelper loginHelper;
        protected NavigationHelper navigationHelper;
        protected ProjectHelper projectHelper;

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            new DriverManager().SetUpDriver(new FirefoxConfig());

            driver = new FirefoxDriver();
            baseURL = "http://localhost/mantisbt-2.25.2";
            Login = new LoginHelper(this);
            Project = new ProjectHelper(this);
            Navigate = new NavigationHelper(this, baseURL);
            API = new APIHelper(this);
        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
            }
        }

        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url = newInstance.baseURL + "/login_page.php";
                app.Value = newInstance;
            }
            return app.Value;
        }

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }
        public LoginHelper Login { get { return loginHelper; } set { loginHelper = value; } }
        public ProjectHelper Project { get { return projectHelper; } set { projectHelper = value; } }
        public NavigationHelper Navigate { get { return navigationHelper; } set { navigationHelper = value; } }
        public APIHelper API { get; }
    }
}

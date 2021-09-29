using NUnit.Framework;


namespace address_book_tests_autoit
{
    public class TestBase
    {
        public ApplicationManager app;

        [OneTimeSetUp]
        public void initApplication()
        {
            app = new ApplicationManager();
        }

        [OneTimeTearDown]

        public void stopApplication()
        {
            app.Stop();
        }
    }
}

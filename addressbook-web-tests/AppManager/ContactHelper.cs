using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace webAddressbookTests
{
    public class ContactHelper : BaseHelper
    {
        private string baseURL;

        public ContactHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.OpenHomePage();

            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllEmails = allEmails,
                AllPhones = allPhones
            };
        }

        public string GetContactInformationFromDetails(int index)
        {
            manager.Navigator.OpenHomePage();
            OpenDetailsPage(0);

            var text = driver.FindElement(By.Id("content")).Text;
            return text;
        }

        public void OpenDetailsPage(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
            .FindElements(By.TagName("td"))[6]
            .FindElement(By.TagName("a")).Click();
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.OpenHomePage();
            InitContactModification(0);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhome = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhome = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhome = driver.FindElement(By.Name("work")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                HomePhone = homePhome,
                MobilePhone = mobilePhome,
                WorkPhone = workPhome,
                Email = email,
                Email2 = email2,
                Email3 = email3
            };
        }

        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper Create(ContactData contact)
        {
            InitContactCreation();
            FillContactForm(contact);
            SubmitAccountCreation();
            return this;
        }

        private List<ContactData> contactCashe = null;

        public List<ContactData> GetContactList()
        {
            if (contactCashe == null)
            {
                contactCashe = new List<ContactData>();

                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
                foreach (IWebElement element in elements)
                {
                    var lastName = element.FindElement(By.CssSelector("td:nth-child(2)")).Text;
                    var firstName = element.FindElement(By.CssSelector("td:nth-child(3)")).Text;

                    contactCashe.Add(new ContactData(firstName, lastName)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
            }
            return new List<ContactData>(contactCashe);
        }
        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("lastname"), contact.LastName);
            Type(By.Name("nickname"), contact.Nickname);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            return this;
        }

        public ContactHelper Modify(ContactData newData)
        {
            InitContactModification(0);
            FillContactForm(newData);
            SubmitContactModification();
            return this;
        }

        public ContactHelper SubmitAccountCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            contactCashe = null;
            return this;
        }

        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCashe = null;
            return this;
        }

        public ContactHelper InitContactModification(int index)
        {
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElements(By.Name("selected[]"))[index - 1].Click();
            return this;
        }
        public ContactHelper RemoveContact(int v, bool acceptNextAlert)
        {
            SelectContact(v);
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(acceptNextAlert), "^Delete 1 addresses[\\s\\S]$"));
            contactCashe = null;
            return this;
        }

        private string CloseAlertAndGetItsText(bool acceptNextAlert)
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }

        public string CleanUpAllContactData(string text)
        {
            if (text == null || text == "")
            {
                return "";
            }
            return Regex.Replace(text, "[ -()MHW:\\r\\n]", "");
        }
        public int GetNumberOfSearchResults()
        {
            manager.Navigator.OpenHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return int.Parse(m.Value);
        }

    }
}

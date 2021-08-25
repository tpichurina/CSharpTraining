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
            InitContactModification();
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

        public ContactHelper InitContactModification()
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
    }
}

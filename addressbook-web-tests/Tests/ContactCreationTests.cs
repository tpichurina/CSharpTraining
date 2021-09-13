using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;


namespace webAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(10), GenerateRandomString(10))
                {
                    Title = GenerateRandomString(10),
                    Company = GenerateRandomString(30),
                    Nickname = GenerateRandomString(30)
                });
            }
            return contacts;
        }

        public static IEnumerable<ContactData> ContactDataFromCsvFile()
        {
            List<ContactData> contacts = new List<ContactData>();
            string path = TestContext.CurrentContext.TestDirectory;
            string[] lines = File.ReadAllLines(path + "\\contacts.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                contacts.Add(new ContactData(parts[0], parts[1])
                {
                    Title = parts[2],
                    Company = parts[3],
                    Nickname = parts[4]

                });
            }
            return contacts;
        }
        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            string path = TestContext.CurrentContext.TestDirectory;
            return (List<ContactData>)
                new XmlSerializer(typeof(List<ContactData>))
                   .Deserialize(new StreamReader(path + "\\contacts.xml"));
        }
        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            string path = TestContext.CurrentContext.TestDirectory;
            return JsonConvert.DeserializeObject<List<ContactData>>(
                File.ReadAllText(path + "\\contacts.json"));
        }

        [Test, TestCaseSource("ContactDataFromXmlFile")]
        public void ContactCreationTest(ContactData contact)
        {
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);
            app.Navigator.ReturnToHomePage();

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}

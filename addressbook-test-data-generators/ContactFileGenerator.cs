using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using webAddressbookTests;

namespace addressbook_test_data_generators
{
    static class ContactFileGenerator
    {
        public static void Generator(int count, string format, StreamWriter writer)
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < count; i++)
            {
                contacts.Add(new ContactData(TestBase.GenerateRandomString(10)
                    , TestBase.GenerateRandomString(10))
                {
                    Title = TestBase.GenerateRandomString(10),
                    Company = TestBase.GenerateRandomString(30),
                    Nickname = TestBase.GenerateRandomString(30)
                });
            }

            if (format == "csv")
            {
                writeContactsToCsvFile(contacts, writer);
            }
            else if (format == "xml")
            {
                writeContactsToXmlFile(contacts, writer);
            }
            else if (format == "json")
            {
                writeContactsToJsonFile(contacts, writer);
            }
            else
            {
                System.Console.Out.Write("Unrecognized format" + format);
            }
            writer.Close();
        }
        static void writeContactsToCsvFile(List<ContactData> contacts, StreamWriter writer)
        {
            foreach (ContactData contact in contacts)
            {
                writer.WriteLine(string.Format("${0},${1},${2},${3},${4}",
                    contact.FirstName, contact.LastName, contact.Title, contact.Company, contact.Nickname));
            }
        }
        static void writeContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }
        static void writeContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }
    }
}

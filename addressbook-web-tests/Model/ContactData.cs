using System;
using System.Collections.Generic;
using LinqToDB.Mapping;
using System.Linq;
using System.Text.RegularExpressions;


namespace webAddressbookTests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private object allEmails;

        public ContactData()
        {
        }

        public ContactData(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return FirstName == other.FirstName && LastName == other.LastName;
        }
        public override int GetHashCode()
        {
            return FirstName.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("firstName={0}, lastName={1}", this.FirstName, this.LastName);
        }

        public int CompareTo(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (LastName == other.LastName)
            {
                return FirstName.CompareTo(other.FirstName);
            }
            return LastName.CompareTo(other.LastName);
        }

        [Column(Name = "firstname")]
        public string FirstName { get; set; }

        [Column(Name = "lastname")]
        public string LastName { get; set; }

        [Column(Name = "nickname")]
        public string Nickname { get; set; }

        [Column(Name = "title")]
        public string Title { get; set; }

        [Column(Name = "company")]
        public string Company { get; set; }

        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }

        [Column(Name = "address")]
        public string Address { get; set; }

        [Column(Name = "home")]
        public string HomePhone { get; set; }

        [Column(Name = "mobile")]
        public string MobilePhone { get; set; }

        [Column(Name = "work")]
        public string WorkPhone { get; set; }

        [Column(Name = "email")]
        public string Email { get; set; }

        [Column(Name = "email2")]
        public string Email2 { get; set; }

        [Column(Name = "email3")]
        public string Email3 { get; set; }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00") select c).ToList();
            }
        }

        public static ContactData GetContactWithoutGroup()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return db.Contacts.FirstOrDefault(c => !db.GCR.Any(gc => gc.ContactId == c.Id));
            }
        }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return (string)allEmails;
                }
                else
                {
                    return (CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        public string AllContactData
        {
            get
            {
                string address = String.IsNullOrEmpty(Address) ? "" : "\r\n" + Address;
                string hPhone = String.IsNullOrEmpty(HomePhone) ? "" : "\r\nH: " + HomePhone;
                string mPhone = String.IsNullOrEmpty(MobilePhone) ? "" : "\r\nM: " + MobilePhone;
                string wPhone = String.IsNullOrEmpty(WorkPhone) ? "" : "\r\nW: " + WorkPhone;
                string email = String.IsNullOrEmpty(Email) ? "" : "\r\n" + Email;
                string email2 = String.IsNullOrEmpty(Email2) ? "" : "\r\n" + Email2;
                string email3 = String.IsNullOrEmpty(Email3) ? "" : "\r\n" + Email3;

                string phoneBlock = !String.IsNullOrEmpty(wPhone) || !String.IsNullOrEmpty(hPhone) ||
                    !String.IsNullOrEmpty(mPhone) ? "\r\n" : "";

                string emailBlock = !String.IsNullOrEmpty(email) || !String.IsNullOrEmpty(email2) ||
                   !String.IsNullOrEmpty(email3) ? "\r\n" : "";

                return $"{FirstName} {LastName}{address}{phoneBlock}{hPhone}{mPhone}" +
                       $"{wPhone}{emailBlock}{email}{email2}{email3}";
            }
        }

        public string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ ()-]", "") + "\r\n";
        }
    }
}

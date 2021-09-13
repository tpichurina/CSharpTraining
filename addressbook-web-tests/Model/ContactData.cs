using System;
using System.Text.RegularExpressions;

namespace webAddressbookTests
{

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

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Nickname { get; set; }

        public string Title { get; set; }

        public string Company { get; set; }

        public string Id { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

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

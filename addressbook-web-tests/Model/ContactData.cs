using System;


namespace webAddressbookTests
{

    public class ContactData : IEquatable<ContactData>
    {
        private string firstName;
        private string lastName;
        private string nickname = "";
        private string title = "";
        private string company = "";

        public ContactData(string firstName, string lastName)
        {

            this.firstName = firstName;
            this.lastName = lastName;
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

        public int GetHashCode()
        {
            return FirstName.GetHashCode();
        }

        public string FirstName

        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }
        public string LastName

        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }
        public string Nickname

        {
            get
            {
                return nickname;
            }
            set
            {
                nickname = value;
            }
        }
        public string Title

        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }
        public string Company

        {
            get
            {
                return company;
            }
            set
            {
                company = value;
            }
        }
    }
}

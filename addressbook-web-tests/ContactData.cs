using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webAddressbookTests
{
    class ContactData
    {
        private string firstname;
        private string lastname;
        private string nickname = "";
        private string title = "";
        private string company = "";

        public ContactData(string firstname, string lastname)
        {
           
            this.firstname = firstname;
            this.lastname = lastname;
        }
        public string Firstname

        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }
        public string Lastname

        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
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
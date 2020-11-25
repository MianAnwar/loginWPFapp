using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    class User
    {
        public User(string fn, string ln, string mail, string pwd)
        {
            this.FirstName = fn;
            this.LastName = ln;
            this.Email= mail;
            this.Password = pwd;
        }

        private string firstName;
        private string lastName;
        private string email;
        private string password;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public void register()
        {

        }
    }
}

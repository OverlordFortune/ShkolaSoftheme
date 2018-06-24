using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12._1
{
    class User : IUser
    {
        public string Name { get; }
        public string Password { get; }
        public string Email { get; }

        public User(string Name, string Password, string Email)
        {
            this.Name = Name;
            this.Password = Password;
            this.Email = Email;
        }

        public string GetFullInfo()
        {
            return "Name:" + this.Name +
                "\nPassword:" + this.Password +
                "\n Email:" + this.Email;
        }
    }
}

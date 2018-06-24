using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12._1
{
    abstract class UserList
    {
        protected List<IUser> users = null;

        protected Dictionary<string, DateTime> lastEntireDate = new Dictionary<string, DateTime>();

        protected void AddUser(IUser user, string KeyForDate)
        {
            Console.WriteLine("Add New User : {0}", user.GetFullInfo());
            if (users == null) users = new List<IUser>();
            users.Add(user);
            lastEntireDate.Add(user.Name, DateTime.Now);
        }
        
    }
}

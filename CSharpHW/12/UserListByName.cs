using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12._1
{
    class UserListByName : UserList, IAuthenticator
    {
        public string AuthenticateUser(IUser user)
        {
            Console.WriteLine("Check by name");
            if (users != null)
                foreach (var item in users)
                {
                    if (item.Name == user.Name)
                    {
                        if (item.Password == user.Password)
                        {
                            DateTime date = new DateTime();
                            lastEntireDate.TryGetValue(item.Name, out date);
                            return date.ToString();
                        }
                        return "Wrong Password";
                    }
                }
            AddUser(user, user.Name);
            return "This user does not exist. He wad add to list";
        }
    }
}

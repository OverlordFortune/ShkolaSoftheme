using System;

namespace _12._1
{
    class UserListByEmail : UserList, IAuthenticator
    {
        public string AuthenticateUser(IUser user)
        {
            Console.WriteLine("Check By email.");
            if (users != null)
                foreach (var item in users)
                {
                    if (item.Email == user.Email)
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

            AddUser(user, user.Email);
            return "This user does not exist. He wad add to list";
        }
    }
}

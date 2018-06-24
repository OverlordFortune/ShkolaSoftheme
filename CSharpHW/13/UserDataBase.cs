using System;
using System.Collections.Generic;
using _12._1;

namespace _13._1
{
    public class UserDataBase : IUserDataBase
    {
        protected List<User> users = null;

        public void AddUser(User user)
        {
            if (users == null) users = new List<User>();
            users.Add(user);
        }

        public User[] GetAllUser()
        {
            return users.ToArray();
        }

        public User FindByName(string Name)
        {
            if (users != null)
                foreach (var item in users)
                    if (item.Name == Name) return item;
            return null;
        }

        ~UserDataBase()
        {
            Console.WriteLine("UserDataBase Destructor");
            this.Dispose();
        }

        public void Dispose()
        {
            Console.WriteLine("Dispose!!!");
            ShowAllUser();
            GC.SuppressFinalize(this);
        }

        private void ShowAllUser()
        {
            if (users != null)
                foreach (var item in users)
                {
                    Console.WriteLine("\n------------------------");
                    Console.WriteLine(item.GetFullInfo());
                }
        }
    }
}

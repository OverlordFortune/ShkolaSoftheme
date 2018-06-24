using System;
using System.Collections.Generic;
using _12._1;

namespace _13._1
{
    

    
    class Program
    {
        static void Main(string[] args)
        {
            using (UserDataBase userbase = new UserDataBase())
            {
                Console.WriteLine("Using");
                userbase.AddUser(new User());
                userbase.AddUser(new User("Artur", "11", "11@gmail.com"));
                userbase.AddUser(new User("Rur", "22", "22@gmail.com"));
                userbase.AddUser(new User("Misha", "33", "133@gmail.com"));
                Console.WriteLine("End Using");
            };
            Console.WriteLine("Out");
          
        }
    }
}

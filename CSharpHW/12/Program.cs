using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12._1
{    
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            string email;
            string password;

            UserListByEmail byEmail = new UserListByEmail();
            UserListByName byName = new UserListByName();
            while (true)
            {
                Console.WriteLine("What user do you want to check? For Exit write 'exit' in all fields");
                Console.Write("User Name: ");
                name = Console.ReadLine();
                Console.WriteLine();
                Console.Write("Password: ");

                password = Console.ReadLine();

                Console.Write("Email: ");
                email = Console.ReadLine();

                if(name=="exit"&& email=="exit"&&password=="exit")
                {
                    Console.WriteLine("You choose close proggram");
                    break;
                }
                string result = byEmail.AuthenticateUser(new User(name, password, email));
                Console.WriteLine(result + "\n" + new string('-',30));
                //string result = byName.AuthenticateUser(new User(name, password, email));
            }
        }
    }
}

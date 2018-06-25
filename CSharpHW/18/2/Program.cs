using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18._2
{ 
    
    class Program
    {
        static void Main(string[] args)
        {
            MobileAccount mobile1 = new MobileAccount("0993422226");
            MobileAccount mobile2 = new MobileAccount("0502121212");

            mobile2.Call("099");
            mobile2.SendMail("0993422226");
            Console.WriteLine(new string('-', 30));
            mobile1.AddAccount(mobile2.PhoneNumber, new Account { Name = "Dima" });

            mobile2.SendMail("0993422226");
        }
    }
}

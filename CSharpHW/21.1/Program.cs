using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Json;

namespace _21._1
{
    class Program
    {
        static void Main(string[] args)
        {

            MobileAccount mobile1 = new MobileAccount("Artur", "Sitnichenko", "overlordfortune@gmail.com", new DateTime(1997, 1, 9));
            JsonSerialixer(mobile1);
            MobileAccount mobile2 = new MobileAccount("Kolya", "Sitnichenko", "overlordfortune@gmail.com", new DateTime(1997, 1, 9));

            MobileAccount mobile3 = new MobileAccount("Masha", "Sitnichenko", "overlordfortune@gmail.com", new DateTime(1997, 1, 9));
            MobileAccount mobile4 = new MobileAccount("Pasha", "Sitnichenko", "overlordfortune@gmail.com", new DateTime(1997, 1, 9));

            // mobile2.Call("099");
            mobile2.SendMail("0993422226");
            Console.WriteLine(new string('-', 30));
            mobile1.AddAccount(new Account { Name = "Dima", PhoneNumber = mobile2.Number });


            mobile2.Call("0993422226");
            mobile2.Call("0993");
            mobile2.Call("0993");
            mobile2.Call("0993");
            mobile2.Call("0993");
            mobile2.SendMail("0993422226");
            mobile1.Call(mobile3.Number);
            mobile1.Call(mobile2.Number);
            mobile1.Call(mobile4.Number);
            mobile1.Call(mobile2.Number);

            mobile2.Call("0993422226");
            Console.WriteLine(new string('-', 30));


            AnalisatorRoutings.BestToNumber();
            Console.WriteLine(new string('-', 30));
            AnalisatorRoutings.BestFromNumber();
            Console.WriteLine(new string('-', 30));

        }

        public static void JsonSerialixer(MobileAccount mobileAccount)
        {
            MemoryStream stream = new MemoryStream();

            var jsSerializer =  new DataContractJsonSerializer(typeof(MobileAccount));

            jsSerializer.WriteObject(stream, mobileAccount);
            stream.Position = 0;
            StreamReader sr = new StreamReader(stream);
            Console.Write("JSON form of Person object: ");
            Console.WriteLine(sr.ReadToEnd());
        }
        
    }
}

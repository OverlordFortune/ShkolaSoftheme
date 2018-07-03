using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization.Formatters.Binary;


namespace _21._1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<MobileAccount> mobileAccounts = new List<MobileAccount>();
            Dictionary<MobileAccount, MobileAccount> keyValuePairs = new Dictionary<MobileAccount, MobileAccount>();

            MobileAccount mobile1 = new MobileAccount("Artur", "Sitnichenko", "overlordfortune@gmail.com", new DateTime(1997, 1, 9));
            mobileAccounts.Add(mobile1);
            MobileAccount mobile2 = new MobileAccount("Kolya", "Sitnichenko", "overlordfortune@gmail.com", new DateTime(1997, 1, 9));
            mobileAccounts.Add(mobile2);

            MobileAccount mobile3 = new MobileAccount("Masha", "Sitnichenko", "overlordfortune@gmail.com", new DateTime(1997, 1, 9));
            MobileAccount mobile4 = new MobileAccount("Pasha", "Sitnichenko", "overlordfortune@gmail.com", new DateTime(1997, 1, 9));
            mobileAccounts.Add(mobile3);
            mobileAccounts.Add(mobile4);

            Console.WriteLine(new string('-', 30));
            mobile1.AddAccount(new Account { Name = "Dima", PhoneNumber = mobile2.Number });

            SerializeAll(mobileAccounts);
        }

        public static void SerializeAll(List<MobileAccount> mobileAccounts)
        {
            Console.WriteLine("Json" + new string('-', 30));
            Stopwatch watch = Stopwatch.StartNew();
            foreach (var mobileaccount in mobileAccounts)
            {
                MyAcountSerializator.JsonSerializer(mobileaccount);
            }
            watch.Stop();
            Console.WriteLine("The object is serialized by JSON serialization");
            Console.WriteLine("It takes " + watch.Elapsed + "\n");

            Console.WriteLine("Binary" + new string('-', 30));
            watch = Stopwatch.StartNew();
            foreach (var mobileaccount in mobileAccounts)
            {
                MyAcountSerializator.BinarySerializer(mobileaccount);
            }
            watch.Stop();
            Console.WriteLine("The object is serialized by Binary serialization");
            Console.WriteLine("It takes " + watch.Elapsed + "\n");

            Console.WriteLine("Xml" + new string('-', 30));
            watch = Stopwatch.StartNew();
            foreach (var mobileaccount in mobileAccounts)
            {
                MyAcountSerializator.XmlSerializer(mobileaccount);
            }
            watch.Stop();
            Console.WriteLine("The object is serialized by Xml serialization");
            Console.WriteLine("It takes " + watch.Elapsed + "\n");
        }
    }
}

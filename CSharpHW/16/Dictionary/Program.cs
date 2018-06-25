using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16._3
{
    
    class Program
    {
        static void Main(string[] args)
        {

            MyDictionary<int, string> dictionary = new MyDictionary<int, string>();
            Random rand = new Random();
            try
            {
                int i = 0;
                int j = 0;
                Console.WriteLine("Add to Dictionary");
                Console.WriteLine(new string('-', 30));
                while (true)
                {
                    j = rand.Next(9);
                    dictionary.Add(j, "Mystring " + i);
                    Console.WriteLine(j + "  Mystring "+  i);
                    i++;
                }
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine(new string('-', 30));

                foreach (var item in dictionary.Keys)
                    Console.WriteLine(item);

                foreach (var item in dictionary.Values)
                    Console.WriteLine(item);
            }              
        }
    }
}

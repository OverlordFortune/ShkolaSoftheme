using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._1
{
    public class Photo
    {

    }

    public class Printer
    {
        public virtual void Print(string str)
        {
            Console.WriteLine("Now we Print {0}", str);
        }
    }

    public class ColorPrinter : Printer
    {
        public void Print(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine("Wse color print", text);
            Console.ResetColor();
        }
    }

    public class PhotoPrinter : Printer
    {
        public void Print (Photo photo)
        {
            Console.WriteLine("Now we prit photo");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string test = "Test string";

            Printer printer = new Printer();
            printer.Print(test);

            ColorPrinter colorPrinter = new ColorPrinter();
            colorPrinter.Print(test);
            colorPrinter.Print(test, ConsoleColor.Blue);

            PhotoPrinter photoPrinter = new PhotoPrinter();
            photoPrinter.Print(test);
            photoPrinter.Print(new Photo());
        }
    }
}

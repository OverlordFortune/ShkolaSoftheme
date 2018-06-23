using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _11._1;

namespace _11._2
{
    static class MyExstensionsMethods
    {
        public static void Print(this ColorPrinter[] colorPrinter, string text, ConsoleColor color = ConsoleColor.Black)
        {
            foreach(var item in colorPrinter)
            item.Print(text, color);
        }

        public static void Print(this PhotoPrinter[] photoPrinter,params Photo[] photos)
        {
            int i = photoPrinter.Length;
            int j = 0;
            if (i != 0)
           foreach(var photo in photos)
            {
                    Console.WriteLine("Печатаем {0}-ю фотографию на {1}- принтере", j + 1, (j % i) + 1);
                    photoPrinter[j % i].Print(photo);
                    j++;                  
            }
        }

        public static void PrintArray(this Printer printer, string[] texts)
        {
            if (texts != null && texts.Length != 0)
                foreach (var item in texts)
                    printer.Print(item);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            ColorPrinter colorPrinter = new ColorPrinter();
            ColorPrinter[] colorArray =
            {
                new ColorPrinter(),
                new ColorPrinter(),
                new ColorPrinter()
            };
            //colorPrinter.PrintArray();
            colorArray.Print("Hello", ConsoleColor.Blue);

            PhotoPrinter[] photoPrinter =
            {
                new PhotoPrinter(),
                new PhotoPrinter(),
                new PhotoPrinter()
            };
            photoPrinter.Print(new Photo(), new Photo(), new Photo(), new Photo());

            Printer printer = new Printer();
            string[] str =
            {
                "1", "2", "3"
            };
            printer.PrintArray(str);
            Console.ReadKey();
        }
    }
}

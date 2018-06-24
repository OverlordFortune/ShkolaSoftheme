using System;


namespace _14._1
{
    class Lottery
    {
        private int[] numbers = new int[6];
        private int[] randnumbers = new int[6];

        public int Length
        {
            get
            {
                return numbers.Length;
            }
        }

        public int this[int index]
        {
            get
            {
                if (index >= 0 && index < 9)
                    return numbers[index];
                else throw new IndexOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < 9)
                    numbers[index] = value;
                else throw new IndexOutOfRangeException();
            }
        }

        public bool IsWin()
        {
            if (Points() == 0) return false;
            return true;
        }

        public int Points()
        {
            randnumbers = new int[this.Length];
            Random rand = new Random();
            int points = 0;
            for (int i = 0; i < this.Length; i++)
            {
                randnumbers[i] = rand.Next(9);
                if (numbers[i] == randnumbers[i])
                {
                    points++;
                    Console.WriteLine("{0} - coincided", i + 1);
                }
            }

            ShowResult();
            return points;
        }

        private void ShowResult()
        {

            for (int i = 0; i < this.Length; i++)
            {
                Console.Write(numbers[i]);
            }
            Console.WriteLine("Your numbers");

            for (int i = 0; i < this.Length; i++)
            {
                Console.Write(randnumbers[i]);
            }
            Console.WriteLine("Rand numbers");
        }
    }
}

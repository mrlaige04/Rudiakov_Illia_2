using System;

namespace Lab2
{
    class Program
    {

        public static void Main(string[] args)
        {
            Locality local = new Locality(new int[] { 50, 3, 6, 4, 10 });
            Console.WriteLine($"Max Height:{local.MaxHeight()}");
            Console.WriteLine($"Min Height:{local.MinHeight()}");
            Console.WriteLine("________________________________________");
            local.HeightKrutyznaDifference();
            Console.WriteLine("________________________________________");
            local.Compare();

            
        }
    }
}

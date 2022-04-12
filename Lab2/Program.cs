using System;
using System.Collections;
using System.Collections.Generic;
namespace Lab2
{
    class Program
    {

        public static void Main(string[] args)
        {
            Console.WriteLine("Enter distance between each heights:");
            int dis = ParseWithoutException(Console.ReadLine());
            

            List<int> list = new List<int>();
            string s = "";
            Console.WriteLine("now start to enter heights.\n If you want to stop, enter: exit");
            while (true)
            {                
                s = Console.ReadLine();
                if (s == "exit") break;
                list.Add(ParseWithoutException(s));
            }
            Locality local = new Locality(list.ToArray());
            local.Dist = dis;
            Console.WriteLine($"Max Height:{local.MaxHeight()}");
            Console.WriteLine($"Min Height:{local.MinHeight()}");
            Console.WriteLine("________________________________________");
            local.HeightKrutyznaDifference();
            Console.WriteLine("________________________________________");
            local.Compare();
	        Console.ReadKey();
            
        }
        public static int ParseWithoutException(string s)
        {
            Console.WriteLine(new string('-',30));
            bool _try = true;
            int ret = default;
            while (_try)
            {
                try
                {
                    ret = int.Parse(s);
                    _try = false;
                } catch
                {
                    Console.WriteLine("try one more time");
                    _try = true;
                }
            }
            Console.WriteLine(new string('-', 30));
            return ret;
            
        }
        
    }

    
}

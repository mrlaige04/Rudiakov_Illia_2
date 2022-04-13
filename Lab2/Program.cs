using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
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
            local.Max = local.MaxHeight();
            local.Min = local.MinHeight();
            Console.WriteLine($"Max Height:{local.Max}");
            Console.WriteLine($"Min Height:{local.Min}");
            Console.WriteLine("________________________________________");
            local.HeightKrutyznaDifference();
            Console.WriteLine("________________________________________");
            local.Compare();
            Console.WriteLine("________________________________________");


            string json = Program.JsonSer<Locality>(local);
            string path = string.Format($@"{Directory.GetCurrentDirectory()}\text.json");
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(json);
            }

            string dejson = "";
            using (StreamReader sr = new StreamReader(path))
            {
                dejson = sr.ReadToEnd();
            }
            Locality local2 = JsonDeser<Locality>(dejson);
            Console.WriteLine(local2.ToString());
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

        public static string JsonSer<T>(T obj)
        {
            return JsonSerializer.Serialize(obj);
        }
        public static T JsonDeser<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json);
        }

    }

    
}

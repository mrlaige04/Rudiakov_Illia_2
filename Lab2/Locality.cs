using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Locality
    {
        private List<int> Heights = new List<int>();
        private double[,] profiles;
        private int dist;

        public int Dist
        { 
            get { return dist; }
            set { dist = value; }
        }

        // Додавання необмеженої кількості висот
        public Locality(params int[] heights)
        {
            for (int i = 0; i < heights.Length; i++)
            {
                Heights.Add(heights[i]);
            }

            profiles = new double[CountArr(Heights.Count)-Heights.Count, 4];
        }


        public int MaxHeight() => (from i in Heights orderby i select i).First();

        public int MinHeight() => (from i in Heights orderby i descending select i).First();

        public void HeightKrutyznaDifference()
        {

            List<int> dif = new List<int>();
            int iter = 0;
            for (int i = 0; i < Heights.Count; i++)
            {
                for (int j = i; j < Heights.Count; j++)
                {
                    if (i != j)
                    {
                        profiles[iter, 0] = i;
                        profiles[iter, 1] = j;
                        profiles[iter, 2] = Math.Abs(Heights[i] - Heights[j]);
                        profiles[iter, 3] = Math.Atan(Math.Max(Heights[i], Heights[j]) / 1);

                        Console.WriteLine($"Перепад висот між значеннями висот у точках {i} та {j} складає {Math.Abs(Heights[i] - Heights[j])}");
                        Console.WriteLine($"Кут нахилу(крутизна): {Math.Atan((Math.Max(Heights[i], Heights[j])-Math.Min(Heights[i], Heights[j])) / Dist)}");
                        Console.WriteLine("_____________________________________________________________________");
                        dif.Add(Math.Abs(Heights[i] - Heights[j]));
                        iter++;
                    }
                }
            }


            Console.WriteLine($"Найбільший перепад висот: {(from i in dif orderby i descending select i)?.First()}");
            Console.WriteLine($"Найменший перепад висот: {(from i in dif orderby i  select i)?.First()}");
            Console.WriteLine("_______________________________________________________________");

            
        }
        public void Compare()
        {
            for (int i = 0; i < profiles.GetLength(0); i++)
            {
                for (int j = i; j < profiles.GetLength(0); j++)
                {
                    if(i!=j)
                    {
                        if (profiles[i, 2] > profiles[j, 2]) Console.WriteLine($"У профілю {i} більше перепад ніж у {j}"); else Console.WriteLine($"У профілю {i} менше перепад ніж у {j}");
                        if (profiles[i, 3] > profiles[j, 3]) Console.WriteLine($"У профілю {i} більше крутизна ніж у {j}"); else Console.WriteLine($"У профілю {i} менше крутизна ніж у {j}");
                    }
                }
            }
        }

        public int CountArr(int n)
        {
            int fact=0;
            for (int i = n; i > 0; i--)
            {
                fact += i;
            }
            return fact;
        }
    }
    
}

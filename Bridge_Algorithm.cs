using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiverCrossing_Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> Side1 = new Dictionary<string, int>();
            Dictionary<string, int> Side2 = new Dictionary<string, int>();

            Console.WriteLine("Enter number of persons");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the name and time taken by each");

            for (int a = 0; a < n; a++)
            {
                string tempname = Console.ReadLine();
                int temptime = Convert.ToInt32(Console.ReadLine());
                Side1.Add(tempname, temptime);
            }

            Console.WriteLine("Shortest time and logic:");
            int totaltime = 0;
            int i = 1;
            do
            {
                KeyValuePair<string, int> low1, low2, high1, high2;
                if (i % 2 == 1)
                {
                    LowestTwo(Side1, out low1, out low2);
                    Console.WriteLine("{0} and {1} goes from side 1 to side 2, time taken = {2}", low1.Key, low2.Key, low2.Value);
                    Side1.Remove(low2.Key);
                    Side1.Remove(low1.Key);
                    Side2.Add(low2.Key, low2.Value);
                    Side2.Add(low1.Key, low1.Value);
                    totaltime += low2.Value;

                    low1 = LowestOne(Side2);
                    Console.WriteLine("{0} comes back to side 1, time taken = {1}", low1.Key, low1.Value);
                    totaltime += low1.Value;
                    Side1.Add(low1.Key, low1.Value);
                    Side2.Remove(low1.Key);
                    i++;
                }
                else
                {
                    HighestTwo(Side1, out high1, out high2);
                    Console.WriteLine("{0} and {1} goes from side 1 to side 2, time taken = {2}", high1.Key, high2.Key, high1.Value);
                    Side1.Remove(high1.Key);
                    Side1.Remove(high2.Key);
                    Side2.Add(high1.Key, high1.Value);
                    Side2.Add(high2.Key, high2.Value);
                    totaltime += high1.Value;

                    low1 = LowestOne(Side2);
                    Console.WriteLine("{0} comes back to side 1, time taken = {1}", low1.Key, low1.Value);
                    Side2.Remove(low1.Key);
                    Side1.Add(low1.Key, low1.Value);
                    totaltime += low1.Value;
                    i++;
                }
            } while (Side1.Count > 2);

            KeyValuePair<string, int> low3, low4;
            LowestTwo(Side1, out low3, out low4);
            Console.WriteLine("{0} and {1} goes from side 1 to side 2, time taken = {2}", low3.Key, low4.Key, low4.Value);
            Side2.Add(low4.Key, low4.Value);
            Side2.Add(low3.Key, low3.Value);
            totaltime += low4.Value;

            Console.WriteLine("\n");
            Console.WriteLine("Total Time taken = {0}", totaltime);

        }

        public static void LowestTwo(Dictionary<string, int> a, out KeyValuePair<string, int> low1, out KeyValuePair<string, int> low2)
        {
            Dictionary<string, int> b = a;
            low1 = b.OrderBy(kvp => kvp.Value).First();
            b.Remove(low1.Key);
            low2 = b.OrderBy(kvp => kvp.Value).First();
        }

        public static void HighestTwo(Dictionary<string, int> a, out KeyValuePair<string, int> high1, out KeyValuePair<string, int> high2)
        {
            Dictionary<string, int> b = a;
            high1 = b.OrderByDescending(k => k.Value).First();
            b.Remove(high1.Key);
            high2 = b.OrderByDescending(k => k.Value).First();
        }

        public static KeyValuePair<string, int> LowestOne(Dictionary<string, int> a)
        {
            Dictionary<string, int> b = a;
            return b.OrderBy(kvp => kvp.Value).First();
        }
    }
}
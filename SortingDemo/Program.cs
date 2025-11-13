using System;
using System.Diagnostics;
using System.Timers;
using static System.Net.Mime.MediaTypeNames;

namespace SortingDemo
{
    internal class Program
    {
        private static Stopwatch watch;
        static void Main(string[] args)
        {
            int[] scores = new int[474];
            Random random = new Random();
            for (int i = 0; i < scores.Length; i++) 
            {
                scores[i] = random.Next(101);
            }
            Console.WriteLine("Starting Set: ");
            PrintSet(scores);
            Console.WriteLine("Selection Sort: ");
            PrintSet(Select(scores));
            Console.WriteLine("Insertion Sort: ");
            PrintSet(Insert(scores));
            //Console.WriteLine("Bubble Sort: ");
            //PrintSet(Bubble(scores));
        }

        private static int[] Quick(int[] oldList)
        {
            int[] list = CopyTheListAndStartTime(oldList);



            StopTime();
            return list;
        }

        private static int[] Quicky(int[] list, int lowIDX, int hiIDX)
        {
            if (list[lowIDX] < list[hiIDX])
            {
                int pivIDX = ((hiIDX - lowIDX)/2) + lowIDX;
            }


            return list;
        }

        /// <summary>
        /// <list type="bullet">
        ///     <item>Selection Sort</item>
        ///     <item>Oposite of Insertion in a way. Find the smallest number</item>
        ///     <item>Best: O(n^2). Worst: O(n^2).</item>
        /// </list>
        /// </summary>
        /// <param name="oldList"></param>
        /// <returns></returns>
        private static int[] Select(int[] oldList)
        {
            int[] list = CopyTheListAndStartTime(oldList);

            for (int i = 0; i < list.Length; i++)
            {
                int smallest = int.MaxValue;
                int smallIndex = 0;
                for (int j = i; j < list.Length; j++)
                {
                    if(list[j] < smallest)
                    {
                        smallest = list[j];
                        smallIndex = j;
                    }
                }
                int temp = list[i];
                list[i] = list[smallIndex];
                list[smallIndex] = temp;
            }

            StopTime();
            return list;
        }

        /// <summary>
        /// <list type="bullet">
        ///     <item>Insertion Sort</item>
        ///     <item>Pickes each index and insets into previous sorted set within the array.</item>
        ///     <item>Best: O(n). Worst: O(n^2).</item>
        /// </list>
        /// </summary>
        /// <param name="oldList"></param>
        /// <returns></returns>
        private static int[] Insert(int[] oldList)
        {
            int[] list = CopyTheListAndStartTime(oldList);
            for (int i = 0; i < list.Length; i++)
            {
                for (int j = i; j > 0 && list[j - 1] > list[j]; j--)
                {
                    int temp = list[j];
                    list[j] = list[j - 1];
                    list[j - 1] = temp;
                }
            }

            StopTime();
            return list;
        }

        private static int[] CopyTheListAndStartTime(int[] oldList)
        {
            int[] list = new int[oldList.Length];
            Array.Copy(oldList, list, oldList.Length);
            watch = Stopwatch.StartNew();
            return list;
        }

        private static void PrintSet(int[] scores)
        {
            for (int i = 0; i < scores.Length; i++) 
            {
                Console.Write(scores[i]);
                if (i+1 !< scores.Length)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine("\n");
        }


        /// <summary>
        /// <list type="bullet">
        ///     <item>Bubble Sort</item>
        ///     <item>This algo swaps pairs out of order of each other. 
        ///     Numbers bubble up till they are all sorted.</item>
        ///     <item>Best: O(1). Worst: O(n^2).</item>
        /// </list>
        /// </summary>
        /// <param name="oldList"></param>
        /// <returns></returns>
        private static int[] Bubble(int[] oldList)
        {
            int[] list = CopyTheListAndStartTime(oldList);

            bool sorted = false;
            while (!sorted)
            {
                sorted = true;
                for (int i = 1; i < list.Length; i++)
                {
                    if (list[i] < list[i - 1])
                    {
                        int temp = list[i];
                        list[i] = list[i - 1];
                        list[i - 1] = temp;
                        sorted = false;
                    }
                }
            }

            StopTime();
            return list;
        }

        private static void StopTime()
        {
            watch.Stop();
            Console.WriteLine($"The algo took {watch.ElapsedMilliseconds}ms.");
        }
    }
}

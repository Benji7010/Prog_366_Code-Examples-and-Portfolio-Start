using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Timers;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            //Console.WriteLine("Selection Sort: ");
            //PrintSet(Select(scores));
            //Console.WriteLine("Insertion Sort: ");
            //PrintSet(Insert(scores));
            //Console.WriteLine("Bubble Sort: ");
            //PrintSet(Bubble(scores));

            // Searching
            const int search = 69;
            //Console.WriteLine("Linear Search: ");
            //Console.WriteLine($"Found {search} at index {LinearS(scores, search)}.");
            //Console.WriteLine("Binary Search: ");
            //Console.WriteLine($"Found {search} at index {BinaryS(Insert(scores), search)}.");
            Console.WriteLine("Interpolation Search: ");
            Console.WriteLine($"Found {search} at index {InterpolS(Insert(scores), search)}.");
        }

        //  Interpolation Search
        //  Using a sorted set, looks at the item's key to deduce where the number to find is most likely at.
        //  Works best on uniform sets.
        //  Worse case: O(n). Best Case: O(log(log(n))). (both after sort)
        //func search(list[], searchValue)
        //{
        //
        //    low = 0;
        //    high = list Length - 1
        //
        //    position
        //    delta
        //
        //
        //    while (low <= high && search >= list[low] && search <= list[high])
        //            {
        //                delta = (search - list[low]) / (list[high] - list[low]);
        //                position = low + (int)Math.Floor((high - low) * delta);
        //                if (list[position] == search)
        //                {
        //                    return position;
        //                }
        //                if (list[position] < search)
        //                {
        //                    low = position + 1;
        //                }
        //                else
        //                {
        //                    high = position - 1;
        //                }
        //            }
        //    return -1;
        //}


        private static int InterpolS(int[] oldList, int search)
        {
            int[] list = CopyTheArrayAndStartTime(oldList);
            
            int low = 0;
            int high = list.Length-1;
            int position;
            int delta;
            while (low <= high && search >= list[low] && search <= list[high])
            {
                delta = (search - list[low]) / (list[high] - list[low]);
                decimal calcd = (high - low) * delta;
                position = low + (int)Math.Floor(calcd);
                if (list[position] == search)
                {
                    StopTime("Interpolation Sort");
                    return position;
                }
                if (list[position] < search)
                {
                    low = position + 1;
                }
                else
                {
                    high = position - 1;
                }
            }

            StopTime("Interpolation Sort");
            return -1;
        }

        //  Binary Search
        //  Using a sorted set, finds the median number and checks the number on if to search
        //  the median of the left or right of the set.
        //  Worse case: O(log(n)). Best Case: O(1). (both after sort)
        //    function binary_search(A, n, T) is
        //      L := 0
        //      R := n − 1
        //      while L ≤ R do
        //          m := floor((L + R) / 2)
        //          if A[m] < T then
        //              L := m + 1
        //          else if A[m] > T then
        //              R := m − 1
        //          else:
        //              return m
        //      return unsuccessful
        private static int BinaryS(int[] oldList, int search)
        {
            int[] list = CopyTheArrayAndStartTime(oldList);
            int leftIdx = 0;
            int rightIdx = list.Length - 1;

            while (leftIdx <= rightIdx)
            {
                decimal decMath = (leftIdx + rightIdx) / 2;
                int middle = (int)Math.Floor(decMath);
                if (list[middle] < search)
                {
                    leftIdx = middle + 1;
                }
                else if (list[middle] > search)
                {
                    rightIdx = middle - 1;
                }
                else
                {
                    StopTime("Binary Search");
                    return middle;
                }
            }

            StopTime("Binary Search");
            return -1;
        }

        //  Linear Search
        //  Goes through every element till it finds the desired element.
        //  Worse case: O(n). Best Case: O(1).
        //  Begin
        //  1) Set i = 0
        //  2) If Li = T, go to line 4
        //  3) Increase i by 1 and go to line 2
        //  4) If i<n then return i
        //  End

        private static int LinearS(int[] oldList, int search)
        {
            int[] list = CopyTheArrayAndStartTime(oldList);
            
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] == search)
                {
                    StopTime("Linear Search");
                    return i;
                }
            }

            StopTime("Linear Search");
            return -1;
        }

        private static int[] Quick(int[] oldList)
        {
            int[] list = CopyTheArrayAndStartTime(oldList);



            StopTime("Quick Sort");
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
            int[] list = CopyTheArrayAndStartTime(oldList);

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

            StopTime("Selection Sort");
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
            int[] list = CopyTheArrayAndStartTime(oldList);
            for (int i = 0; i < list.Length; i++)
            {
                for (int j = i; j > 0 && list[j - 1] > list[j]; j--)
                {
                    int temp = list[j];
                    list[j] = list[j - 1];
                    list[j - 1] = temp;
                }
            }

            StopTime("Insertion Sort");
            return list;
        }

        private static int[] CopyTheArrayAndStartTime(int[] oldList)
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
            int[] list = CopyTheArrayAndStartTime(oldList);

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

            StopTime("Bubble Sort");
            return list;
        }

        private static void StopTime(string algoName)
        {
            watch.Stop();
            Console.WriteLine($"The {algoName} algorithm took {watch.ElapsedMilliseconds}ms.");
        }
    }
}

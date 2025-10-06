using System;
using System.IO;

namespace Prog_405_Code_Examples_and_Portfolio_Start
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(RotateConstant(45, 90));
            //Console.WriteLine(BigDifference(new int[] { 2, 4 }));
            //Console.WriteLine(BigDifference(new int[] {int.MinValue, int.MaxValue}));
            //Console.WriteLine(uint.MaxValue);
            string[] shuff = FishShuff();
            foreach (string s in shuff)
                Console.WriteLine(s);
        }

        static string[] FishShuff()
        {
            List<string> shuff = GetFile();

            Random rand = new Random();

            for (int i = 0; i < shuff.Count; i++)
            {
                int gen = rand.Next(i, shuff.Count);
                string temp = shuff[i];
                shuff[i] = shuff[gen];
                shuff[gen] = temp;
            }

            return shuff.ToArray();
        }

        private static List<string> GetFile()
        {
            // Keeping it simple, not great with serialization so a modified off the shelf solution when the requirements are still flexibe seems pretty good.
            
            //Console.WriteLine("FilePath: ");
            //string? file = Console.ReadLine();
            string file = "C:/Users/benji/Downloads/testFile.txt";

            if (File.Exists(file))
            {
                StreamReader Textfile = new StreamReader(file);
                string line;
                // TODO: Find a type of manipulatable list that doesn't have sorting and shuffling built in.
                List<string> lines = new List<string>();

                while ((line = Textfile.ReadLine()) != null)
                {
                    lines.Add(line);
                }

                Textfile.Close();

                return lines;
            }
            else { throw new FileNotFoundException(); }
        }

        //Constant Time. Will only run a limited amount of operations even with numbers below 0.
        static int RotateConstant(int value, int amount)
        {
            value += amount;
            if (value > 360)
            {
                value -= 360;
            }
            else if (value < 0)
            {
                value += 360;
            }
            return value;
        }

        //Linear Time. Complexity determined by array length.
        static uint BigDifference(int[] set)
        {
            int small = int.MaxValue;
            int big = int.MinValue;

            if (set.Length <= 1)
            {
                return 0;
            }

            foreach (int i in set)
            {
                if (i > big)
                {
                    big = i;
                }
                if (i < small)
                {
                    small = i;
                }
            }

            return (uint)(big - small);
        }

        //Quadratic Time. Since there is a loop for each interation of a loop. complexity scales by the array length squared.
        static int Thirteens(int[] set)
        {
            int amount = 0;

            for(int i = 0; i < set.Length; i++)
            {
                for (int j = i + 1; j < set.Length; j++)
                {
                    if (set[i] + set[j] == 13)
                    {
                        amount++;
                    }
                }
            }
            
            return amount;
        }
    }
}

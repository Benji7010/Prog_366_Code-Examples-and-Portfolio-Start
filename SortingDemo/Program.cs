namespace SortingDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] scores = new int[474];
            Random random = new Random();
            for (int i = 0; i < scores.Length; i++) 
            {
                scores[i] = random.Next(101);
            }
            Console.Write("Starting Set: ");
            PrintSet(scores);
            Console.Write("Bubble Sort: ");
            PrintSet(Bubble(scores));
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

        private static int[] Bubble(int[] list)
        {
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
            return list;
        }
    }
}

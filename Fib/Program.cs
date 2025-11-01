namespace Fib
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter a factor. (Sequence starts with factor 0:0 and 1:1)");
                Console.WriteLine(Fib(Int32.Parse(Console.ReadLine())));
            }
        }

        public static int Fib(int x)
        {
            int factorDash2 = 0;
            int factorDash1 = 1;
            int currentFactor = 0;

            if (x == 0)
            {
                return factorDash2;
            }
            if (x == 1)
            {
                return factorDash1;
            }

            for (int i = 2; i <= x; i++)
            {
                currentFactor = factorDash2 + factorDash1;
                factorDash2 = factorDash1;
                factorDash1 = currentFactor;
                Console.WriteLine($"{i}: {currentFactor}");
            }

            return currentFactor;
        }
    }
}

using Prog_405_Code_Examples_and_Portfolio_Start;

namespace DataStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            //For applying only.
            List<int> list = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                list.Add(rand.Next(0,100));
            }
            
            //Can be read and writen to in O(1), but must be writen to in whole if you want to change the size of the array.
            int[] intsArr = list.ToArray();
            Console.WriteLine($"{intsArr[56]} is at element 56.");
            intsArr[56] = -1;
            Console.WriteLine($"Now {intsArr[56]} is at element 56.");
            try
            {
                intsArr[103] = -1;
            }
            catch
            {
                Console.WriteLine("Out of bounds as expected.");
            }

            //A list of elements. Elements can be added and removed from the start of the list.
            //Big O for linked lists depends on secific stucture, but find a element at an index one way is typically O(n).
            IStack<int> intsStack = new BJIStack<int>();
            for (int i = 0; i < list.Count(); i++)
            {
                intsStack.AddFirst(list.ElementAt(i));
            }
            intsStack.RemoveFirst();
            Iterator<int> it = new Iterator<int>(intsStack);
            if(list.ElementAt(0) != it.GetCurrentValue)
            {
                Console.WriteLine($"{list.ElementAt(0)} Removed. {it.GetCurrentValue} is the new first one.");
            }
            else
            {
                Console.WriteLine("Nope");
            }

                //A list of elements. Elements can be added to the front and removed from the back of the list.
                IQueue<int> intsQueue = new BJIQueue<int>();
            for (int i = 0; i < list.Count(); i++)
            {
                intsQueue.AddFirst(list.ElementAt(i));
            }
            //Bad implimentation. Should be adding to the end of the list to make removing from queue O(1).
            intsQueue.RemoveLast();
            it = new Iterator<int>(intsQueue);
            while (it.HasNext())
            {
                it.NextValue();
            }
            if(list.ElementAt(99) != it.GetCurrentValue)
            {
                Console.WriteLine($"{list.ElementAt(99)} Removed. {it.GetCurrentValue} is the new last one.");
            }
            else
            {
                Console.WriteLine("Nope");
            }


            //Unordered list of key and value pairs. Easy to find each value by it's key.
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < list.Count(); i++)
            {
                dict.Add(i, list.ElementAt(i));
            }
            Console.WriteLine(dict.ElementAt(89));

            //Like a dictionary, but the keys are pre-set with a hash function. Needs rules for dealing with hash collisions.
            //Much safer from collisions when there is enough room.
            HashSet<int> numbers = new HashSet<int>(list.Count());
            for (int i = 0; i < list.Count(); i++)
            {
                numbers.Add(list.ElementAt(i));
            }
            Console.WriteLine($"It is {numbers.Contains(7)} that the table contains a {7} somewhere.");
        }
    }
}

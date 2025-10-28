using Prog_405_Code_Examples_and_Portfolio_Start;

namespace TestProject1
{
    public class LinkedListTests
    {
        [Fact]
        public void AddFirst()
        {
            BenjiLinkedList<int> ints = new BenjiLinkedList<int>();
            ints.AddFirst(1);
            Iterator<int> it = new Iterator<int>(ints);
            Assert.Equal(1, it.GetCurrentValue);
        }

        [Fact]
        public void AddFirstTwice()
        {
            BenjiLinkedList<int> ints = new BenjiLinkedList<int>();
            ints.AddFirst(1);
            ints.AddFirst(2);
            Iterator<int> it = new Iterator<int>(ints);
            Assert.Equal(2, it.GetCurrentValue);
            Assert.Equal(1, it.NextValue());
        }

        //[Fact]
        //public void AddLast()
        //{

        //}

        [Fact]
        public void RemoveFirst()
        {
            BenjiLinkedList<int> ints = new BenjiLinkedList<int>();
            ints.AddFirst(1);
            ints.AddFirst(2);
            ints.RemoveFirst();
            Iterator<int> it = new Iterator<int>(ints);
            Assert.Equal(1, it.GetCurrentValue);
        }

        [Fact]
        public void RemoveFirstTwice()
        {
            BenjiLinkedList<int> ints = new BenjiLinkedList<int>();
            ints.AddFirst(1);
            ints.AddFirst(2);
            ints.RemoveFirst();
            ints.RemoveFirst();
            Iterator<int> it = new Iterator<int>(ints);
            Assert.Equal(0, it.GetCurrentValue);
        }

        [Fact]
        public void GetArray()
        {
            BenjiLinkedList<int> ints = new BenjiLinkedList<int>();
            ints.AddFirst(6);
            ints.AddFirst(5);
            ints.AddFirst(4);
            ints.AddFirst(3);
            ints.AddFirst(2);
            ints.AddFirst(1);
            int[]? arr = ints.GetArray();
            Assert.Equal(new int[] { 1, 2, 3, 4, 5, 6 }, arr);
        }

        //[Fact]
        //public void RemoveToNull()
        //{
        //    BenjiLinkedList<int> ints = new BenjiLinkedList<int>();
        //    ints.AddFirst(1);
        //    ints.RemoveFirst();
        //    Iterator<int> it = new Iterator<int>(ints);
        //    Assert.Equal(null, it.GetCurrentValue);
        //}
    }
}

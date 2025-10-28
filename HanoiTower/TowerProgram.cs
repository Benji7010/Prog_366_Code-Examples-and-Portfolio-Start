using Prog_405_Code_Examples_and_Portfolio_Start;
using System.Formats.Asn1;

namespace HanoiTower
{
    internal class Tower
    {
        BenjiLinkedList<uint> linkedTower;
        uint TopRing
        {
            get
            {
                Iterator<uint> it = new Iterator<uint>(linkedTower);
                return it.GetCurrentValue;
            }
        }

        /// <summary>
        /// Create a towers with a set number of rings.
        /// </summary>
        /// <param name="rings"></param>
        public Tower(uint rings)
        {
            linkedTower = new BenjiLinkedList<uint>();
            for (uint i = rings; i > 0; i--)
            {
                linkedTower.AddFirst(i);
            }
        }

        /// <summary>
        /// Add a ring to the tower. Returns true if the move was legal.
        /// </summary>
        /// <param name="ringSize"></param>
        public bool AddRing(uint ringSize)
        {
            if(ringSize > TopRing && TopRing != 0)
            {
                return false;
            }
            else
            {
                linkedTower.AddFirst(ringSize);
                return true;
            }
        }

        /// <summary>
        /// Remove ring from the tower and return it.
        /// </summary>
        /// <returns></returns>
        public uint RemoveRing()
        {
            uint takenRing = TopRing;
            linkedTower.RemoveFirst();
            return takenRing;
        }

        /// <summary>
        /// Gives an array of the rings in the tower.
        /// </summary>
        /// <returns></returns>
        public uint[] ArrayRings()
        {
            uint[]? arr = linkedTower.GetArray();
            if(arr == null)
            {
                return new uint[0];
            }
            return arr;
        }
    }

    //Missing Implimentation. Would have been useful to have something I can easily que actions into.
    internal class HanoiTower
    {

    }
    
    internal class TowerProgram
    {
        static string ConvertArrToString(uint[] arr)
        {
            return string.Concat(arr.Select(x => x.ToString()));
        }
        
        static void Main(string[] args)
        {
            Tower[] towers = CreateTowers();
            string ringsSuccess = ConvertArrToString(towers[0].ArrayRings());
            uint heldRing = 0;
            uint prevTower = 0;

            while (true)
            {
                string twoTower = ConvertArrToString(towers[2].ArrayRings());
                Console.WriteLine($"[1] Left tower:   {ConvertArrToString(towers[0].ArrayRings())}");
                Console.WriteLine($"[2] Middle tower: {ConvertArrToString(towers[1].ArrayRings())}");
                Console.WriteLine($"[3] Right tower:  {twoTower}");
                if (twoTower == ringsSuccess)
                {
                    Console.WriteLine("You Win!");
                    break;
                }
                Console.WriteLine($"Held Ring: {heldRing}");
                uint towerNum;
                if (heldRing == 0)
                {
                    towerNum = ValidInput("Enter the number tower to take from the top of.", 1, 3);
                    heldRing = towers[towerNum-1].RemoveRing();
                    prevTower = towerNum;
                }
                else
                {
                    towerNum = ValidInput("Enter the number tower to place the ring on top of.", 1, 3);
                    if(prevTower != 2 && (towerNum != 2 && towerNum != prevTower))
                    {
                        Console.WriteLine("Must place ring on nearby tower.");
                    }
                    else if (!towers[towerNum-1].AddRing(heldRing))
                    {
                        Console.WriteLine("Ring is too large.");
                    }
                    else
                    {
                        heldRing = 0;
                    }
                }
            }
        }

        /// <summary>
        /// Creates towers array and returns them.
        /// </summary>
        /// <returns></returns>
        private static Tower[] CreateTowers()
        {
            //Could do a lot more if I can better display the rings.
            uint ringNum = ValidInput("Enter how many rings to solve for? Max: 9", 1, 9);

            Tower firstTower = new Tower(ringNum);

            return new Tower[]
            {
                firstTower,
                new Tower(0),
                new Tower(0)
            };
        }

        /// <summary>
        /// Loop until valid number has been inputed.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        private static uint ValidInput(string request, uint min, uint max)
        {
            uint num;
            while (true)
            {
                Console.WriteLine(request);
                string? ringString = Console.ReadLine();
                try
                {
                    num = Convert.ToUInt32(ringString);
                    if (num >= min && num <= max)
                    {
                        break;
                    }
                }
                catch { }
                Console.WriteLine($"Input valid number between {min} and {max}.");
            }

            Console.Clear();
            return num;
        }
    }
}

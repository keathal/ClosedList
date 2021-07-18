using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosedList
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomList<int> myList= new CustomList<int>();
            myList.HeadReached += MyList_HeadReached;
            myList.Add(1);
            Console.WriteLine("Previous: " + myList.Previous);
            Console.WriteLine("Current: " + myList.Current);
            Console.WriteLine("Next: " + myList.Next);
            myList.Add(2);
            Console.WriteLine("Previous: " + myList.Previous);
            Console.WriteLine("Current: " + myList.Current);
            Console.WriteLine("Next: " + myList.Next);
            myList.Add(4);

            for(int i = 0; i < myList.Count; i++)
            {
                Console.WriteLine(myList[i]);
            }
            myList.MoveNext();

            Console.WriteLine("Move Next");
            Console.WriteLine("Previous: " + myList.Previous);
            Console.WriteLine("Current: " + myList.Current);
            Console.WriteLine("Next: " + myList.Next);

            myList.Insert(2, 3);

            for (int i = 0; i < myList.Count; i++)
            {
                Console.WriteLine(myList[i]);
            }

            Console.WriteLine("Previous: " + myList.Previous);
            Console.WriteLine("Current: " + myList.Current);
            Console.WriteLine("Next: " + myList.Next);

            myList.Insert(3, 10);
            for (int i = 0; i < myList.Count; i++)
            {
                Console.WriteLine(myList[i]);
            }
            Console.WriteLine("Previous: " + myList.Previous);
            Console.WriteLine("Current: " + myList.Current);
            Console.WriteLine("Next: " + myList.Next);

            myList.MoveNext();

            Console.WriteLine("Move Next");
            Console.WriteLine("Previous: " + myList.Previous);
            Console.WriteLine("Current: " + myList.Current);
            Console.WriteLine("Next: " + myList.Next);

            myList.Remove(4);

            Console.WriteLine("Move Back");
            Console.WriteLine("Previous: " + myList.Previous);
            Console.WriteLine("Current: " + myList.Current);
            Console.WriteLine("Next: " + myList.Next);

            myList.MoveBack();

            Console.WriteLine("Move Back");
            Console.WriteLine("Previous: " + myList.Previous);
            Console.WriteLine("Current: " + myList.Current);
            Console.WriteLine("Next: " + myList.Next);

            myList.MoveBack();

            Console.WriteLine("Move Back");
            Console.WriteLine("Previous: " + myList.Previous);
            Console.WriteLine("Current: " + myList.Current);
            Console.WriteLine("Next: " + myList.Next);

            myList.MoveBack();

            Console.WriteLine("Move Back");
            Console.WriteLine("Previous: " + myList.Previous);
            Console.WriteLine("Current: " + myList.Current);
            Console.WriteLine("Next: " + myList.Next);

            Console.ReadLine();
        }

        private static void MyList_HeadReached(object sender, int e)
        {
            Console.WriteLine("---Head reached---");
        }
    }
}

using System;
using PortableMD5;

namespace MD5ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
          

            var test1 = "The quick brown fox jumps over the lazy dog";
            var result1 = "9e107d9d372bb6826bd81d3542a419d6";

            var test2 = "The quick brown fox jumps over the lazy dog.";
            var result2 = "e4d909c290d0fb1ca068ffaddf22cbd0";

            var h = new MD5();

            string t1 = h.Process(test1);
            Console.WriteLine("Testing {0} ... {1}",t1,(t1 == result1));

            string t2 = h.Process(test2);
            Console.WriteLine("Testing {0} ... {1}", t2, (t2 == result2));

            Console.WriteLine("Press any key...");
            Console.ReadLine();

        }
    }
}

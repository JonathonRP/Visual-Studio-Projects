using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main( string[] args )
        {
            // variable scoping test

            var foo = "foo";

            void first()
            {
                Console.WriteLine( foo );
                //var foo = "bar";
                foo = "bar";
            }

            first(); // output foo if defined outside

            Console.ReadKey();
        }
    }
}

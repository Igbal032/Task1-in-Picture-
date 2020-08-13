using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("X ededin daxil edin: ");
                double x = Double.Parse(Console.ReadLine());

                Console.WriteLine("Y ededin daxil edin: ");
                double y = Double.Parse(Console.ReadLine());

                string res = Extension.calculate(x, y);
                Console.WriteLine("Netice :" + res);
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = new List<string>();
            Console.Write("Birinci sözü daxil edin: ");
            string firstWord = Console.ReadLine();
            Console.Write("Ikinci sözü daxil edin: ");
            string secondWord = Console.ReadLine();
            Console.Write("Üçüncü sözü daxil edin: ");
            string thirdWord = Console.ReadLine();
            Console.Write("Dördüncü sözü daxil edin: ");
            string fourthWord = Console.ReadLine();
            words.Add(firstWord);
            words.Add(secondWord);
            words.Add(thirdWord);
            words.Add(fourthWord);
            var sort = words.OrderBy(n => n.Length);
            Console.WriteLine(sort.FirstOrDefault()+" -- Qisa");
            Console.WriteLine(sort.LastOrDefault()+" -- Uzun");
        }
    }
}

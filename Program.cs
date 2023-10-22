using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refrigerator_exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Refrigerator refrigerator= new Refrigerator();
            Console.WriteLine(refrigerator);
            refrigerator.cleanRefrigerator();
            Console.WriteLine("-------------------------");
            Console.WriteLine(refrigerator);
            Console.ReadLine();
        }
    }
}

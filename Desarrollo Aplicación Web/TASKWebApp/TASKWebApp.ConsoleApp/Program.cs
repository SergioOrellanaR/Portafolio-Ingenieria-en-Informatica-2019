using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASKWebApp.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach(string val in Business.Helpers.ComboBoxDataLoader.Gender.Values.ToList())
            {
                Console.WriteLine(val);
            }
            Console.ReadKey();
        }
    }
}

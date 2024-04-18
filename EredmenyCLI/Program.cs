using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EredmenyCLI
{
    class Program
    {
        static void Main(string[] args)
        {

            EredmenyRepo.path = "eredmenyek.txt";

            List<Eredmeny> eredmenyek = EredmenyRepo.FindAll();

            foreach (var item in eredmenyek)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}

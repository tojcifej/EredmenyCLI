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


            Eredmeny valami = EredmenyRepo.FindByID("110");

            valami.Szazalek = 100;

            EredmenyRepo.Save(valami);


            foreach (var item in eredmenyek)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}

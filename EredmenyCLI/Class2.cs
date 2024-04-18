using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EredmenyCLI
{
    class EredmenyRepo
    {
        public static string path { get; set; }
        public static bool SkipHeader { get; set; } = true;
        public static char separator { get; set; } = ',';

        public static List<Eredmeny> FindAll()
        {
            using (StreamReader reader = new StreamReader(path))
            {
                if (SkipHeader)
                    reader.ReadLine();


                List<Eredmeny> People = new List<Eredmeny>();

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    Eredmeny person = Eredmeny.CreateFromLine(line, separator);
                    People.Add(person);

                }

                return People;
            }
        }

        public static List<Eredmeny> FindAllBySearch(string vezeteknev, string keresztnev, string targy, string szazalek, string erdemjegy)
        {
            List<Eredmeny> Eredmeny = new List<Eredmeny>();

            foreach (Eredmeny eredmeny in FindAll())
            {

                if (!eredmeny.VezetekNev.ToLower().Contains(vezeteknev.ToLower().Trim()))
                    continue;
                if (!eredmeny.KeresztNev.ToLower().Contains(keresztnev.ToLower().Trim()))
                    continue;
                if (!eredmeny.Targy.ToLower().Contains(targy.ToLower().Trim()))
                    continue;
                if (!eredmeny.Szazalek.ToString().Contains(szazalek.ToLower().Trim()))
                    continue;
                if (!eredmeny.Erdemjegy.ToString().ToLower().Contains(erdemjegy.ToLower().Trim()))
                    continue;

                Eredmeny.Add(eredmeny);
            }

            return Eredmeny;
        }

    }
}

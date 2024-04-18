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

        public static List<Eredmeny> FindAllBySearch(string id, string vezeteknev, string keresztnev, string targy, string szazalek, string erdemjegy)
        {
            List<Eredmeny> Eredmeny = new List<Eredmeny>();

            foreach (Eredmeny eredmeny in FindAll())
            {
                if (!eredmeny.ID.ToString().ToLower().Contains(id.ToLower().Trim()))
                    continue;
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

        public static Eredmeny FindByID(string id)
        {
            List<Eredmeny> eredmenyek = FindAll();

            for (int i = 0; i < eredmenyek.Count; i++)
            {
                if (id == eredmenyek[i].ID.ToString())
                    return eredmenyek[i];
            }

            return null;
        }

        public static Eredmeny Save(Eredmeny eredmeny)
        {
            List<Eredmeny> eredmenyek = FindAll();

            if (eredmeny.ID == 0)
            {
                eredmeny.ID = eredmenyek.Last().ID + 1;

                eredmenyek.Add(eredmeny);
            }
            else
            {
                for (int i = 0; i < eredmenyek.Count; i++)
                {
                    if (eredmenyek[i].ID == eredmeny.ID)
                    {
                        eredmenyek[i] = eredmeny;
                    }
                }
            }

            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine("id,vezeteknev,keresztnev,targy,szazalek,erdemjegy");

                foreach (var item in eredmenyek)
                {
                    string line = $"{item.ID},{item.VezetekNev},{item.KeresztNev},{item.Targy},{item.Szazalek},{item.Erdemjegy}";
                    writer.WriteLine(line);
                }
            }


            return eredmeny;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqV1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Skladiste> skladiste1 = new List<Skladiste>()
            {
                new Skladiste(1000, "Split"),
                new Skladiste(2000, "Zagreb"),
                new Skladiste(3000, "Rijeka")
            };

            List<Proizvod> proizvodi = new List<Proizvod>()
            { 
                new Proizvod(1, "Mlijeko", 522220, 50, skladiste1[1]),
                new Proizvod(2, "Kruh", 32222, 30, skladiste1[0]),
                new Proizvod(3, "Jaja", 12220, 11, skladiste1[2]),  
                new Proizvod(4, "Sir", 22220, 17,skladiste1[1])
            };
                      
            var upit = from proizvod in proizvodi
                        where proizvod.Barkod  > 30000
                        select new { proizvod.Naziv, proizvod.Barkod };
           
            foreach (var proizvod in upit)
            {
                Console.WriteLine("Proizvod: {0}, Barkod: {1}", proizvod.Naziv, proizvod.Barkod);
            }

            ArrayList Kolekcija = new ArrayList();

            Kolekcija.Add(123);          
            Kolekcija.Add("Hello");      
            Kolekcija.Add(45.67);         
            Kolekcija.Add(true);          
            Kolekcija.Add(new Skladiste(1000, "Split"));
            Kolekcija.Add(new Skladiste(2000, "Zagreb"));
            Kolekcija.Add(new Skladiste(3000, "Rijeka"));

            
            var upit2 = from skladiste in Kolekcija.OfType<Skladiste>()
                        select new { skladiste.Kapacitet, skladiste.Lokacija };
           
            foreach (var skladiste in upit2)
            {
                Console.WriteLine("Skladiste: {0}, Kapacitet: {1}", skladiste.Lokacija, skladiste.Kapacitet);
            }


            var sortiranje = from proizvod in proizvodi
                        orderby proizvod.Sifra, proizvod.Barkod, proizvod.ID
                        select proizvod;
          
            foreach (var proizvod in sortiranje)
            {
                Console.WriteLine("Proizvod: {0}, Barkod: {1}, Sifra: {2}", proizvod.Naziv, proizvod.Barkod, proizvod.Sifra);
            }

            
            var sortiranje2 = from skladiste in Kolekcija.OfType<Skladiste>()
                        orderby skladiste.Kapacitet, skladiste.Lokacija
                        select skladiste;
           
            foreach (var skladiste in sortiranje2)
            {
                Console.WriteLine("Skladiste: {0}, Kapacitet: {1}", skladiste.Lokacija, skladiste.Kapacitet);
            }


            List<string> recenice = new List<string>
                {
                     "Ovo je prva rečenica.",
                     "Ovo je druga rečenica.",          
                     "To je to."
                };

            var query = (from sentence in recenice
                               from word in sentence.Split(' ')
                               where word == "je"
                               select word).Count();

            var metoda = recenice.SelectMany(sentence => sentence.Split(' '))
                                        .Where(word => word == "je")
                                        .Count();

            
            Console.WriteLine($"Broj reči 'je' (Query): {query}");
            Console.WriteLine($"Broj reči 'je' (Metoda): {metoda}");


            var grupiranje = from proizvod in proizvodi
                             group proizvod by proizvod.Skladiste into grupa
                             select new { Skladiste = grupa.Key, Proizvodi = grupa };

           
            foreach (var grupa in grupiranje)
            {
                Console.WriteLine("Skladiste: {0}", grupa.Skladiste.Lokacija);

                foreach (var proizvod in grupa.Proizvodi)
                {
                    Console.WriteLine("Proizvod: {0}", proizvod.Naziv);
                }
            }


            Console.ReadKey();
        }

              
     }

}
    



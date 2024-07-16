using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqV1
{
    internal class Proizvod
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public int Barkod { get; set; }
        public int Sifra { get; set; }

        public Skladiste Skladiste { get; set; }


        public Proizvod(int id, string naziv, int barkod, int sifra, Skladiste skladiste)
        {
            ID = id;
            Naziv = naziv;
            Barkod = barkod;
            Sifra = sifra;
            Skladiste = skladiste;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDolgozat
{
    internal class Fuvar
    {
        int taxiAzonosito;
        DateTime indulasIdopontja;
        int utazasIdotartama;
        double megtettTavolsag;
        double viteldij;
        double borravalo;
        string fizetesModja;

        public Fuvar(int taxiAzonosito, DateTime indulasIdopontja, int utazasIdotartama, double megtettTavolsag, double viteldij, double borravalo, string fizetesModja)
        {
            this.taxiAzonosito = taxiAzonosito;
            this.indulasIdopontja = indulasIdopontja;
            this.utazasIdotartama = utazasIdotartama;
            this.megtettTavolsag = megtettTavolsag;
            this.viteldij = viteldij;
            this.borravalo = borravalo;
            this.fizetesModja = fizetesModja;
        }

        public int TaxiAzonosito { get => taxiAzonosito; }
        public DateTime IndulasIdopontja { get => indulasIdopontja; }
        public int UtazasIdotartama { get => utazasIdotartama; }
        public double MegtettTavolsag { get => megtettTavolsag; }
        public double Viteldij { get => viteldij; }
        public double Borravalo { get => borravalo; }
        public string FizetesModja { get => fizetesModja; }
    }
}

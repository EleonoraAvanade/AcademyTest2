using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2_AC.Classi
{
    public abstract class Movimento
    {
        public DateTime DataTransazione { get; set; }
        public double Importo { get; set; }
        public string Descrizione { get; set; }
        public override string ToString()
        {
            return $"Data transazione: {DataTransazione}\nImporto: {Importo}\nDescrizione {Descrizione}\n";
        }
    }
}

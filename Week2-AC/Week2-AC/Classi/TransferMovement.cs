using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2_AC.Classi
{
    public class TransferMovement:Movimento
    {
        public string BancaOrigine { get; set; }
        public string BancaDestinazione { get; set; }
        public override string ToString()
        {
            return base.ToString() + $"Dalla banca {BancaOrigine} a {BancaDestinazione}\n"; ;
        }
        public TransferMovement(DateTime dataTransazione, double importo, string descrizione, string bancaO, string bancaD)
        {
            DataTransazione = dataTransazione;
            Importo = importo;
            Descrizione = descrizione;
            BancaOrigine = bancaO;
            BancaDestinazione = bancaD;
        }
    }
}

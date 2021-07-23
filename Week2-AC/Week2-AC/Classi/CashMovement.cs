using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2_AC.Classi
{
    public class CashMovement:Movimento
    {
        public Account A { get; set; }
        public override string ToString()
        {
            return base.ToString()+$"Fatto da: {A}\n";
        }
        public CashMovement(DateTime dataTransazione, double importo, string descrizione, Account a)
        {
            DataTransazione = dataTransazione;
            Importo = importo;
            Descrizione = descrizione;
            A = a;
        }
    }
}

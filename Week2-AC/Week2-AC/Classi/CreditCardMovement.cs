using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2_AC.Classi
{
    public class CreditCardMovement:Movimento
    {
        public enum Tipo { Amex, Visa, Mastercard, Other};
        public int NumeroDellaCarta { get; set; }
        public Tipo Carta { get; set; }
        public override string ToString()
        {
            return base.ToString()+$"Numero della carta: {NumeroDellaCarta}\nCircuito: {Carta.ToString()}\n";
        }
        public CreditCardMovement(DateTime dataTransazione, double importo, string descrizione, int numeroDellaCarta, Tipo carta)
        {
            DataTransazione = dataTransazione;
            Importo = importo;
            Descrizione = descrizione;
            NumeroDellaCarta = numeroDellaCarta;
            Carta = carta;
        }
    }
}

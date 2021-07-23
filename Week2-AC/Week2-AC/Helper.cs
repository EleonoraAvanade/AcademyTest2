using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2_AC.Classi;

namespace Week2_AC
{
    public class Helper
    {
        public List<Account> utenti = new List<Account>();
        public bool SchermoMenu()
        {
            Console.WriteLine("Vuoi: \n\t1 - Creare un account\n\t2 - Inserire dei movimenti\n\t" +
                "3 - Stampare i dati del conto con i relativi movimenti\n\t4 - Exit");
            int input=GestisciInput(4);
            switch (input)
            {
                case 1:
                    CreaUtente();
                    break;
                case 2:
                    InserisciMovimenti();
                    break;
                case 3:
                    Stampa();
                    break;
                case 4:
                    return false;
                default:
                    Console.WriteLine("Errore");
                    return false;
            }
            return true;
        }

        private void Stampa()
        {
            Console.WriteLine("Da quale account vuoi stampare i dati e movimenti?\n");
            int count = 1;
            foreach (Account a in utenti)
            {
                Console.WriteLine(count + " - " + a);
                count++;
            }
            int input = GestisciInput(count);
            input--;
            utenti[input].Statement();
        }

        private void InserisciMovimenti()
        {
            Console.WriteLine("In quale account vuoi inserire i movimenti?\n");
            int count = 1;
            foreach(Account a in utenti)
            {
                Console.WriteLine(count+" - "+ a);
                count++;
            }
            int input=GestisciInput(count );
            input--;
            Console.WriteLine("inserisci la tipologia di Movimento tra:" +
                "\n\t1 - Cash\n\t2 - CreditCard\n\t3 - TransferMovement\n");
            int tipo = GestisciInput(3);
            Console.WriteLine("Data transazione: \n");
            DateTime DataTransazione = DateTime.MinValue;
            while (!DateTime.TryParse(Console.ReadLine(), out DataTransazione))
            {
                Console.WriteLine("Immetti un valore corretto\n");
            }
            Console.WriteLine("Importo: \n");
            double Importo = 0;
            while (!Double.TryParse(Console.ReadLine(), out Importo))
            {
                Console.WriteLine("Immetti un valore corretto\n");
            }
            Console.WriteLine("Descrizione: \n");
            string Descrizione = Console.ReadLine();
            Movimento m = null;
            bool check=utenti[input] + Importo;
            switch (tipo)
            {
                case 1:
                    m = new CashMovement(DataTransazione, Importo, Descrizione, utenti[input]);
                    utenti[input].movimenti.Add(m);
                    break;
                case 2:
                    Console.WriteLine("Numero della carta: \n");
                    int numeroCarta = 0;
                    while (!Int32.TryParse(Console.ReadLine(), out numeroCarta))
                    {
                        Console.WriteLine("Immetti un valore corretto\n");
                    }
                    Console.WriteLine("inserisci la tipologia di Movimento tra:" +
                        "\n\t1 - Amex\n\t2 - Visa\t\n3 - Mastercard\n\t4-Other\n");
                    int tipoCarta = GestisciInput(4);
                    if(tipoCarta==1)
                    m = new CreditCardMovement(DataTransazione, Importo, Descrizione, numeroCarta, CreditCardMovement.Tipo.Amex);
                    else if (tipoCarta == 2)
                    m = new CreditCardMovement(DataTransazione, Importo, Descrizione, numeroCarta, CreditCardMovement.Tipo.Visa);
                    else if (tipoCarta == 2)
                    m = new CreditCardMovement(DataTransazione, Importo, Descrizione, numeroCarta, CreditCardMovement.Tipo.Mastercard);
                    else if (tipoCarta == 2)
                    m = new CreditCardMovement(DataTransazione, Importo, Descrizione, numeroCarta, CreditCardMovement.Tipo.Other);
                    utenti[input].movimenti.Add(m);
                    break;
                case 3:
                    Console.WriteLine("Banca d'origine: \n");
                    string bancaO = Console.ReadLine();
                    Console.WriteLine("Banca destinazione: \n");
                    string bancaD = Console.ReadLine();
                    m = new TransferMovement(DataTransazione, Importo, Descrizione, bancaO, bancaD);
                    utenti[input].movimenti.Add(m);
                    break;
                default:
                    Console.WriteLine("errore\n");
                    break;
            }
        }

        private void CreaUtente()
        {
            Console.WriteLine("Immetti il numero di conto: ");
            int res = 0;
            while (!Int32.TryParse(Console.ReadLine(), out res))
            {
                Console.WriteLine("Immetti un valore corretto\n");
            }
            Console.WriteLine("Immetti il nome della banca: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Immetti il saldo: ");
            double saldo = 0;
            while (!Double.TryParse(Console.ReadLine(), out saldo))
            {
                Console.WriteLine("Immetti un valore corretto\n");
            }
            DateTime date = DateTime.Now;
            Account utente = new Account(res, nome, saldo, date);
            Console.WriteLine("Account correttamente creato!\n");
            utenti.Add(utente);
        }

        private int GestisciInput(int v)
        {
            int res=-1;
            while(res<1||res>v){
                Console.WriteLine("Immetti un valore corretto\n");
                Int32.TryParse(Console.ReadLine(), out res);
            }
            return res;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2_AC.Classi
{
    public class Account
    {
        public int NumeroConto { get; set; }
        public string NomeDellaBanca { get; set; }
        public double Saldo { get; set; }
        public DateTime DataUltimaOperazione { get; set; }
        public List<Movimento> movimenti { get; set; } = new List<Movimento>();
        public static bool operator +(Account a, double b)
        {
            if (b <= 0) return false;
            a.Saldo += b;
            a.DataUltimaOperazione = DateTime.Now;
            return true;
        }
        public static bool operator -(Account a, double b)
        {
            if (b >= 0) return false;
            a.Saldo -= b;
            a.DataUltimaOperazione = DateTime.Now;
            return true;
        }
        public override string ToString()
        {
            return $"Numero conto: {NumeroConto}\nNome della banca: {NomeDellaBanca}\n" +
                $"Saldo: {Saldo}\nData ultima operaione: {DataUltimaOperazione}\n";
        }
        public string Statement()
        {
            string thi=ToString();
            Console.WriteLine(thi);
            foreach (Movimento m in movimenti) Console.WriteLine(m);
            return thi;
        }
        public Account(int numero, string nome, double s, DateTime op)
        {
            NumeroConto = numero;
            NomeDellaBanca = nome;
            Saldo = s;
            DataUltimaOperazione = op;
        }
    }
}

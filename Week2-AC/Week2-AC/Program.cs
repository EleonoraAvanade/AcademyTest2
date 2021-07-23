using System;

namespace Week2_AC
{
    class Program
    {
        static void Main(string[] args)
        {
            bool check=true;
            Helper h = new Helper();
            Console.WriteLine("Benvenuto nel tuo wallet\n");
            while (check)
            {
                check=h.SchermoMenu();
            }
        }
    }
}

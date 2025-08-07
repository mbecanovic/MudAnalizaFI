using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Functions
{
    public class IzracunajVremeSablona
    {
        private static readonly Dictionary<string, double> kodoviVrednosti = new()
        {
            { "KA", 0.9 },
            { "AB1", 1.08 },
            { "AB2", 1.62 },
            { "AJ1", 1.44 },
            { "AJ2", 2.34 },
            { "AM1", 3.42 },
            { "AM2", 4.32 },
            { "PB1", 0.72 },
            { "PB2", 1.08 },
            { "PB3", 1.26 },
            { "ZA2", 0.54 },
            { "ZA3", 0.72 },
            { "PC1", 1.08 },

        };

        public static double IzracunajUkupnuVrednost(List<string> kodovi)
        {
            double suma = 0.0;

            foreach (var kod in kodovi)
            {
                var kljuc = kod.Trim().ToUpper(); // uklanja razmake i osigurava veliko slovo

                if (kodoviVrednosti.TryGetValue(kljuc, out double vrednost))
                {
                    suma += vrednost;
                }
                else
                {
                    Console.WriteLine($"Kod '{kod}' nije prepoznat.");
                }
            }

            return suma;
        }
    }
}
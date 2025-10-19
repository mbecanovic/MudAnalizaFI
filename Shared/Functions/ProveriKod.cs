using System;
using System.Collections.Generic;

namespace Shared.Functions
{
    public class ProveriKod
    {
        private static readonly HashSet<string> DozvoljeniKodovi = new HashSet<string>
        {
            "AB2", "AJ2", "AM2", "PB2", "PB3", "ZA2", "ZA3"
        };

        public static bool ProveriKodove(List<string> kodovi)
        {
            if (kodovi.Count >= 2)
            {
                if (kodovi[0] == "KA" && DozvoljeniKodovi.Contains(kodovi[1]))
                    return false;
            }

            if (kodovi.Count >= 4)
            {
                if (kodovi[2] == "KA" && DozvoljeniKodovi.Contains(kodovi[3]))
                    return false;
            }

            return true;
        }


    }
}

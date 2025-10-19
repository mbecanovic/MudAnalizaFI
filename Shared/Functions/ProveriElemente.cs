using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Functions
{
    public class ProveriElemente
    {
        public static bool ProveriElement(List<Element> elementi, List<Sablon> sabloni)
        {
            foreach (var element in elementi)
            {
                //proveravamo da li nas element zaista odgvara sablon (da li je stiopor itd)
                if (!sabloni.Any(s => s.GustinaId.Contains(element.GustinaId)))
                {
                    return false; // nema poklapanja gustine
                }


                // Pravilo 1: AB kod
                bool pravilo1 = element.Duzina <= 0.8 && element.Povrsina <= 0.09 && element.Tezina < 1
                                && sabloni.Any(s => s.Kod.Contains("AB1") || s.Kod.Contains("AB2") || s.Kod.Contains("KA"));

                // Pravilo 2 : AJ kod
                bool pravilo2 = false;
                if (element.Povrsina <= 0.09 && element.Tezina < 1)
                {
                    if (element.Duzina > 0.8 && element.Duzina < 1.3 && sabloni.Any(s => s.Kod.Contains("AJ1") || s.Kod.Contains("AJ2") || s.Kod.Contains("KA")))
                    {
                        pravilo2 = true; // prioritetno pravilo
                    }
                }
                if (element.Duzina <= 0.8 && element.Tezina < 1)
                {
                    if (element.Povrsina > 0.09 && sabloni.Any(s => s.Kod.Contains("AJ1") || s.Kod.Contains("AJ2") || s.Kod.Contains("KA")))
                    {
                        pravilo2 = true;
                    }
                }
                if (element.Duzina <= 0.8 && element.Povrsina <= 0.09)
                {
                    if (element.Tezina > 1 && element.Tezina <= 8 && sabloni.Any(s => s.Kod.Contains("AJ1") || s.Kod.Contains("AJ2") || s.Kod.Contains("KA")))
                    {
                        pravilo2 = true;
                    }
                }
                else
                {
                    pravilo2 = false;
                }

                // Pravilo 3: AM kod
                bool pravilo3 = false;

                if (sabloni.Any(s => (s.Kod.Contains("AM1") && s.Kod.Contains("KA")) || s.Kod.Contains("AM2") ))
                {
                    // Kombinacija 1: dužina >= 800, površina >= 0.09, težina 1–8
                    if (element.Duzina >= 0.8 && element.Povrsina >= 0.09 && element.Tezina >= 1 && element.Tezina <= 8)
                        pravilo3 = true;

                    // Kombinacija 2: dužina >= 800, površina >= 0.09, težina < 1
                    if (element.Duzina >= 0.8 && element.Povrsina >= 0.09 && element.Tezina < 1)
                        pravilo3 = true;

                    // Kombinacija 3: dužina >= 800, površina < 0.09, težina 1–8
                    if (element.Duzina >= 0.8 && element.Povrsina < 0.09 && element.Tezina >= 1 && element.Tezina <= 8)
                        pravilo3 = true;

                    // Kombinacija 4: dužina < 800, površina >= 0.09, težina 1–8
                    if (element.Duzina < 0.8 && element.Povrsina >= 0.09 && element.Tezina >= 1 && element.Tezina <= 8)
                        pravilo3 = true;
                }


                // Pravilo 4: Ostali kodovi PB1 PB2 PB3 ZA1 ZA2 PC1
                bool pravilo4 = false;
                if (sabloni.Any(s => s.Kod.Contains("PB1") || s.Kod.Contains("PB2")
                || s.Kod.Contains("PB3") || s.Kod.Contains("ZA1") || s.Kod.Contains("ZA2") || s.Kod.Contains("PC1")))
                {
                    pravilo4 = true;
                }
                


                    // Element je validan ako zadovoljava bilo koje pravilo
                    if (!(pravilo1 || pravilo2 || pravilo3 || pravilo4))
                    {
                    return false; // postoji bar jedan element koji nije ok
                    }
            }

            return true; // svi elementi zadovoljavaju bar jedno pravilo

        }

        public static string DodeliKod(Element element)
        {
            // Pravilo 1: AB kod
            if (element.Duzina <= 0.8 && element.Povrsina <= 0.09 && element.Tezina < 1)
            {
                return "AB";
            }
            // Pravilo 2 : AJ kod
            if (element.Povrsina <= 0.09 && element.Tezina < 1)
            {
                if (element.Duzina > 0.8 && element.Duzina < 1.3)
                {
                    return "AJ";
                }
            }
            if (element.Duzina <= 0.8 && element.Tezina < 1)
            {
                if (element.Povrsina > 0.09)
                {
                    return "AJ";
                }
            }
            if (element.Duzina <= 0.8 && element.Povrsina <= 0.09)
            {
                if (element.Tezina > 1 && element.Tezina <= 8)
                {
                    return "AJ";
                }
            }
            // Pravilo 3: AM kod
            int br = 0;

            if (element.Duzina >= 0.8)
                br++;

            if (element.Povrsina > 0.09)
                br++;

            if (element.Tezina >= 1 && element.Tezina <= 8)
                br++;

            // Ako su ispunjena najmanje dva uslova
            if (br >= 2)
                return "AM";
            else
                return "KA";

        }
    }
}
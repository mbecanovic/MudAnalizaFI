using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Functions
{
    public class CheckCode
    {
        public static void PrintElement(List<Element> element, Sablon sablon)
        {
            Console.WriteLine($"Za sablon: {sablon.Naziv}, ciji je kod {sablon.Kod}, kao i vreme {sablon.Vreme}");

            if (element == null || !element.Any())
            {
                Console.WriteLine("Lista elemenata je prazna.");
                return;
            }
            foreach (var el in element)
            {
              Console.WriteLine($"Id: {el.Id}, Naziv: {el.Naziv}, Sifra: {el.Sifra}, Duzina: {el.Duzina}, Sirina: {el.Sirina}, Visina: {el.Visina}, Tezina: {el.Tezina}, Povrsina: {el.Povrsina}, BrRadnika: {el.BrRadnika}, Datum: {el.Datum}, GustinaId: {el.GustinaId}, PaketId: {el.PaketId}, SablonId: {el.SablonId}, Kod: {el.Kod}, Vreme: {el.Vreme}");
            }
        }

        public static void CheckElementDimensions(List<Element> element, Sablon sablon)
        {
            string AB = "AB";



            //if element.zona=1 onda da predje na ovaj if dole
            if(sablon.Kod.Contains(AB))

            {
                foreach (var el in element)
                {
                    if (el.Duzina <= 0.8 && el.Povrsina <= 0.09 && el.Tezina < 1)

                    {
                        Console.WriteLine($"Element {el.Naziv} ima neispravne dimenzije: Duzina: {el.Duzina}, Sirina: {el.Sirina}, Visina: {el.Visina}");
                    }
                    else
                    {
                        Console.WriteLine($"Element {el.Naziv} ima ispravne dimenzije.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Šablon ne sadrži kod 'AB', provera dimenzija nije izvršena.");
            }
        }
    }
}
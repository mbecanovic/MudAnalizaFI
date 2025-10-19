using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json; // za ReadFromJsonAsync

namespace Shared.Functions
{
    public class UcitajElemente
    {
        private readonly HttpClient _httpClient;

        public UcitajElemente(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Element>> UcitajElementeAsync(List<string> sifre, List<string> sablonKod)
        {
            if (sifre == null || sifre.Count == 0)
                return new List<Element>();

            var query = string.Join(",", sifre);
            var url = $"/api/Elements/elementi?sifre={query}";
            var elementi = await _httpClient.GetFromJsonAsync<List<Element>>(url);

            // Console ispis pronađenih elemenata
            Console.WriteLine("Pronađeni elementi:");
            if (elementi != null)
            {
                foreach (var el in elementi)
                {
                    Console.WriteLine($"Šifra: {el.Sifra}, Naziv: {el.Naziv}");
                }
            }
            else
            {
                Console.WriteLine("Nema elemenata.");
            }

            // Dodeli kod šablona svakom elementu (primer)
            if (elementi != null && sablonKod != null)
            {
                foreach (var el in elementi)
                {
                    // Ovo je primer, možeš dodeliti celu listu ili neki specifičan kod
                    el.Kod = string.Join(",", sablonKod);
                    Console.WriteLine($"Dodeljen kod elementu {el.Sifra}: {el.Kod}");
                }
            }

            return elementi ?? new List<Element>();
        }
    }
}
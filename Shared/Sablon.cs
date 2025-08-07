using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Shared
{
    public class Sablon
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Sifra { get; set; }

        public List<string> Kod { get; set; } = new List<string>();
        public double? Vreme { get; set; }

        // Ako su ti potrebni ID-jevi gustina, koristi ovo:
        public List<int> GustinaId { get; set; } = new List<int>();

        // Lista povezanih Gustina objekata
        public virtual List<Gustina>? Gustine { get; set; }

        public List<int> Kvantitet { get; set; } = new List<int>();
    }
}

namespace Shared
{
    using System.Text.Json.Serialization;

    public class Element
    {
        public int Id { get; set; }
        public string? Naziv { get; set; }
        public string? Sifra { get; set; }
        public double Duzina { get; set; }
        public double Sirina { get; set; }
        public double Visina { get; set; }
        public double Tezina { get; set; }
        public double? BrRadnika { get; set; }
        public DateTime? Datum { get; set; }

        public int GustinaId { get; set; }

        [JsonIgnore]
        public virtual Gustina? Gustina { get; set; }

        public int PaketId { get; set; }

        [JsonIgnore]
        public virtual Paket? Paket { get; set; }
    }

}
